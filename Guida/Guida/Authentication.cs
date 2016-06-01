using System;
using SQLite;
using System.IO;

namespace Guida
{
    /// <summary>
    /// This is serving as a test for the backend right now.
    /// ToDo: Delete this file and replace with backend controller.
    /// </summary>
	public class Authentication
	{
        Database database;
        public Authentication()
		{
            database = new Database();
            Doctor user = new Doctor();
            user.name = "Sean";
            user.password = "199";
            user.username = "3digit";
            database.createUser(user);
        }

        public bool authenticate(String username, String password)
        {
            return database.authenticate(username, password);
        }
        
	}
}

