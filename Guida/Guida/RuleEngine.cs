using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Guida
{
    class RuleEngine
    {
        public Dictionary<string, int> missingKnowledge;
        
        public RuleEngine() {
            missingKnowledge = new Dictionary<string, int>();
        }

        /// <summary>
        /// Determines the proper antibiotic for a given illness
        /// </summary>
        /// <param name="illness"></param>
        /// <returns>
        /// Antibiotic if rule matches
        /// Null if no antibiotic was found
        /// </returns>
        public Antibiotic determineAntibiotic(String illness) {
            List<Rule> rules = Controller.getRules(illness);
            foreach(Rule rule in rules) {
                if (evaluateCondition(rule.condition,Session.patientData)) return Controller.getAntibiotic(rule.antibiotic);
            }
            return null;
        }

        /// <summary>
        /// Evaluates the truth of a given conditional sting based on a knowledge Dictionary
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="knowledge"></param>
        /// <returns></returns>
        public bool evaluateCondition(String condition,Dictionary<string,string> knowledge) {
            char[] delim = { '&' };
            String boolPattern = @"\s*(\w+\s*\w+)\s+([<>=]+)\s+(\w+\s*\w+)";
            bool truth = true;
            List<string> missing = new List<string>();

            foreach (String c in condition.Split(delim)) {
                foreach (Match exp in Regex.Matches(c, boolPattern)) {
                    string variable = exp.Groups[1].Value;
                    string op = exp.Groups[2].Value;
                    string value = exp.Groups[3].Value;
                    if (knowledge.ContainsKey(variable)) {
                        String data = knowledge[variable];
                        switch (op) {
                            case ">":
                                if (!(Double.Parse(data) > Double.Parse(value))) truth = false;
                                break;
                            case ">=":
                                if (!(Double.Parse(data) >= Double.Parse(value))) truth = false;
                                break;
                            case "<":
                                if (!(Double.Parse(data) < Double.Parse(value))) truth = false;
                                break;
                            case "<=":
                                if (!(Double.Parse(data) <= Double.Parse(value))) truth = false;
                                break;
                            case "==":
                                if (!(String.Compare(data, value, true) == 0)) truth = false;
                                break;
                            default:
                                truth = false;
                                break;
                        }
                    }
                    else {
                        missing.Add(variable);
                        truth = false;
                    }
                }
            }

            if(missing.Count > 0) {
                foreach(string m in missing) {
                    missingKnowledge.Add(m, missing.Count);
                }
            }

            return truth;
        }

        
        public string getMissing() {
            string least = null;
            foreach(KeyValuePair<string,int> m in missingKnowledge) {
                if (least == null) least = m.Key;
                if (m.Value < missingKnowledge[least]) least = m.Key;
            }
            return least;
        }
        

    }
}
