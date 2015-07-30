﻿using System;
using Xamarin.Forms;
using GiTracker.iOS.Injections;
using GiTracker.Database;
using System.IO;

[assembly: Dependency (typeof(SQLiteTouch))]

namespace GiTracker.iOS.Injections
{
    public class SQLiteTouch : ISQLite
    {
        public SQLite.SQLiteConnection GetConnection ()
        {
            var documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine (documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, Constants.DatabaseName);
            return new SQLite.SQLiteConnection(path);
        }}
    }
}

