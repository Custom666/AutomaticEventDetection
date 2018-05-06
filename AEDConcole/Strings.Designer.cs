﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AEDConcole {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Strings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Strings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("AEDConcole.Strings", typeof(Strings).Assembly);
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
        ///   Looks up a localized string similar to [symptomAlgorithm] - bow : Bag of words.
        /// </summary>
        internal static string Bow {
            get {
                return ResourceManager.GetString("Bow", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &quot;There is no such detection method that you requested!&quot;.
        /// </summary>
        internal static string DetectionMethodError {
            get {
                return ResourceManager.GetString("DetectionMethodError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Format: [tweets] [symptomAlgorithm] [optional: .vec file] [method] [optional: integer k] [output].
        /// </summary>
        internal static string ExecutionFormat {
            get {
                return ResourceManager.GetString("ExecutionFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Input file not found!.
        /// </summary>
        internal static string FileNotFound {
            get {
                return ResourceManager.GetString("FileNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to [symptomAlgorithm] - ft : Fast test based on average (this option need specify [optional: .vec file] as path to .vec file with dictionary).
        /// </summary>
        internal static string FT {
            get {
                return ResourceManager.GetString("FT", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This program take csv file [tweets] iand create symptoms from them by [symptomAlgorithm] and classify them with supervised [method] and finally write result into [output] csv file..
        /// </summary>
        internal static string Help {
            get {
                return ResourceManager.GetString("Help", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to [method] - knn : K-Nearest neighbours (This option need to specify [option: integer k] as positive integer k).
        /// </summary>
        internal static string KNN {
            get {
                return ResourceManager.GetString("KNN", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to [method] - mdm : Minimal distance method.
        /// </summary>
        internal static string MDM {
            get {
                return ResourceManager.GetString("MDM", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Path, where result should be store.
        /// </summary>
        internal static string Output {
            get {
                return ResourceManager.GetString("Output", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Output file has wrong format!.
        /// </summary>
        internal static string OutputError {
            get {
                return ResourceManager.GetString("OutputError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Number has to be positive integer!.
        /// </summary>
        internal static string PositiveIntegerError {
            get {
                return ResourceManager.GetString("PositiveIntegerError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &quot;There is no such symtoms algorithm that you requested!&quot;.
        /// </summary>
        internal static string SymptomAlgorithmError {
            get {
                return ResourceManager.GetString("SymptomAlgorithmError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to [symptomAlgorithm] - tf-idf : Term frequency-Inverse document frequency.
        /// </summary>
        internal static string TFIDF {
            get {
                return ResourceManager.GetString("TFIDF", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to [tweets] - Path to csv file. Each event in file has to be in the following format: IsEvent;EventType;Id;Culture;Datetime;Message;.
        /// </summary>
        internal static string Tweets {
            get {
                return ResourceManager.GetString("Tweets", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Input file has wrong formatted data. .
        /// </summary>
        internal static string WrongFileFormat {
            get {
                return ResourceManager.GetString("WrongFileFormat", resourceCulture);
            }
        }
    }
}