using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using O2.Kernel;
using O2.DotNetWrappers.ExtensionMethods;
using O2.External.SharpDevelop.ExtensionMethods;
using Microsoft.VisualStudio.CommandBars;
using SecurityInnovation.TeamMentor_VisualStudio_with_CatNet;
using O2.FluentSharp.REPL;
using O2.FluentSharp;
//O2Ref:TeamMentor_VisualStudio_with_CatNet.dll

//O2File:ExtensionMethods\VisualStudio_2010_ExtensionMethods.cs
 
namespace SecurityInnovaqtion.TeamMentor_VisualStudio_with_CatNet
//namespace O2.FluentSharp
{    
    public class TeamMentor_Gui
    {
        public static VisualStudio_2010     visualStudio;

        /*public static Panel                 LandingPages_Panel      { get; set; }
        public static WebBrowser            LandingPages_Browser    { get; set; }
        public static CommandBarPopup       TeamMentorMenu          { get; set; }
        public static String                DefaultPage             { get; set; }
        public static TM_CatNet_Options     TM_CatNet_Options       { get; set; }
        */

        public static TeamMentor_CatNet_Options Options
        {
            get
            {
                var value = "TeamMentor_CatNet_Options".o2Cache<TeamMentor_CatNet_Options>();
                if (value.isNull())
                {
                    value = new TeamMentor_CatNet_Options();
                    Options = value;
                }
                return value;
            }
            set
            {
                "TeamMentor_CatNet_Options".o2Cache<TeamMentor_CatNet_Options>(value);
            }
                    
        }
        public TeamMentor_Gui()
        {
            visualStudio = new VisualStudio_2010();
        }

        

        public TeamMentor_Gui buildGui()
        {
            installCatNet();
            createTopLevelMenu();
            createLandingPagesWindow();
            configureVisualStudioForCatNetAndTeamMentor();
			return this;
        }

        public TeamMentor_Gui createTopLevelMenu()
        {
            @"VS_Plugins\Create TeamMentor Menu.h2".local().executeH2Script();            
            return this;
        }
        public TeamMentor_Gui createOptionsWindow()
        {
            TeamMentor_Gui.visualStudio.open_Panel("TeamMentor Options").add_PropertyGrid().show(TeamMentor_Gui.Options);
            return this;
        }
        public TeamMentor_Gui createLandingPagesWindow()
        {            
            @"VS_Plugins\Create TeamMentor LandingPages Window.h2".local().executeH2Script();
            return this;
        }
        public TeamMentor_Gui configureVisualStudioForCatNetAndTeamMentor()
        {
            @"VS_Plugins\Script - Configure VisualStudio For CatNet and TM.h2".local().executeH2Script();
            return this;
        }
        


        
		public TeamMentor_Gui configureCatNetScanEnvironment()
		{
			var tmCatNetScript = @"VS_Scripts\Script - Configure VisualStudio For CatNet and TM.h2";
            tmCatNetScript.executeH2Script();
            return this;
		}		

        public Panel openScriptsViewer()
        {
            ////var baseFolder = @"E:\TeamMentor\TeamMentor_VisualStudio_Extensions\TeamMentor_VisualStudio_with_CatNet\VS_Scripts\";
            var baseFolder = @"VS_Scripts\Script - Configure VisualStudio For CatNet and TM.h2".local().parentFolder();
            var panel = visualStudio.create_WinForms_Window_Float("TeamMentor Scripts")
                                    .add_Panel()
                                    .insert_LogViewer();
            var script = panel.add_Script_With_FolderViewer(baseFolder);            
            return panel;
        }
        
            
        public void installCatNet()
        {
            "CatNet.cs".local()
                       .compile()
                       .type("CatNet")
                       .ctor();
        }
    }
    
}
