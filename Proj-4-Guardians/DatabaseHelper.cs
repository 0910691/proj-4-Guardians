using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace Proj_4_Guardians
{
    class DatabaseHelper
    {
        private string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Workouts.db3");
        public SQLiteConnection Connection;
        public SQLiteAsyncConnection A_Connection;
        public DatabaseHelper()
        {
            Connection = new SQLiteConnection(dbPath);
            A_Connection = new SQLiteAsyncConnection(dbPath);
        }
        public void CreateTable<T>(T table)
        {
            Connection.CreateTable<T>();
        }
        public void Add<C>(C instance)
        {
            Connection.InsertOrReplace(instance);
        }
    }
}