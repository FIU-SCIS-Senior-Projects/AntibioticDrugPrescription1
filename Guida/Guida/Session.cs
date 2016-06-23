using System;
using System.Collections.Generic;
using System.Text;

namespace Guida
{
    public static class Session
    {
        public static Doctor user { get; set; }
        public static Patient selectedPatient { get; set; }
		public static Antibiotic antibioticInformation { get; set; }
    }
}
