﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kaiyuanshe.OpenHackathon.Server {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Kaiyuanshe.OpenHackathon.Server.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Forbidden. The user associated with the token doesn&apos;t have proper permission. Please contact the administrator for access..
        /// </summary>
        internal static string Auth_Forbidden {
            get {
                return ResourceManager.GetString("Auth_Forbidden", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The access token cannot be validated. Code:{0}, Message:{1}.
        /// </summary>
        internal static string Auth_Token_ValidateRemoteFailed {
            get {
                return ResourceManager.GetString("Auth_Token_ValidateRemoteFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Token expired at {0}. Please re-login..
        /// </summary>
        internal static string Auth_TokenExpired {
            get {
                return ResourceManager.GetString("Auth_TokenExpired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Token is either missing or invalid. Please add it to Http request headers: Headers[&quot;Authorization&quot;]=token TOKEN. .
        /// </summary>
        internal static string Auth_Unauthorized {
            get {
                return ResourceManager.GetString("Auth_Unauthorized", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enrollment already ended at {0}.
        /// </summary>
        internal static string Hackathon_Enrollment_Ended {
            get {
                return ResourceManager.GetString("Hackathon_Enrollment_Ended", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enrollment not started. The enrollment will be accepted starting from {0}.
        /// </summary>
        internal static string Hackathon_Enrollment_NotStarted {
            get {
                return ResourceManager.GetString("Hackathon_Enrollment_NotStarted", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Hackathon with name {0} not found. Try PUT to create a new one..
        /// </summary>
        internal static string Hackathon_NotFound {
            get {
                return ResourceManager.GetString("Hackathon_NotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An unexpected exception occurs. Please try again later or report an issue at https://github.com/kaiyuanshe/open-hackathon/issues.
        /// </summary>
        internal static string Hackathon_UnhandledException {
            get {
                return ResourceManager.GetString("Hackathon_UnhandledException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Required parameter {0} is null or empty..
        /// </summary>
        internal static string Parameter_Required {
            get {
                return ResourceManager.GetString("Parameter_Required", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Access denied. Only the admins of the event are allowed. Please contact the admin to request access..
        /// </summary>
        internal static string Request_Forbidden_HackAdmin {
            get {
                return ResourceManager.GetString("Request_Forbidden_HackAdmin", resourceCulture);
            }
        }
    }
}
