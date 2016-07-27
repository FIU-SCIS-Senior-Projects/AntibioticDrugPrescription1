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
			Controller.addPatient("Sergio", "Medina","Illness acquired from == community  & severely ill == false & PCN allergy == no","August 5");
			Controller.addPatient("Karla", "Perez", "Illness acquired from == community & severely ill  == false & PCN allergy == severe", "February 10");
			Controller.addPatient("Richard", "Krox", "Illness acquired from == hospital & PCN allergy == no", "January 2");
			Controller.addPatient("Evelyn", "Gonzales", "Illness acquired from == hospital & PCN allergy == non severe", "December 23");
			Controller.addPatient("Guillermo", "Lojo", "Illness acquired from == hospital & PCN allergy == severe", "October 12");
			Controller.addPatient("Eduardo", "Gutierrez", "Illness severity == severe & PCN allergy == severe", "September 1");

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
			Controller.addDisease("Biliary Tract Infection","Abdominal Infection");
			Controller.addDisease("Diverticulitis","Abdominal Infection");
			Controller.addDisease("Pancreatitis","Abdominal Infection");
			Controller.addDisease("Peritonitis","Abdominal Infection");
			//Controller.addDisease("AB1", "Pulmonary Infection");
			//Controller.addDisease("AB2", "Pulmonary Infection");
			//Controller.addDisease("AB3", "Pulmonary Infection");

			//ANTIBIOTICS
            //Columns -> Name | Price | Aceptance Use | Toxicity
            //------------------------------------------------------------
            Controller.addAntibiotic("Ceftriaxone", "Biliary Tract Infection", 5, "Unknown");     //update info
            Controller.addAntibiotic("Ciprofloxacin", "Biliary Tract Infection",5, "Unknown");   //update info
            Controller.addAntibiotic("Piperacilin", "Biliary Tract Infection", 5, "Unknown");     //update info
            Controller.addAntibiotic("Cefepime", "Biliary Tract Infection", 5, "Unknown");        //update info
            Controller.addAntibiotic("Aztreonam", "Biliary Tract Infection", 5, "Unknown");       //update info

			//RULES
 			Controller.addRule("Biliary Tract Infection", "Illness acquired from == community  & severely ill == false & PCN allergy == no", "Ceftriaxone");
			Controller.addRule("Biliary Tract Infection", "Illness acquired from == community & severely ill  == false & PCN allergy == severe", "Ciprofloxacin");
			Controller.addRule("Biliary Tract Infection", "Illness acquired from == hospital & PCN allergy == no", "Piperacilin");
			Controller.addRule("Biliary Tract Infection", "Illness acquired from == hospital & PCN allergy == non severe", "Cefepime");
			Controller.addRule("Biliary Tract Infection", "Illness acquired from == hospital & PCN allergy == severe", "Aztreonam");
			Controller.addRule("Biliary Tract Infection", "Illness severity == severe & PCN allergy == no", "Piperacilin");
			Controller.addRule("Biliary Tract Infection", "Illness severity == severe & PCN allergy == non severe", "Cefepime");
			Controller.addRule("Biliary Tract Infection", "Illness severity == severe & PCN allergy == severe", "Aztreonam");
			Controller.addRule("Biliary Tract Infection", "mtbm == true & PCN allergy == no", "Piperacilin");
			Controller.addRule("Biliary Tract Infection", "mtbm == true & PCN allergy == non severe", "Cefepime");
			Controller.addRule("Biliary Tract Infection", "mtbm == true & PCN allergy == severe", "Aztreonam");

            Controller.addRule("Diverticulitis", "infection severity == moderate & PCN allergy == no", "Amoxacillin");
            Controller.addRule("Diverticulitis", "infection severity == moderate & PCN allergy == severe", "Ciprofloxacin");
            Controller.addRule("Diverticulitis", "infection severity == severe & PCN allergy == no", "Piperavillin");
            Controller.addRule("Diverticulitis", "infection severity == severe & PCN allergy = non severe", "Cefepime");
            Controller.addRule("Diverticulitis", "infection severity == severe & PCN allergy = severe", "Ciprofloxacin");

            Controller.addRule("Pancreatitis", "abdominal sepsis == true & PCN allergy == no", "Piperacilin");
            Controller.addRule("Pancreatitis", "abdominal sepsis == true & PCN allergy == non severe", "Cefepime");
            Controller.addRule("Pancreatitis", "abdominal sepsis == true & PCN allergy == severe", "Ciprofloxacin");

            Controller.addRule("Peritonitis", "peritonitis type == primary & PCN allergy == no", "Cefriaxone");
            Controller.addRule("Peritonitis", "peritonitis type == primary & PCN allergy == severe", "Monifloxacin");
            Controller.addRule("Peritonitis", "Peritonitis type == spontaneous * PCN allergy == no", "Cefriaxone");
            Controller.addRule("Peritonitis", "Peritonitis type == spontaneous * PCN allergy == severe", "Monifloxacin");

            //acquired == community
            //acquired == hospital
            //severely ill == true
            //severely ill == false
            //PCN allergy == no
            //PCN allergy == severe
            //PCN allergy == non severe

            //temp hardcoded patient data
            //Session.patientData = new System.Collections.Generic.Dictionary<string, string>();
            //Session.patientData.Add("acquired", "community");
            //Session.patientData.Add("severely ill", "false");
            //Session.patientData.Add("PCN allergy", "severe");
        }
	}
}

