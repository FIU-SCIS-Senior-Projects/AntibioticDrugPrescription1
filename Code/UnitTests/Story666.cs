﻿using System;
using NUnit.Framework;
using Guida;

namespace UnitTests
{
    [TestFixture]
    public class Story666
    {
        [SetUp]
        public void Setup() {
            Database.connect();
        }

        [TearDown]
        public void Tear() {
            Database.db.DeleteAll<Doctor>();
        }

        /// <summary>
        /// A valid create user request to the database will return true
        /// Preconditions:  A Doctor object is created with:
        ///                     Username is not already in use
        ///                     password and name are not null
        /// Postconditions: True
        /// </summary>
        [Test]
        public void TC001()
        {
            Console.WriteLine("TC001");
            Doctor user = new Doctor();
            user.username = "testuser123";
            user.password = "987";
            user.name = "tester";
            Assert.True(Database.createUser(user));
        }


        /// <summary>
        /// An invalid create user request will return false
        /// Preconditions:  A Doctor exists in the database 
        ///                 A Doctor object is created with:
        ///                     Username that is already in use
        ///                     password and name are not null
        /// Postconditions: False
        /// </summary>
        [Test]
        public void TC002()
        {
            Console.WriteLine("TC002");

            //Insert precondition user into database
            Doctor user = new Doctor();
            user.username = "testuser123";
            user.password = "987";
            user.name = "tester";
            Database.createUser(user);

            //Create duplicate user
            user.username = "testuser123";
            user.password = "456";
            user.name = "tester1";

            //Try to create duplicate user
            Assert.False(Database.createUser(user));
        }

        /// <summary>
        /// An attempt to create a user with null username or password will return false
        /// preconditions: A doctor is created with a null username or password 
        /// postcondition: false
        /// </summary>
        [Test]
        public void TC003()
        {
            Console.WriteLine("TC003");

            //Insert precondition user into database
            Doctor user1 = new Doctor();
            user1.password = "987";
            user1.name = "tester";

            Doctor user2 = new Doctor();
            user2.username = "testuser123";
            user2.name = "tester";

            //Assert
            Assert.False(Database.createUser(user1) && Database.createUser(user2));
        }

        /// <summary>
        /// A authentication request with valid credentials will return the user
        /// Preconditions: A user exists in the database.
        ///                Username: testuser123
        ///                Password: 987
        /// PostConditions:Doctor object
        /// </summary>
        [Test]
        public void TC004()
        {
            Console.WriteLine("TC004");

            //Insert precondition user into database
            Doctor user = new Doctor();
            user.username = "testuser123";
            user.password = "987";
            user.name = "tester";
            Database.createUser(user);

            //Act
            Doctor loggedIn = Database.authenticate("testuser123", "987");

            //Assert
            Assert.True(loggedIn.username == user.username && loggedIn.password == user.password && loggedIn.name == user.name);
        }

        /// <summary>
        /// An authentication request with invalid credentials will return null
        /// Preconditions: A user exists in the database.
        ///                Username: testuser123
        ///                Password: 987
        /// PostConditions:null
        /// </summary>
        [Test]
        public void TC005()
        {
            Console.WriteLine("TC005");

            //Insert precondition user into database
            Doctor user = new Doctor();
            user.username = "testuser123";
            user.password = "987";
            user.name = "tester";
            Database.createUser(user);

            //Assert
            Assert.True(Database.authenticate("testuser123", "985") == null);
        }
    }
}