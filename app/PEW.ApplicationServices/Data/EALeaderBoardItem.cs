using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PEW.ApplicationServices.Data
{
    /*{"data":[{"rank":"1","gamertag":"Sonninho","ovrSkillPoints":"10003","skill":"77","wins":"429","losses":"18","ties":"2","dnfPercent":"2","gp":"449"}]*/
    public class EALeaderBoardItemContainer 
    {
        public IEnumerable<EALeaderBoardItem> data { get; set; }
    }


    /*{"rank":"2","gamertag":"MiksEi_","ovrSkillPoints":"9515","skill":"76","wins":"523","losses":"42","ties":"8","dnfPercent":"0","gp":"573"}*/

    public class EALeaderBoardItem
    {
        public string rank { get; set; }
        public string gamertag { get; set; }
        public string ovrSkillPoints { get; set; }
        public string skill { get; set; }
        public string wins { get; set; }
        public string ties { get; set; }
        public string losses { get; set; }
        public string dnfPercent { get; set; }
        public string gp { get; set; }
    }
}
