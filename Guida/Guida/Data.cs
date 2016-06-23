using System;
namespace Guida
{
	public static class Data
	{
		//Data Class. Insert information in the Database.
		public static void insertData()
		{ 
			//DOCTOR: 
			//Columns -> Username | Password | Name (Optional)
			//------------------------------------------------
			appSettings.getController().addUser("Alan", "12345");
			appSettings.getController().addUser("Sean", "12345");
			appSettings.getController().addUser("Mohsen", "12345");
			appSettings.getController().addUser("Sadjadi", "12345");
			appSettings.getController().addUser("Giri", "12345");
			appSettings.getController().addUser("Trevor", "12345");

			//PATIENTS
			//Columns -> ID (AutoIncrement) | Name | Date of Birth
			//----------------------------------------------------
			appSettings.getController().addPatient("Sergio", "Jul");
			appSettings.getController().addPatient("Karla", "Aug");
			appSettings.getController().addPatient("Richard", "Jan");
			appSettings.getController().addPatient("Evelyn", "Dec");
			appSettings.getController().addPatient("Guillermo", "Oct");
			appSettings.getController().addPatient("Eduardo", "Sep");

			//DOCTOR-PATIENT
			//Columns -> ID (AutoIncrement) | Patient id | Doctor Username
			//------------------------------------------------------------
			appSettings.getController().addDoctorPatient(2, "Alan");
			appSettings.getController().addDoctorPatient(1, "Alan");
			appSettings.getController().addDoctorPatient(3, "Alan");
			appSettings.getController().addDoctorPatient(4, "Sean");
			appSettings.getController().addDoctorPatient(5, "Giri");
			appSettings.getController().addDoctorPatient(6, "Trevor");

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
			appSettings.getController().addAntibiotic("Ab1", "Flu", 5, "100mg");
			appSettings.getController().addAntibiotic("Pulmoderpoxifan", "Derp", 5, "100mg");
		}
	}
}

