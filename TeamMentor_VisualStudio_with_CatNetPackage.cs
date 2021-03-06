﻿using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using Microsoft.Win32;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;

using O2.DotNetWrappers.ExtensionMethods;
using O2.FluentSharp;
using System.Windows.Forms;
using O2.DotNetWrappers.DotNet;

namespace SecurityInnovation.TeamMentor_VisualStudio_with_CatNet
{    
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    [Guid(GuidList.guidTeamMentor_VisualStudio_with_CatNetPkgString)]
    [ProvideAutoLoad(UIContextGuids80.NoSolution)]
    public sealed class TeamMentor_VisualStudio_with_CatNetPackage : NoSolution_Package
    {
        public TeamMentor_VisualStudio_with_CatNetPackage()
        {
            Trace.WriteLine("Entering constructor for: {0}".format(this.ToString()));            
        }


        protected override void Initialize()
        {
            Trace.WriteLine (string.Format(CultureInfo.CurrentCulture, "Entering Initialize() of: {0}", this.ToString()));

            if (Control.ModifierKeys == Keys.Shift)
                VisualStudio_O2_Utils.open_LogViewer();
            VisualStudio_O2_Utils.compileAndExecuteScript(@"VS_Scripts\TeamMentor_Gui.cs", "TeamMentor_Gui", "buildGui");
            base.Initialize();
        }        

    }
}
