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
    /// Patient has an id, name and a DoB(Date of Birth)
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
    /// Visit has a date, patient, and doctor
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
    /// Disease has a name, and an affectedArea.
    /// </summary>
    [Table("disease")]
    public class Disease
    {
        [PrimaryKey, Column("name")]
        public String name { get; set; }
        [Column("affectedArea")]
        public String affectedArea { get; set; }
    }

    /// <summary>
    /// Represents the database table "antibiotics"
    /// Antibiotic has a name, a price, acceptable uses, and a toxicity.
    /// </summary>
    [Table("antibiotics")]
    public class Antibiotic
    {
        [PrimaryKey, Column("name")]
        public string name { get; set; }
        [Column("price")]
        public int price { get; set; }
        [Column("acceptableUses")]
        public String acceptableUses { get; set; }
        [Column("toxicity")]
        public String toxicity { get; set; }
    }

    /// <summary>
    /// This class represents a connection to the local database.
    /// </summary>
    class Database
    {
        public SQLiteConnection db;

        /// <summary>
        /// Creates a connection to the DB. DB location is based on operating system. 
        /// Creates all tables if they don't already exist.
        /// </summary>
        public Database()
        {
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
        public bool createUser(Doctor doc)
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

		public bool createPatient(Patient doc)
		{
			if (doc.name == null) return false;
			if (doc.DoB == null) return false;
			var users = db.Table<Patient>();
			foreach (Patient x in users)
			{
				if (x.id == doc.id)
				{
					return false;
				}
			}
			db.Insert(doc);
			return true;
		}

		public bool createDoctorPatient(DoctorPatient doc)
		{
			if (doc.patient_id < 0) return false;
			if (doc.doctor == null) return false;
			var users = db.Table<DoctorPatient>();
			foreach (DoctorPatient x in users)
			{
				if (x.patient_id == doc.patient_id && x.doctor == doc.doctor)
				{
					return false;
				}
			}
			db.Insert(doc);
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
        public Doctor authenticate(string username, string password)
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

		public List<string> DisplayPatients(string username)
		{
			var patients = db.Table<Patient>();
			var doctorpatient = db.Table<DoctorPatient>();
			List<string> list = new List<string>();

			foreach (var pat in patients)
			{
				foreach (var docpat in doctorpatient)
				{
					if (pat.id == docpat.patient_id && docpat.doctor == username)
					{
						list.Add(pat.name);
						break;
					}

				}
			}
			return list;
		}

		public List<string> DisplayPatientsID(string username)
		{
			var patients = db.Table<Patient>();
			var doctorpatient = db.Table<DoctorPatient>();
			List<string> list = new List<string>();

			foreach (var pat in patients)
			{
				foreach (var docpat in doctorpatient)
				{
					if (pat.id == docpat.patient_id && docpat.doctor == username)
					{
						list.Add(pat.id.ToString());
						break;
					}

				}
			}
			return list;
		}

		public bool patientExist(int id)
		{
			var patients = db.Table<Patient>();
			foreach (var pat in patients)
			{
				if (pat.id == id)
				{
					Session.selectedPatient = pat;
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public bool addAntibiotic(Antibiotic antibiotic)
        {
            var table = db.Table<Antibiotic>();
            foreach (var element in table)
            {
                if(element.name == antibiotic.name)
                {
                    return false;
                }
            }
            db.Insert(antibiotic);
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Antibiotic getAntibiotic(String name)
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
    }
}

