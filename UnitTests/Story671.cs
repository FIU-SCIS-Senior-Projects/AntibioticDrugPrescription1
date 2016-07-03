using System;
using NUnit.Framework;
using Guida;

namespace UnitTests
{
    [TestFixture]
    public class Story671
    {
        [SetUp]
        public void Setup()
        {
            Database.connect();
        }

        [TearDown]
        public void Tear()
        {
            Database.db.DeleteAll<Antibiotic>();
        }

        /// <summary>
        /// Antibiotics can be added to the database
        /// Preconditions:  An antibiotic with name "TestAB" does not exist in the database
        ///                 An antibiotic object is created
        ///                 addAntibiotic() is called
        /// Postconditions: True
        /// </summary>
        [Test]
        public void TC001()
        {
            //preconditions
            Antibiotic antibiotic = new Antibiotic();
            antibiotic.name = "TestAB";
            antibiotic.price = 350;
            antibiotic.acceptableUses = "Flu,Cold";
            antibiotic.toxicity = "150mg";
           
            //assert
            Assert.True(Database.addAntibiotic(antibiotic));
        }

        /// <summary>
        /// Duplicate antibiotics can not be added to the database
        /// Preconditions:  An antibiotic with name "TestAB" does exist in the database
        ///                 An antibiotic object is created with the name "TestAB"
        ///                 addAntibiotic() is called
        /// Postconditions: False
        /// </summary>
        [Test]
        public void TC002()
        {
            //preconditions
            Antibiotic antibiotic = new Antibiotic();
            antibiotic.name = "TestAB";
            antibiotic.price = 350;
            antibiotic.acceptableUses = "Flu,Cold";
            antibiotic.toxicity = "150mg";
            Database.addAntibiotic(antibiotic);

            //assert
            Assert.False(Database.addAntibiotic(antibiotic));
        }

        /// <summary>
        /// An antibiotic that exists in the database can be retrieved
        /// Preconditions:  A Antibiotic exists in the database 
        ///                 getAntibiotic() is called
        /// Postconditions: Antibiotic is returned
        /// </summary>
        [Test]
        public void TC003()
        {
            //preconditions
            Antibiotic antibiotic = new Antibiotic();
            antibiotic.name = "Test";
            antibiotic.price = 350;
            antibiotic.acceptableUses = "Flu,Cold";
            antibiotic.toxicity = "150mg";
            Database.addAntibiotic(antibiotic);

            //execute
            var ab = Database.getAntibiotic("Test");

            //assert
            Assert.True(ab.name == antibiotic.name && ab.price == antibiotic.price && ab.acceptableUses == antibiotic.acceptableUses && ab.toxicity == antibiotic.toxicity);
        }

        /// <summary>
        /// An antibiotic that does not exists in the database can not be retrieved
        /// Preconditions:  A Antibiotic does not exists in the database 
        ///                 getAntibiotic() is called
        /// Postconditions: null is returned
        /// </summary>
        [Test]
        public void TC004()
        {
            //execute
            var ab = Database.getAntibiotic("Test");

            //assert
            Assert.True(ab == null);
        }

        /// <summary>
        /// An antibiotic that exists in the database can be retrieved regardless of case
        /// Preconditions: An antibiotic exists in the database
        ///                 getAntibiotic() is called
        /// Postconditions: antibitoic is returned
        /// </summary>
        [Test]
        public void TC005() {
            //execute
            //preconditions
            Antibiotic antibiotic = new Antibiotic();
            antibiotic.name = "Test";
            antibiotic.price = 350;
            antibiotic.acceptableUses = "Flu,Cold";
            antibiotic.toxicity = "150mg";
            Database.addAntibiotic(antibiotic);

            //execute
            var ab = Database.getAntibiotic("test");

            //assert
            Assert.True(ab.name == antibiotic.name && ab.price == antibiotic.price && ab.acceptableUses == antibiotic.acceptableUses && ab.toxicity == antibiotic.toxicity);
        }
    }
}