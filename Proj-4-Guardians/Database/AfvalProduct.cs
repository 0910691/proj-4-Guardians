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
    class afvalproduct
    {
        public string ProductTitel { get; set; }
        public string AfvalTitel { get; set; }

        public afvalproduct(string product, string afval)
        {
            this.ProductTitel = product;
            this.AfvalTitel = afval;
        }

        public afvalproduct()
        {

        }
    }
}