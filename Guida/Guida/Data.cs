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
			Controller.addUser("Alan", "12345");
			Controller.addUser("Sean", "12345");
			Controller.addUser("Mohsen", "12345");
			Controller.addUser("Sadjadi", "12345");
			Controller.addUser("Giri", "12345");
			Controller.addUser("Trevor", "12345");

			//PATIENTS
			//Columns -> ID (AutoIncrement) | Name | Date of Birth
			//----------------------------------------------------
			Controller.addPatient("Sergio", "Jul");
			Controller.addPatient("Karla", "Aug");
			Controller.addPatient("Richard", "Jan");
			Controller.addPatient("Evelyn", "Dec");
			Controller.addPatient("Guillermo", "Oct");
			Controller.addPatient("Eduardo", "Sep");

			//DOCTOR-PATIENT
			//Columns -> ID (AutoIncrement) | Patient id | Doctor Username
			//------------------------------------------------------------
			Controller.addDoctorPatient(2, "Alan");
			Controller.addDoctorPatient(1, "Alan");
			Controller.addDoctorPatient(3, "Alan");
			Controller.addDoctorPatient(4, "Sean");
			Controller.addDoctorPatient(5, "Giri");
			Controller.addDoctorPatient(6, "Trevor");

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
			Controller.addAntibiotic("Ab1", "Flu", 5, "100mg");
			Controller.addAntibiotic("Pulmoderpoxifan", "Derp", 5, "100mg");
		}
	}
}

