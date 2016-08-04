using System;
using NUnit.Framework;
using Guida;
using System.Collections.Generic;

namespace UnitTests {

    [TestFixture]
    class RuleEngineTest {
        
        RuleEngine ie;

        [SetUp]
        public void Setup() {
            Database.connect();
            ie = new RuleEngine();
        }

        [TearDown]
        public void Tear() {
            ie = null;
        }

        /// <summary>
        /// Testing condition evaluation
        /// Test example with no real application
        /// </summary>
        [Test]
        public void TC001() {
            Dictionary<string, string> knowledge = new Dictionary<string, string>();
            knowledge.Add("weight", "500");
            knowledge.Add("alan", "true");
            string condition = "weight > 100 & alan == true";
            Assert.True(ie.evaluateCondition(condition, knowledge));
        }

        /// <summary>
        /// Test condition evalutation
        /// Real test example for biliary tract infection
        /// </summary>
        [Test]
        public void TC002() {
            Dictionary<string, string> knowledge = new Dictionary<string, string>();
            knowledge.Add("Community Aquired", "true");
            knowledge.Add("severely ill", "false");
            knowledge.Add("PCN allergy", "no");
            string condition = "Community Aquired == true & severely ill == false & PCN allergy == no";
            Assert.True(ie.evaluateCondition(condition, knowledge));
        }

        /// <summary>
        /// Test condition evalutation
        /// Real test example for biliary tract infection
        /// </summary>
        [Test]
        public void TC003() {
            Dictionary<string, string> knowledge = new Dictionary<string, string>();
            knowledge.Add("Community Aquired", "true");
            knowledge.Add("severely ill", "false");
            knowledge.Add("PCN allergy", "no");
            string condition = "Community Aquired == false & severely ill == false & PCN allergy == no";
            Assert.False(ie.evaluateCondition(condition, knowledge));
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void TC004() {
            //add antibiotic
            Controller.addAntibiotic("BTIAB", "BTI", 150, "350mg");
            //add rule
            Controller.addRule("Biliary tract infection",
                "Community Aquired == true & severely ill == false & PCN allergy == no", "BTIAB");
            
            //Set up patient data
            Dictionary<string, string> knowledge = new Dictionary<string, string>();
            knowledge.Add("Community Aquired", "true");
            knowledge.Add("severely ill", "false");
            knowledge.Add("PCN allergy", "no");
            Session.patientData = knowledge;

            String found = ie.determineAntibiotic("Biliary tract infection");
            Assert.True(found == "BTIAB");
        }

        [Test]
        public void TC005() {
            String found = ie.determineAntibiotic("Biliary Tract Infection");
            Console.WriteLine(found);
            Assert.True(found == "Ciprofloxacin");
        }
    }
}