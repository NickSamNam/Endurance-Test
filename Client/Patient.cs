using System;

namespace Client
{
    public struct Patient
    {
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
        ///   Gets the gender of the patient.
        /// </summary>
        public bool IsMale { get; }

        /// <summary>
        ///   Gets the age of the patient at the current point in time.
        /// </summary>
        public int Age => (DateTime.Now - Birthdate).Days % 365;

        /// <summary>
        ///   Initializes a new instance of the <see cref="Patient" /> class.
        /// </summary>
        /// <param name="firstName">The patient's first name.</param>
        /// <param name="lastName">The patient's last name.</param>
        /// <param name="birthdate">The patient's birthdate.</param>
        /// <param name="isMale">The patient's gender.</param>
        public Patient(string firstName, string lastName, DateTime birthdate, bool isMale)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthdate = birthdate;
            IsMale = isMale;
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