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
using SQLite; // sqlite niet goed geïnstalleerd?

namespace Proj_4_Guardians.Database
{
    class DB
    {
        //string k = "SQLite.Net.SQLiteConnection";
        private SQLiteConnection DbConn;

        #region Connection
        public DB()
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "recycler.db3");

            // sqlite connection
            DbConn = new SQLiteConnection(dbPath);
            //DbConn = new SQLiteConnection(null, dbPath);
        }

        public SQLiteConnection Conn()
        {
            return DbConn;
        }

        #endregion

        #region Select 

        // Here are the select from <Table> statements

        //Select from state without filters
        public IEnumerable<T> SelectFrom<T>(string query) where T : new() //<-- this means the query returns new objects of generic "T"
        {
            return DbConn.DeferredQuery<T>(query);
            //return DbConn.DeferredQuery<T>(query, null);
        }

        public IEnumerable<T> SelectFrom<T>(string query, string filter) where T : new()
        {
            return DbConn.DeferredQuery<T>(query, filter);
        }

        //Select statement with filters
        public IEnumerable<T> SelectFrom<T>(string query, string[] filters) where T : new()
        {
            return DbConn.DeferredQuery<T>(query, filters);
        }

        // create more functions with the same name but more filters ...........

        #endregion

        #region Delete & Update
        //Here are the Delete from <table> 

        //Delete from Query without filters
        public void Execute(string query)
        {
            DbConn.Execute(query);
        }

        //Delete from Query with 1 filter
        public void Execute(string query, string filter)
        {
            DbConn.Execute(query, filter);
        }

        //Delete from Query with filters
        public void Execute(string query, string[] filters)
        {
            DbConn.Execute(query, filters);
        }

        #endregion

        #region Create table
        //Create table from an Object
        public void CreateTable<T>()
        {
            DbConn.CreateTable(typeof(T));
        }

        #endregion

        #region Insert
        //Insert into an db table from an existing object
        public void Insert<T>(T Object)
        {
            DbConn.Insert(Object);
        }

        #endregion
    }
}