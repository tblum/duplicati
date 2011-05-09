﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Duplicati.Library.Backend.Strings {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class SSHCommonOptions {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal SSHCommonOptions() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Duplicati.Library.Backend.Strings.SSHCommonOptions", typeof(SSHCommonOptions).Assembly);
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
        ///   Looks up a localized string similar to An error occured while setting up the SSH dialog: {0}.
        /// </summary>
        internal static string LoadError {
            get {
                return ResourceManager.GetString("LoadError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The entered SFTP program could not be found.
        ///Do you want to use the path anyway?.
        /// </summary>
        internal static string LocatingSftpError {
            get {
                return ResourceManager.GetString("LocatingSftpError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Leave empty to use the sftp application found: {0}.
        /// </summary>
        internal static string SftpAutodetectedInfo {
            get {
                return ResourceManager.GetString("SftpAutodetectedInfo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The sftp application could not be located, please enter the path manually.
        /// </summary>
        internal static string SftpNotAutodetectedWarning {
            get {
                return ResourceManager.GetString("SftpNotAutodetectedWarning", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An error occured while attempting to verify the sftp program path:
        ///{0}
        ///
        ///Do you want to use the path anyway?.
        /// </summary>
        internal static string SftpProgramNotFoundError {
            get {
                return ResourceManager.GetString("SftpProgramNotFoundError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You have not entered a path to the SFTP application.
        ///This will use the default path to the SFTP application. 
        ///The SFTP application could not be found during system probing.
        ///Are you sure this is what you want?.
        /// </summary>
        internal static string UseEmptyPathWarning {
            get {
                return ResourceManager.GetString("UseEmptyPathWarning", resourceCulture);
            }
        }
    }
}