﻿using Kaiyuanshe.OpenHackathon.Server.Cache;
using Kaiyuanshe.OpenHackathon.Server.Models;
using Kaiyuanshe.OpenHackathon.Server.Storage.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Kaiyuanshe.OpenHackathon.Server.Biz
{
    public interface IWorkManagement
    {
        /// <summary>
        /// Create a new team work. No existance check
        /// </summary>
        /// <returns></returns>
        Task<TeamWorkEntity> CreateTeamWorkAsync(TeamWork request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update a team work.
        /// </summary>
        Task<TeamWorkEntity> UpdateTeamWorkAsync(TeamWorkEntity existing, TeamWork request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a team work.
        /// </summary>
        /// <returns></returns>
        Task<TeamWorkEntity> GetTeamWorkAsync(string teamId, string workId, CancellationToken cancellationToken = default);

        /// <summary>
        /// List paginated works by team
        /// </summary>
        Task<IEnumerable<TeamWorkEntity>> ListPaginatedWorksAsync(string teamId, TeamWorkQueryOptions options, CancellationToken cancellationToken = default);


        /// <summary>
        /// Delete team work by Id
        /// </summary>
        Task DeleteTeamWorkAsync(string teamId, string workId, CancellationToken cancellationToken = default);
    }

    public class WorkManagement : ManagementClientBase, IWorkManagement
    {
        private readonly ILogger Logger;

        public WorkManagement(ILogger<WorkManagement> logger)
        {
            Logger = logger;
        }

        #region Cache
        private string CacheKeyWorks(string teamId)
        {
            return CacheKeys.GetCacheKey(CacheEntryType.TeamWork, teamId);
        }

        private void InvalidateCachedWorks(string teamId)
        {
            Cache.Remove(CacheKeyWorks(teamId));
        }

        private async Task<IEnumerable<TeamWorkEntity>> ListByTeamAsync(string teamId, CancellationToken cancellationToken)
        {
            return await Cache.GetOrAddAsync(
                CacheKeyWorks(teamId),
                TimeSpan.FromHours(4),
                (ct) => StorageContext.TeamWorkTable.ListByTeamAsync(teamId, ct),
                true,
                cancellationToken);
        }
        #endregion

        #region CreateTeamWorkAsync
        public async Task<TeamWorkEntity> CreateTeamWorkAsync(TeamWork request, CancellationToken cancellationToken = default)
        {
            if (request == null)
                return null;

            var entity = new TeamWorkEntity
            {
                PartitionKey = request.teamId,
                RowKey = Guid.NewGuid().ToString(),

                CreatedAt = DateTime.UtcNow,
                Description = request.description,
                HackathonName = request.hackathonName,
                Title = request.title,
                Type = request.type.GetValueOrDefault(TeamWorkType.website),
                Url = request.url,
            };
            await StorageContext.TeamWorkTable.InsertAsync(entity);

            InvalidateCachedWorks(request.teamId);
            return entity;
        }
        #endregion

        #region Task<TeamWorkEntity> UpdateTeamWorkAsync(TeamWorkEntity existing, TeamWork request, CancellationToken cancellationToken = default);
        public async Task<TeamWorkEntity> UpdateTeamWorkAsync(TeamWorkEntity existing, TeamWork request, CancellationToken cancellationToken = default)
        {
            if (existing == null || request == null)
                return existing;

            existing.Title = request.title ?? existing.Title;
            existing.Description = request.description ?? existing.Description;
            existing.Url = request.url ?? existing.Url;
            existing.Type = request.type.GetValueOrDefault(existing.Type);

            await StorageContext.TeamWorkTable.MergeAsync(existing, cancellationToken);
            InvalidateCachedWorks(existing.TeamId);
            return existing;
        }
        #endregion

        #region Task<TeamWorkEntity> GetTeamWorkAsync(string teamId, string workId, CancellationToken cancellationToken = default);
        public async Task<TeamWorkEntity> GetTeamWorkAsync(string teamId, string workId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(teamId) || string.IsNullOrWhiteSpace(workId))
                return null;

            return await StorageContext.TeamWorkTable.RetrieveAsync(teamId, workId, cancellationToken);
        }
        #endregion

        #region Task<IEnumerable<TeamWorkEntity>> ListPaginatedWorksAsync(string teamId, TeamWorkQueryOptions options, CancellationToken cancellationToken = default);
        public async Task<IEnumerable<TeamWorkEntity>> ListPaginatedWorksAsync(string teamId, TeamWorkQueryOptions options, CancellationToken cancellationToken = default)
        {
            var allWorks = await ListByTeamAsync(teamId, cancellationToken);

            // paging
            int np = 0;
            int.TryParse(options.TableContinuationToken?.NextPartitionKey, out np);
            int top = options.Top.GetValueOrDefault(100);
            var works = allWorks.OrderByDescending(a => a.CreatedAt)
                .Skip(np)
                .Take(top);

            // next paging
            options.Next = null;
            if (np + top < allWorks.Count())
            {
                options.Next = new TableContinuationToken
                {
                    NextPartitionKey = (np + top).ToString(),
                    NextRowKey = (np + top).ToString(),
                };
            }

            return works;
        }
        #endregion

        #region Task DeleteTeamWorkAsync(string teamId, string workId, CancellationToken cancellationToken = default);
        public async Task DeleteTeamWorkAsync(string teamId, string workId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(teamId) || string.IsNullOrWhiteSpace(workId))
                return;

            await StorageContext.TeamWorkTable.DeleteAsync(teamId, workId, cancellationToken);
        }
        #endregion
    }
}