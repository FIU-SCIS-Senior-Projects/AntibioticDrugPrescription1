using System;
using NUnit.Framework;
using Guida;
using System.Collections.Generic;

namespace UnitTests
{
	[TestFixture]
	public class Story667
	{
		Database db;
		[SetUp]
		public void Setup()
		{
			db = new Database();
		}

		[TearDown]
		public void Tear()
		{
			db.db.DeleteAll<Patient>();
			db = null;
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
			patient.DoB = "July";

			//assert
			Assert.True(db.createPatient(patient) == true);
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
			patient.DoB = "July";
			db.createPatient(patient);

			//assert
			Assert.True(db.createPatient(patient) == false);
		}

		/*
		/// <summary>
		/// A list of Patients that exists in the database can be retrieved
		/// Preconditions:  A Patient exists in the database 
		///                 displayPatient() is called
		/// Postconditions: a list of Patients name is returned
		/// </summary>
		[Test]
		public void TC003()
		{
			//preconditions
			Doctor doctor = new Doctor();
			doctor.username = "Alan";
			doctor.password = "12345";
			db.createUser(doctor);

			Patient patient = new Patient();
			patient.name = "Sergio";
			patient.DoB = "Jul";
			db.createPatient(patient);

			DoctorPatient doctorPatient = new DoctorPatient();
			doctorPatient.patient_id = 1;
			doctorPatient.doctor = "Alan";
			db.createDoctorPatient(doctorPatient);

			//Execute
			var list = db.getPatientList("Alan");

			//assert
			Assert.True(list.Count > 0);
		}*/

		/// <summary>
		/// A list of Patients that does not exists in the database can not be retrieved
		/// Preconditions:  A list of petients does not exists in the database 
		///                 displayPatients() is called
		/// Postconditions: empty list is returned
		/// </summary>
		[Test]
		public void TC004()
		{
			//execute
			var ab = db.getPatientList("Test");

			//assert
			Assert.True(ab.Count == 0);
		}
	}
}

