using System;
using SQLite;
using System.IO;

namespace Guida
{
    [Table("Doctors")]
    public class Doctor
    {
      [PrimaryKey,Column("username")]
      public String username { get; set; }
      [Column("password")]
      public String password { get; set; }
      [Column("name")]
      public String name { get; set; }
    }

	public class Authentication
	{
        SQLiteConnection db;
        public Authentication()
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
            if(db.Table<Doctor>().Count() == 0)
            {
                Doctor doc = new Doctor();
                doc.username = "Sean";
                doc.password = "12345";
                db.Insert(doc);
            }
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
                }
            }
            return auth;
        }
	}
}

