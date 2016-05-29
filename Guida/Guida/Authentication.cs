using System;
using SQLite;
using System.IO;

namespace Guida
{
   
	public class Authentication
	{
        
        SQLiteConnection db;
        public Authentication()
		{
            Database database = new Database();
            db = database.db;
        }

        public bool authenticate(string username, string password)
        {
            var users = db.Table<Doctor>();
            bool auth = false;
            foreach (var doc in users)
            {
                if (doc.username == username && doc.password == password)
                {
                    auth = true;
                    break;
                }
            }
            return auth;
        }
	}
}

