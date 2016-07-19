using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Guida
{
    class RuleEngine {
        char[] delim = { '&' };
        String boolPattern = @"\s*(\w+(\s*\w+)*)\s+([<>=]+)\s*(\w+(\s*\w+)*)";
        public Dictionary<Rule, List<string>> missingKnowledge;

        public RuleEngine() {
            missingKnowledge = new Dictionary<Rule, List<string>>();
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
            foreach (Rule rule in rules) {
                if (evaluateCondition(rule.condition, Session.patientData)) return Controller.getAntibiotic(rule.antibiotic);
                else {
                    List<string> missing = determineMissing(rule.condition, Session.patientData);
                    missingKnowledge.Add(rule,missing);
                }
            }
            return null;
        }

        /// <summary>
        /// Evaluates the truth of a given conditional sting based on a knowledge Dictionary
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="knowledge"></param>
        /// <returns></returns>
        public bool evaluateCondition(String condition, Dictionary<string, string> knowledge) {
            foreach (String c in condition.Split(delim)) {
                Match exp = Regex.Match(c, boolPattern);
                string variable = exp.Groups[1].Value;
                string op = exp.Groups[3].Value;
                string value = exp.Groups[4].Value;
                if (knowledge.ContainsKey(variable)) {
                    String data = knowledge[variable];
                    switch (op) {
                        case ">":
                            if (!(Double.Parse(data) > Double.Parse(value))) return false;
                            break;
                        case ">=":
                            if (!(Double.Parse(data) >= Double.Parse(value))) return false;
                            break;
                        case "<":
                            if (!(Double.Parse(data) < Double.Parse(value))) return false;
                            break;
                        case "<=":
                            if (!(Double.Parse(data) <= Double.Parse(value))) return false;
                            break;
                        case "==":
                            if (!(String.Compare(data, value, true) == 0)) return false;
                            break;
                        default:
                            return false;
                    }
                }
                else return false;
            }
            return true;
        }


        public List<string> determineMissing(string condition, Dictionary<string, string> knowledge) {
            List<string> missing = new List<string>();
            foreach (String c in condition.Split(delim)) {
                Match exp = Regex.Match(c, boolPattern);
                string variable = exp.Groups[1].Value;
                if (!knowledge.ContainsKey(variable)) {
                    missing.Add(variable);
                }
            }
            return missing;
        }

        public string getMissing() {
            KeyValuePair<Rule, List<string>> best = new KeyValuePair<Rule, List<string>>(null,new List<string>());
            foreach(KeyValuePair<Rule,List<string>> m in missingKnowledge) {
                if (best.Key == null) best = m;
                if(m.Value.Count < best.Value.Count) {
                    best = m;
                }
            }
            string ret = null;
            foreach(string s in best.Value) {
                if (ret == null) ret = s;
                else ret = ret + " and " + s ;
            }
            return ret;
        }

        
    }
}
