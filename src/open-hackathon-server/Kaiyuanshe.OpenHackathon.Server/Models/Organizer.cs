﻿using Kaiyuanshe.OpenHackathon.Server.Models.Validations;
using System.ComponentModel.DataAnnotations;

namespace Kaiyuanshe.OpenHackathon.Server.Models
{
    /// <summary>
    /// Represents an organizer who organizes/sponsors the hackathon.
    /// </summary>
    public class Organizer
    {
        /// <summary>
        /// name of hackathon
        /// </summary>
        /// <example>foo</example>
        public string hackathonName { get; internal set; }

        /// <summary>
        /// auto-generated id of the organizer.
        /// </summary>
        /// <example>9ffbe751-975f-46a7-b4f7-48f2cc2805b0</example>
        public string id { get; internal set; }

        /// <summary>
        /// Name of the organizer.
        /// </summary>
        /// <example>开源社</example>
        [MaxLength(64)]
        [RequiredIfPut]
        public string name { get; set; }

        /// <summary>
        /// description of the organzier
        /// </summary>
        /// <example>专注于“开源治理、社区发展、国际接轨、开源项目”的开源社区联盟.</example>
        [MaxLength(256)]
        public string description { get; set; }

        /// <summary>
        /// target whom the award is given. team or individual. team by default.
        /// </summary>
        /// <example>team</example>
        [RequiredIfPut]
        public OrganizerType? target { get; set; }

        /// <summary>
        /// A logo picture.
        /// </summary>
        [RequiredIfPut]
        public PictureInfo logo { get; set; }
    }

    /// <summary>
    /// Type of organizer. host:主办, organizer:承办，coorganzer:协办, sponsor:赞助, titleSponsor:冠名
    /// </summary>
    public enum OrganizerType
    {
        host,
        organizer,
        coorganizer,
        sponsor,
        titleSponsor,
    }
}
