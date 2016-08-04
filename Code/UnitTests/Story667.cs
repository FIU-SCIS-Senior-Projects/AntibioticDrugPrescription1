using System;
using NUnit.Framework;
using Guida;
using System.Collections.Generic;

namespace UnitTests
{
	[TestFixture]
	public class Story667
	{
		[SetUp]
		public void Setup()
		{
            Database.connect();
		}

		[TearDown]
		public void Tear()
		{
			Database.db.DeleteAll<Doctor>();
			Database.db.DeleteAll<Patient>();
			Database.db.DeleteAll<DoctorPatient>();
		}

		/// <summary>
		/// Patient can be added to the database
		/// Preconditions:  A patient object is created with name "Sergio" and DoB "July"
		///                 createPatient() is called
		/// Postconditions: True
		/// </summary>
		[Test]
		public void TC001()
		{
			//preconditions
			Patient patient = new Patient();
			patient.name = "Sergio";
			patient.DoB = "Jul";

			bool created = Database.createPatient(patient);

			//assert
			Assert.True(created == true);
		}

		/// <summary>
		/// null Patients can not be added to the database
		/// Preconditions:  A Patient object is created with a null name          
		///                 createPatient() is called
		/// Postconditions: False
		/// </summary>
		[Test]
		public void TC002()
		{
			//preconditions
			Patient patient = new Patient();
			patient.name = null;
			patient.DoB = "Jul";

			//execute
			bool created = Database.createPatient(patient);

			//assert
			Assert.True(created == false);
		}

		/// <summary>
		/// DoctorPatient can be added to the database
		/// Preconditions:  A DoctorPatient object is created with patient_id 1 and doctor "Alan"
		///                 createDoctorPatient() is called
		/// Postconditions: True
		/// </summary>
		[Test]
		public void TC003()
		{
			//preconditions
			DoctorPatient doctorPatient = new DoctorPatient();
			doctorPatient.patient_id = 1;
			doctorPatient.doctor = "Alan";

			//execute
			bool created = Database.createDoctorPatient(doctorPatient);	

			//assert
			Assert.True(created == true);
		}

		/// <summary>
		/// duplicate DoctorPatient can not be added to the database
		/// Preconditions:  A DoctorPatient object is not created with patient_id and doctor already created in the database
		///                 createDoctorPatient() is called with 2 identical objects
		/// Postconditions: False
		/// </summary>
		[Test]
		public void TC004()
		{
			//preconditions
			DoctorPatient doctorPatient1 = new DoctorPatient();
			doctorPatient1.patient_id = 1;
			doctorPatient1.doctor = "Alan";
			DoctorPatient doctorPatient2 = new DoctorPatient();
			doctorPatient2.patient_id = 1;
			doctorPatient2.doctor = "Alan";

			//execute
			bool created1 = Database.createDoctorPatient(doctorPatient1);
			bool created2 = Database.createDoctorPatient(doctorPatient2);

			//assert
			Assert.True(created1 == true && created2 == false);
		}

		/// <summary>
		/// A list of Patients that does not exists in the database can not be retrieved
		/// Preconditions:  A list of petients does not exists in the database 
		///                 displayPatients() is called
		/// Postconditions: empty list is returned
		/// </summary>
		[Test]
		public void TC005()
		{
			//execute
			var ab = Database.getPatientList("Test");

			//assert
			Assert.True(ab.Count == 0);
		}

		/// <summary>
		/// A list of Patients that exists in the database can be retrieved
		/// Preconditions:  A Patient exists in the database 
		///                 displayPatient() is called
		/// Postconditions: a list of Patients name is returned
		/// </summary>
		[Test]
		public void TC006()
		{
			//preconditions
			Doctor doctor = new Doctor();
			doctor.username = "Alan";
			doctor.password = "12345";
			Database.createUser(doctor);

			Patient patient = new Patient();
			patient.name = "Sergio";
			patient.DoB = "Jul";
			Database.createPatient(patient);

			DoctorPatient doctorPatient = new DoctorPatient();
			doctorPatient.patient_id = patient.id;
			doctorPatient.doctor = "Alan";
			Database.createDoctorPatient(doctorPatient);

			//Execute
			var list = Database.getPatientList("Alan");

			//assert
			Assert.True(list.Count > 0);
		}
	}
}

