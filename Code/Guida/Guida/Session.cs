using System;
using System.Collections.Generic;
using System.Text;

namespace Guida
{
	//Session class store data required data to use it in another page
    public static class Session
    {
        public static Doctor user { get; set; }
        public static Patient selectedPatient { get; set; }
        public static Dictionary<string, string> patientData { get; set; }
		public static Disease selectedArea { get; set; }
		public static Antibiotic antibioticInformation { get; set; }
    }
}
