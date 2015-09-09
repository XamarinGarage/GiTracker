﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GiTracker.Resources.Strings {
    using System;
    using System.Reflection;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class IssueDetails {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal IssueDetails() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("GiTracker.Resources.Strings.IssueDetails", typeof(IssueDetails).GetTypeInfo().Assembly);
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
        ///   Looks up a localized string similar to {0} opened this issue.
        /// </summary>
        internal static string CreatedBy {
            get {
                return ResourceManager.GetString("CreatedBy", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Issue #{0}.
        /// </summary>
        internal static string IssueNumber {
            get {
                return ResourceManager.GetString("IssueNumber", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Closed.
        /// </summary>
        internal static string IssueStatus_Closed {
            get {
                return ResourceManager.GetString("IssueStatus_Closed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Merged.
        /// </summary>
        internal static string IssueStatus_ClosedPullRequest {
            get {
                return ResourceManager.GetString("IssueStatus_ClosedPullRequest", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Open.
        /// </summary>
        internal static string IssueStatus_Open {
            get {
                return ResourceManager.GetString("IssueStatus_Open", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Open.
        /// </summary>
        internal static string IssueStatus_OpenPullRequest {
            get {
                return ResourceManager.GetString("IssueStatus_OpenPullRequest", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Log time.
        /// </summary>
        internal static string LogWork {
            get {
                return ResourceManager.GetString("LogWork", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to at {0:g}.
        /// </summary>
        internal static string TimeAt {
            get {
                return ResourceManager.GetString("TimeAt", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unknown.
        /// </summary>
        internal static string Unknown {
            get {
                return ResourceManager.GetString("Unknown", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to View in browser.
        /// </summary>
        internal static string ViewInBrowser {
            get {
                return ResourceManager.GetString("ViewInBrowser", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Time logs.
        /// </summary>
        internal static string WorkLogs {
            get {
                return ResourceManager.GetString("WorkLogs", resourceCulture);
            }
        }
    }
}
