﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:2.0.50727.4952
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace IntVideoSurv.DMClient {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0")]
    internal sealed partial class SMClientSetting : global::System.Configuration.ApplicationSettingsBase {
        
        private static SMClientSetting defaultInstance = ((SMClientSetting)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new SMClientSetting())));
        
        public static SMClientSetting Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("192.168.1.108")]
        public string RemotingServerIP {
            get {
                return ((string)(this["RemotingServerIP"]));
            }
        }
    }
}