using System;
using System.Collections.Generic;
using System.Text;

namespace Guida
{
    class ApplicationFacade
    {
        Database db;
        public ApplicationFacade()
        {
            db = new Database();
        }

        /// <summary>
        /// Attempts to log in.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>
        /// True if logged in successfully
        /// False if log in failed
        /// </returns>
        public bool logIn(String username, String password)
        {
            return db.authenticate(username, password);
        }

        /// <summary>
        /// Attempts to add a user.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>
        /// True if user was added
        /// False is user was not added
        /// </returns>
        public bool addUser(String username, String password)
        {
            Doctor newUser = new Doctor();
            newUser.username = username;
            newUser.password = password;
            newUser.name = "";
            return db.createUser(newUser);
        }

        /// <summary>
        /// Attempts to add a user.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>
        /// True if user was added
        /// False is user was not added
        /// </returns>
        public bool addUser(String username,String password,String name)
        {
            Doctor newUser = new Doctor();
            newUser.username = username;
            newUser.password = password;
            newUser.name = name;
            return db.createUser(newUser);
        }
    }
}