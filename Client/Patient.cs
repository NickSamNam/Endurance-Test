using System;
using System.Collections.Generic;
using System.Linq;

namespace Client
{
    public struct Patient
    {
        private static readonly Dictionary<int, int> MaxHeartRates = new Dictionary<int, int>
        {
            {15, 210},
            {25, 200},
            {35, 190},
            {40, 180},
            {45, 170},
            {50, 160},
            {55, 150}
        };

        /// <summary>
        ///   Gets the first name of the patient.
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        ///   Gets the last name of the patient.
        /// </summary>
        public string LastName { get; }

        /// <summary>
        ///   Gets the birthdate of the patient.
        /// </summary>
        public DateTime Birthdate { get; }

        /// <summary>
        ///   Gets the Weight in KG of the patient.
        /// </summary>
        public int Weight { get; }

        /// <summary>
        ///   Gets the gender of the patient.
        /// </summary>
        public bool IsMale { get; }

        /// <summary>
        /// Gets the body mass of the patient.
        /// </summary>
        public double Mass { get; }

        /// <summary>
        ///   Gets the age of the patient at the current point in time.
        /// </summary>
        public int Age => (int) ((DateTime.Now - Birthdate).Days / 365.25);

        /// <summary>
        /// Gets the maximum allowed heartrate of the patient in relation to its age.
        /// </summary>
        public int MaxHeartRate
        {
            get
            {
                var roundAge = (int) Math.Round(Age / 5.0) * 5;
                if (roundAge < MaxHeartRates.Keys.Min())
                {
                    return MaxHeartRates[MaxHeartRates.Keys.Min()];
                }
                else if (roundAge > MaxHeartRates.Keys.Max())
                {
                    return MaxHeartRates[MaxHeartRates.Keys.Max()];
                }
                return MaxHeartRates[roundAge];
            }
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="Patient" /> class.
        /// </summary>
        /// <param name="firstName">The patient's first name.</param>
        /// <param name="lastName">The patient's last name.</param>
        /// <param name="birthdate">The patient's birthdate.</param>
        /// <param name="isMale">The patient's gender.</param>
        /// <param name="mass">The patient's body mass.</param>
        public Patient(string firstName, string lastName, DateTime birthdate, bool isMale, double mass)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthdate = birthdate;
            Weight = weight;
            IsMale = isMale;
            Mass = mass;
        }

        public bool Equals(Patient other)
        {
            return string.Equals(FirstName, other.FirstName) && string.Equals(LastName, other.LastName) &&
                   Birthdate.Equals(other.Birthdate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Patient patient && Equals(patient);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = FirstName.GetHashCode();
                hashCode = (hashCode * 397) ^ LastName.GetHashCode();
                hashCode = (hashCode * 397) ^ Birthdate.GetHashCode();
                return hashCode;
            }
        }
    }
}