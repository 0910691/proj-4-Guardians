using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Proj_4_Guardians.Database
{
    class afvallocaties
    {
        public string LoospuntTitel { get; set; }
        public string Straat { get; set; }
        public string Long { get; set; }
        public string Lat { get; set; }

        public afvallocaties(string loospunt, string straat, string lengte, string breedte)
        {
            this.LoospuntTitel = loospunt;
            this.Straat = straat;
            this.Long = lengte;
            this.Lat = breedte;
        }
        public afvallocaties()
        {

        }
    }
}