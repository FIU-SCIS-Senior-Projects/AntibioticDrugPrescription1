using System;
using System.Collections.Generic;
using System.Text;

namespace Guida
{
	//appSettings make sure only one Controller is created and it can be accessed in the front end
    public static class appSettings {

		public static Controller controller;
		public static Controller getController()
		{
			if (controller == null)
			{
				controller = new Controller();
				Data.insertData();
			}
			return controller;
		}
		public static void SetController(Controller ctrl)
		{
			controller = ctrl;
		}
    }

	//Controller is the logic layer of the program.
	//It contain all the functions required by the program
    public class Controller
    {
		//Create a new Database
        Database db;
        public Controller()
        {
			db = new Database();
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
		public bool addUser(String username, String password, String name)
		{
			Doctor newUser = new Doctor();
			newUser.username = username;
			newUser.password = password;
			newUser.name = name;
			return db.createUser(newUser);
		}


		/// <summary>
		/// Add a the patient.
		/// </summary>
		/// <returns>
		/// True if Patient was added
		/// False if Patient was not added 
		/// </returns>
		/// <param name="name">Name.</param>
		/// <param name="DoB">Dob.</param>
		public bool addPatient(String name, String DoB)
		{
			Patient newUser = new Patient();
			newUser.name = name;
			newUser.DoB = DoB;
			return db.createPatient(newUser);
		}

		/// <summary>
		/// Adds the doctor patient.
		/// </summary>
		/// <returns>DoctorPatient.</returns>
		/// <param name="patient_id">Patient identifier.</param>
		/// <param name="username">Username.</param>
		public bool addDoctorPatient(int patient_id, String username)
		{
			DoctorPatient newUser = new DoctorPatient();
			newUser.patient_id = patient_id;
			newUser.doctor = username;
			return db.createDoctorPatient(newUser);
		}

		/// <summary>
		/// Attempts to add an antibiotic to the database
		/// </summary>
		/// <param name="name"></param>
		/// <param name="acceptableUses"></param>
		/// <param name="price"></param>
		/// <param name="toxicity"></param>
		/// <returns>
		/// True if it was added
		/// False otherwise
		/// </returns>
		public bool addAntibiotic(String name, String acceptableUses, int price, String toxicity)
		{
			Antibiotic antibiotic = new Antibiotic();
			antibiotic.name = name;
			antibiotic.acceptableUses = acceptableUses;
			antibiotic.price = price;
			antibiotic.toxicity = toxicity;
			return db.addAntibiotic(antibiotic);
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
			Doctor user = db.authenticate(username, password);
			if (user == null) return false;

			Session.user = user;
			return true;

		}
       
		/// <summary>
		/// Find all the patients with the same name as the input
		/// </summary>
		/// <returns>A List of Patients</returns>
		/// <param name="name">Name.</param>
		public List<Patient> getPatientList(String name)
		{
			return db.getPatientList(name);
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
    }
}