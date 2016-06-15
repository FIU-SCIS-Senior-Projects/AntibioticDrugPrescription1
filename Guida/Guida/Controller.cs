using System;
using System.Collections.Generic;
using System.Text;

namespace Guida
{
    class Controller
    {
        Database db;
        public Controller()
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
		/// Adds the patient.
		/// </summary>
		/// <returns>The patient.</returns>
		/// <param name="name">Name.</param>
		/// <param name="DoB">Do b.</param>
		public bool addPatient(String name, String DoB)
		{
			Patient newUser = new Patient();
			newUser.name = name;
			newUser.DoB = DoB;
			return db.createPatient(newUser);
		}


		public bool addDoctorPatient(int id, String username)
		{
			DoctorPatient newUser = new DoctorPatient();
			newUser.id = id;
			newUser.doctor = username;
			return db.createDoctorPatient(newUser);
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

		public List<string> patientsList(string username)
		{
			return db.DisplayPatients(username);
		}

		public List<string> allDoctors()
		{
			return db.DisplayAllDoctors();
		}

		public List<string> allPatients()
		{
			return db.DisplayAllPatients();
		}

		public List<string> allDoctorPatient()
		{
			return db.DisplayAllDoctorPatient();
		}

		public List<string> all()
		{
			return db.DisplayAll();
		}
    }
}