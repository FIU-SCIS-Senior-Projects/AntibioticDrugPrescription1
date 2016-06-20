﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Guida
{
    public static class appSettings {
        public static Controller controller {
            get {
                if(controller == null) {
                    controller = new Controller();
                }
                return controller;
            }
            set {
                controller = value;
            }
        }
    }

    public class Controller
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
            Doctor user =  db.authenticate(username, password);
            if (user == null) return false;
            else {
                Session.user = user;
                User.doc = user;
                return true;
            }
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

		public List<string> patientsIDList(string username)
		{
			return db.DisplayPatientsID(username);
		}

		public bool patientExist(int id)
		{
			return db.patientExist(id);
		}

        /// <summary>
        /// Retrieves an antibiotic from the database with a given name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>
        /// Antibiotic if name exists
        /// null otherwise
        /// </returns>
        public Antibiotic getAntibiotic(String name)
        {
            return db.getAntibiotic(name);
        }

        /// <summary>
        /// Attempts to add an antibiotic to the database
        /// </summary>
        /// <param name="name"></param>
        /// <param name="acceptableUses"></param>
        /// <param name="price"></param>
        /// <param name="toxicity"></param>
        /// <returns></returns>
        public bool addAntibiotic(String name, String acceptableUses, int price, String toxicity)
        {
            Antibiotic antibiotic = new Antibiotic();
            antibiotic.name = name;
            antibiotic.acceptableUses = acceptableUses;
            antibiotic.price = price;
            antibiotic.toxicity = toxicity;
            return db.addAntibiotic(antibiotic);
        }
    }
}