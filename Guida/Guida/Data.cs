using System;
namespace Guida
{
	public static class Data
	{
		//Insert information in the Database.
		public static void InsertData()
		{ 
			//DOCTOR: 
			//Columns -> Username | Password | Name (Optional)
			//------------------------------------------------
			appSettings.GetController().addUser("Alan", "12345");
			appSettings.GetController().addUser("Sean", "12345");
			appSettings.GetController().addUser("Mohsen", "12345");
			appSettings.GetController().addUser("Sadjadi", "12345");
			appSettings.GetController().addUser("Giri", "12345");
			appSettings.GetController().addUser("Trevor", "12345");

			//PATIENTS
			//Columns -> ID (AutoIncrement) | Name | Date of Birth
			//----------------------------------------------------
			appSettings.GetController().addPatient("Sergio", "Jul");
			appSettings.GetController().addPatient("Karla", "Aug");
			appSettings.GetController().addPatient("Richard", "Jan");
			appSettings.GetController().addPatient("Evelyn", "Dec");
			appSettings.GetController().addPatient("Guillermo", "Oct");
			appSettings.GetController().addPatient("Eduardo", "Sep");

			//DOCTOR-PATIENT
			//Columns -> ID (AutoIncrement) | Patient id | Doctor Username
			//------------------------------------------------------------
			appSettings.GetController().addDoctorPatient(1, "Alan");
			appSettings.GetController().addDoctorPatient(2, "Alan");
			appSettings.GetController().addDoctorPatient(3, "Alan");
			appSettings.GetController().addDoctorPatient(4, "Sean");
			appSettings.GetController().addDoctorPatient(5, "Giri");
			appSettings.GetController().addDoctorPatient(6, "Trevor");

			//VISIT
			//appSettings.controller.addVisits(1, "01-05-16", "Sergio", "Thyru");
			//appSettings.controller.addVisits(2, "02-05-16", "Karla", "Alan");
			//appSettings.controller.addVisits(3, "03-05-16", "Richard", "Sean");
			//appSettings.controller.addVisits(4, "04-05-16", "Everlyn", "Giri");
			//appSettings.controller.addVisits(1, "02-05-16", "Sergio", "Trevor");

			//DESEASE

			//ANTIBIOTICS
			//Columns -> Name | Price | Aceptance Use | Toxicity
			//------------------------------------------------------------
			appSettings.GetController().addAntibiotic("Ab1", "Flu", 5, "100mg");
			appSettings.GetController().addAntibiotic("Pulmoderpoxifan", "Derp", 5, "100mg");
		}
	}
}

