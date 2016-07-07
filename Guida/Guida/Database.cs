using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.IO;

namespace Guida
{
    /// <summary>
    /// Represents the database table "doctors"
    /// Doctor is the user of the system.
    /// Doctor has a unique username, a password and a name.
    /// </summary>
    [Table("doctors")]
    public class Doctor
    {
        [PrimaryKey, Unique, Column("username")]
        public String username { get; set; }
        [Column("password")]
        public String password { get; set; }
        [Column("name")]
        public String name { get; set; }
    }

    /// <summary>
    /// Represents the database table "patients"
	/// Patient has a unique id, name and a DoB(Date of Birth)
    /// </summary>
    [Table("patients")]
    public class Patient
    {
        [PrimaryKey, AutoIncrement, Column("id")]
		public int id { get; set;}
        [Column("name")]
        public String name { get; set; }
        [Column("DoB")]
        public String DoB { get; set; }
    }

	/// <summary>
	/// Represents a relashionship between a doctor an a patient
	/// Doctor=Patient has a unique id, patient_id, and doctor username
	/// </summary>
	[Table("doctor-patient")]
	public class DoctorPatient
	{
		[PrimaryKey, AutoIncrement, Column("id")]
		public int id { get; set; }
		[Column("patient_id")]
		public int patient_id {get;set;}
        [Column("doctor")]
        public String doctor { get; set; }
    }

    /// <summary>
    /// Represents the database table "visits"
    /// Visit has a unique id, date, patient, and doctor
    /// </summary>
    [Table("visits")]
    public class Visit
    {
        [PrimaryKey, AutoIncrement,Column("id")]
		public int id { get; set;}
        [Column("date")]
        public String date { get; set; }
        [Column("patient")]
        public String patient { get; set; }
        [Column("doctor")]
        public String doctor { get; set; }
    }

    /// <summary>
    /// Represents the batabase table "disease"
    /// Disease has a unique name, and an affectedArea.
    /// </summary>
    [Table("disease")]
    public class Disease
    {
        [PrimaryKey,Column("name")]
        public String name { get; set; }
        [Column("affectedArea")]
		public String affectedArea { get; set; }
    }

    /// <summary>
    /// Represents the database table "antibiotics"
    /// Antibiotic has a unique name, a price, acceptable uses, and a toxicity.
    /// </summary>
    [Table("antibiotics")]
    public class Antibiotic
    {
        [PrimaryKey, Column("name")]
        public string name { get; set; }
        [Column("price")]
        public int price { get; set; }
        [Column("acceptableUses")]
        public string acceptableUses { get; set; }
        [Column("toxicity")]
        public string toxicity { get; set; }
    }

    [Table("rules")]
    public class Rule {
        [PrimaryKey, AutoIncrement,Column("id")]
        public int id { get; set; }
        [Column("illness")]
        public string illness { get; set; }
        [Column("condition")]
        public string condition { get; set; }
        [Column("antibiotic")]
        public string antibiotic { get; set; }
    }

    /// <summary>
    /// This class represents a connection to the local database.
    /// </summary>
    public static class Database
    {
        public static SQLiteConnection db;

        /// <summary>
        /// Creates a connection to the DB. DB location is based on operating system. 
        /// Creates all tables if they don't already exist.
        /// </summary>
        public static void connect()
        {
            if (db != null) return;
            var sqliteFilename = "Guida.db3";
#if __ANDROID__
            // Just use whatever directory SpecialFolder.Personal returns
            string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
#else
            // we need to put in /Library/ on iOS5.1 to meet Apple's iCloud terms
            // (they don't want non-user-generated data in Documents)
            string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
            string libraryPath = Path.Combine (documentsPath, "..", "Library"); // Library folder instead
#endif
            var path = Path.Combine(libraryPath, sqliteFilename);
            db = new SQLiteConnection(path);
            db.CreateTable<Doctor>();
            db.CreateTable<Patient>();
            db.CreateTable<DoctorPatient>();
            db.CreateTable<Visit>();
            db.CreateTable<Disease>();
            db.CreateTable<Antibiotic>();
            db.CreateTable<Rule>();
        }

        /// <summary>
        /// Adds a user to the database.
        /// </summary>
        /// <param name="doc">
        /// The Doctor object to be created.
        /// Must have a unique username, a password and a name.
        /// </param>
        /// <returns>
        /// True if the user was created successully.
        /// False if the user was not created.
        /// </returns>
        public static bool createUser(Doctor doc)
        {
            if (doc.password == null) return false;
            if (doc.username == null) return false;
            var users = db.Table<Doctor>();
            foreach (Doctor x in users)
            {
                if (x.username == doc.username)
                {
                    return false;
                }
            }
            db.Insert(doc);
            return true;
        }

        /// <summary>
        /// Adds a user to the database
        /// </summary>
        /// <param name="doc">
        /// The Patient object to be created.
        /// Must have a unique id, a name and a DoB.
        /// </param>
        /// <returns>
        /// True if the Patient was created successully.
        /// False if the Patient was not created.
        /// </returns>
        public static bool createPatient(Patient patient)
		{
			if (patient.name == null) return false;
			if (patient.DoB == null) return false;
			var users = db.Table<Patient>();
			foreach (Patient x in users)
			{
				if (x.id == patient.id)
				{
					return false;
				}
			}
			db.Insert(patient);
			return true;
		}

		/// <summary>
		/// Adds a relationship between a doctor and a patient to the database
		/// </summary>
		/// <param name="doc">
		/// The Doctor-Patient object to be created.
		/// Must have a unique id, a patient_id and a doctor username.
		/// </param>
		/// <returns>
		/// True if the Doctor-Patient was created successully.
		/// False if the Doctor-Patient was not created.
		/// </returns>
		public static bool createDoctorPatient(DoctorPatient docpat)
		{
			if (docpat.patient_id < 0) return false;
			if (docpat.doctor == null) return false;
			var users = db.Table<DoctorPatient>();
			foreach (DoctorPatient x in users)
			{
				if (x.patient_id == docpat.patient_id && x.doctor == docpat.doctor)
				{
					return false;
				}
			}
			db.Insert(docpat);
			return true;
		}

		/// <summary>
		/// Adds the disease.
		/// </summary>
		/// <returns>The disease.</returns>
		/// <param name="d">Disease</param>
		public static bool addDisease(Disease d)
		{
			if (d.affectedArea == null) return false;
			if (d.name == null) return false;
			var diseases = db.Table<Disease>();
			foreach (Disease x in diseases)
			{
				if (x.affectedArea == d.affectedArea && x.name == d.name)
				{
					return false;
				}
			}
			db.Insert(d);
			return true;
		}

		/// <summary>
		/// Adds the antibiotic.
		/// </summary>
		/// <returns>The antibiotic.</returns>
		/// <param name="antibiotic">Antibiotic.</param>
		public static bool addAntibiotic(Antibiotic antibiotic)
		{
			var table = db.Table<Antibiotic>();
			foreach (var element in table)
			{
				if (element.name == antibiotic.name)
				{
					return false;
				}
			}
			db.Insert(antibiotic);
			return true;
		}

        /// <summary>
        /// Authenticates a username and password.
        /// i.e checks if a user exists in the batabase with the given username and password.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>
        /// Doctor object if the username and password were authenticated
        /// Null if the username and password were not authenticated
        /// </returns>
        public static Doctor authenticate(string username, string password)
        {
            var users = db.Table<Doctor>();
            foreach (var doc in users)
            {
                if (doc.username == username && doc.password == password)
                {
                    return doc;
                }
            }
            return null;
        }

		/// <summary>
		/// Gets the patient list.
		/// </summary>
		/// <returns>The patient list.</returns>
		/// <param name="name">Name.</param>
		public static List<Patient> getPatientList(string name)
		{
			var patient = db.Table<Patient>();
			var doctorPatient = db.Table<DoctorPatient>();
			var list = new List<Patient>();

			foreach (var pat in patient)
			{
				foreach (var docpat in doctorPatient)
				{
					if (pat.id == docpat.patient_id && docpat.doctor == name)
					{
						list.Add(pat);
						break;
					}
				}
			}
			return list;
		}

		public static List<Disease> getDisease(string affectedArea)
		{
			var diseases = db.Table<Disease>();
			var list = new List<Disease>();

			foreach (var x in diseases)
			{
				if (x.affectedArea == affectedArea)
				{
					list.Add(x);
				}
			}
			return list;
		}

        /// <summary>
        /// Gets the antibiotic.
        /// </summary>
        /// <returns>The antibiotic.</returns>
        /// <param name="name">Name.</param>
        public static Antibiotic getAntibiotic(String name)
        {
            Antibiotic antibiotic = null;
            var antibiotics = db.Table<Antibiotic>();
            foreach (var ab in antibiotics)
            {
                if(String.Compare(ab.name,name,true) == 0)
                {
                    antibiotic = ab;
                    break;
                }
            }
            return antibiotic;
        }

        public static bool addRule(Rule r) {
            db.Insert(r);
            return true;
        }

        public static List<Rule> getRules(string illness) {
            List<Rule> rules = new List<Rule>();
            var table = db.Table<Rule>();
            foreach(var rule in table) {
                if (String.Compare(rule.illness, illness, true) == 0) rules.Add(rule);
            }
            return rules;
        }
    }
}

