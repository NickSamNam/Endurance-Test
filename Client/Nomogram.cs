namespace Client
{
    public static class Nomogram
    {
        /// <summary>
        /// The first constant in the VO2Max formula for males.
        /// </summary>
        private const double Am = .00212;

        /// <summary>
        /// The first constant in the VO2Max formula for females.
        /// </summary>
        private const double Af = .00193;

        /// <summary>
        /// The second constant in the VO2Max formula for males.
        /// </summary>
        private const double Bm = .299;

        /// <summary>
        /// The second constant in the VO2Max formula for females.
        /// </summary>
        private const double Bf = .326;

        /// <summary>
        /// The third constant in the VO2Max formula.
        /// </summary>
        private const double C = .769;

        /// <summary>
        /// The fourth constant in the VO2Max formula for males.
        /// </summary>
        private const double Dm = 48.5;

        /// <summary>
        /// The fourth constant in the VO2Max formula for females.
        /// </summary>
        private const double Df = 56.1;

        /// <summary>
        /// The fith constant in the VO2Max formula.
        /// </summary>
        private const int E = 100;

        /// <summary>
        /// The conversion rate from watts to kg-m/min.
        /// </summary>
        private const double WattInKgmMin = 6.12;

        /// <summary>
        /// Age factors starting with age 35, ending with age 65, incrementing by 5 years of age.
        /// </summary>
        private static readonly double[] AgeFactor = {.87, .83, .78, .75, .71, .68, .65};

        /// <summary>
        ///   Calculate the absolute maximum oxygen consumption.
        /// </summary>
        /// <param name="patient">The patient whose VO2Max to calculate.</param>
        /// <param name="power">The power at which the patient cycled during the test in watts.</param>
        /// <param name="avgHR">The patient's average heart rate in beats per minute.</param>
        /// <returns>Returns the patient's VO2Max.</returns>
        public static double CalcVO2MaxAbsolute(Patient patient, int power, int avgHR)
        {
            double calc;
            if (patient.IsMale)
            {
                calc = (Am * (power * WattInKgmMin) + Bm) / (C * avgHR - Dm) * E;
            }
            else
            {
                calc = (Af * (power * WattInKgmMin) + Bf) / (C * avgHR - Df) * E;
            }
            switch (patient.Age)
            {
                case int n when n < 35:
                    break;
                case int n when n >= 35 && n < 40:
                    calc *= AgeFactor[0];
                    break;
                case int n when n >= 40 && n < 45:
                    calc *= AgeFactor[1];
                    break;
                case int n when n >= 45 && n < 50:
                    calc *= AgeFactor[2];
                    break;
                case int n when n >= 50 && n < 55:
                    calc *= AgeFactor[3];
                    break;
                case int n when n >= 55 && n < 60:
                    calc *= AgeFactor[4];
                    break;
                case int n when n >= 60 && n < 65:
                    calc *= AgeFactor[5];
                    break;
                case int n when n >= 65:
                    calc *= AgeFactor[6];
                    break;
            }
            return calc;
        }

        /// <summary>
        /// Calculate the maximum oxygen consumption relative to the patient's body mass.
        /// </summary>
        /// <param name="patient">The patient whose VO2Max to calculate.</param>
        /// <param name="power">The power at which the patient cycled during the test in watts.</param>
        /// <param name="avgHR">The patient's average heart rate in beats per minute.</param>
        /// <returns></returns>
        public static double CalcVO2MaxRelative(Patient patient, int power, int avgHR) =>
            CalcVO2MaxRelative(patient, CalcVO2MaxAbsolute(patient, power, avgHR));

        public static double CalcVO2MaxRelative(Patient patient, double VO2MaxAbsolute) =>
            VO2MaxAbsolute *= 1000 / patient.Mass;
    }
}