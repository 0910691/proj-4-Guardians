using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
//using SQLite; // sqlite niet goed geïnstalleerd?

namespace Proj_4_Guardians.Database
{
    class DB
    {
       // private SQLiteConnection DbConn;

        public DB()
        {
            string dbpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Recycler.db3");

          //  DbConn = new SQLiteConnection(dbpath);
        }
    }
}