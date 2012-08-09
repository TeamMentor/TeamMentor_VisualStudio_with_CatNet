using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SecurityInnovation.TeamMentor_VisualStudio_with_CatNet
{
    public class TeamMentor_CatNet_Options
    {
        public bool AutoScanOnBuild { get; set; }
        public bool OpenLinksInNewTab { get; set; }
        public string TeamMentorServer { get; set; }
        //public string CatNet_InstallDir { get; set; }
        //public string Extension_InstallDir { get; set; }        
        public String DefaultPage { get; set; }

        public Panel LandingPages_Panel { get; set; }
        public WebBrowser LandingPages_Browser { get; set; }

        public TeamMentor_CatNet_Options()
        {
            AutoScanOnBuild = true;
            OpenLinksInNewTab = true;
            TeamMentorServer = "http://teammentor.net";
            DefaultPage = "http://docs.teammentor.net/article/TeamMentor_Landing_Page";
        }
    }
}
