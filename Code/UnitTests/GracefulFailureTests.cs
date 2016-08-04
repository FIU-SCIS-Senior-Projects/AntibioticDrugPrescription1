using System;
using NUnit.Framework;
using Guida;
using System.Collections.Generic;

namespace UnitTests {

    [TestFixture]
    class GracefulFailureTests {

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

        
        [Test]
        public void TC001() {
            Dictionary<string, string> knowledge = new Dictionary<string, string>();
            string condition = "weight > 100 & sper == 5";
            ie.evaluateCondition(condition, knowledge);
            Assert.AreEqual("weight", ie.getMissing(), "missing value should be weight");
        }
        

        [Test]
        public void TC002() {
            Dictionary<string, string> knowledge = new Dictionary<string, string>();
            knowledge.Add("weight", "50");
            string condition = "sper > 100 & weight == 5";
            ie.evaluateCondition(condition, knowledge);
            Assert.AreEqual("sper", ie.getMissing(), "missing value should be sper");
        }

        [Test]
        public void TC003() {
            Dictionary<string, string> knowledge = new Dictionary<string, string>();
            knowledge.Add("sper", "50");
            string condition = "sper > 100 & weight == 5";
            ie.evaluateCondition(condition, knowledge);
            Assert.AreEqual("weight", ie.getMissing(), "missing value should be sper");
        }

        [Test]
        public void TC004() {
            Dictionary<string, string> knowledge = new Dictionary<string, string>();
            knowledge.Add("weight", "50");
            Assert.AreEqual(false, knowledge.ContainsKey("sper"), "missing value should be sper");
        }

    }
}