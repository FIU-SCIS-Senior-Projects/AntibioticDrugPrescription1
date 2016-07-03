using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Guida
{
    class RuleEngine
    {
        Controller controller;
        List<int> trueRules = new List<int>();
        Dictionary<string, int> missingKnowledge = new Dictionary<string, int>();

        public RuleEngine() {
            controller = appSettings.getController();
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
            List<Rule> rules = controller.getRules(illness);
            foreach(Rule rule in rules) {
                if (evaluateCondition(rule.condition,Session.patientData)) return controller.getAntibiotic(rule.antibiotic);
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
            foreach (String c in condition.Split(delim)) {
                foreach (Match exp in Regex.Matches(c, boolPattern)) {
                    string variable = exp.Groups[1].Value;
                    string op = exp.Groups[2].Value;
                    string value = exp.Groups[3].Value;
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
                            default: return false;
                        }
                    }
                    else {
                        missingKnowledge.Add(variable, 1);      //needs to be modified to hold the relative weight of the missing knowdlege
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
