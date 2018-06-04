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
    class afvalsoort
    {
        public string AfvalTitel { get; set; }
        public string Categorie { get; set; }
        public string LoospuntTitel { get; set; }
        public string Toelichting { get; set; }

        public afvalsoort(string titel, string categorie, string loospunt, string toelichting)
        {
            this.AfvalTitel = titel;
            this.Categorie = categorie;
            this.LoospuntTitel = loospunt;
            this.Toelichting = toelichting;
        }

        public afvalsoort()
        {

        }
    }
}