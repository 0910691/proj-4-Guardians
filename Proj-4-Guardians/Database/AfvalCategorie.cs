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
    class afvalcategorie
    {
        public string Categorie { get; set; }
        public string CategorieOmschrijving { get; set; }

        public afvalcategorie(string categorie, string omschrijving)
        {
            this.Categorie = categorie;
            this.CategorieOmschrijving = omschrijving;
        }

        public afvalcategorie()
        {

        }
    }
}