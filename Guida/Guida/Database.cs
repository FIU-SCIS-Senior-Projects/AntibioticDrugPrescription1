using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.IO;

namespace Guida
{
    [Table("Doctors")]
    public class Doctor
    {
        [PrimaryKey, Column("username")]
        public String username { get; set; }
        [Column("password")]
        public String password { get; set; }
        [Column("name")]
        public String name { get; set; }
        [Column("patients")]
        public Patient[] patients { get; set; }
    }

    [Table("Patients")]
    public class Patient
    {
        [PrimaryKey, Column("name")]
        public String name { get; set; }
        [PrimaryKey, Column("DoB")]
        public String DoB { get; set; }
        [Column("doctors")]
        public Doctor[] doctors { get; set; }
    }

    [Table("Visits")]
    public class Visit
    {
        [PrimaryKey, Column("date")]
        public String date { get; set; }
        [PrimaryKey, Column("patient")]
        public Patient patient { get; set; }
        [Column("doctor")]
        public Doctor doctor { get; set; }
    }

    [Table("disease")]
    public class Disease
    {
        [PrimaryKey, Column("name")]
        public String name { get; set; }
        [Column("affectedArea")]
        public String affectedArea { get; set; }
    }

    [Table("antibiotic")]
    public class Antibiotic
    {
        [PrimaryKey, Column("name")]
        public string name { get; set; }
        [Column("price")]
        public double price { get; set; }
        [Column("acceptableUses")]
        public String[] acceptableUses { get; set}
        [Column("toxicity")]
        public String toxicity { get; set; }
        [Column("interactions")]
        public Antibiotic[] interactions { get; set; }
    }

    class Database
    {
        public SQLiteConnection db;
        public Database() {
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
            db.CreateTable<Visit>();
            db.CreateTable<Antibiotic>();
            db.CreateTable<Disease>();
            if (db.Table<Doctor>().Count() == 0)
            {
                Doctor doc = new Doctor();
                doc.username = "Sean";
                doc.password = "12345";
                db.Insert(doc);
            }
        }

        public void insert<T>(ref T obj)
        { 
            db.Insert(obj);
        }
    }
}

