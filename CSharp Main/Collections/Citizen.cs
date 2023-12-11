namespace Collections
{
    public abstract class Citizen
    {
        public string Passport { get; protected set; } = "";
        public string FullName
        {
            get { return string.Format("{0} {1}", FirstName, LastName); }
        }
        public string FirstName { get; protected set; } = "";
        public string LastName { get; protected set; } = "";
        protected int age = 0;
        public abstract int Age { get; set; }
        public char Gender { get; protected set; } = 'N';
        public Citizen(string passport, string firstname, string lastname, int age, char gender)
        {
            Passport = passport.Replace(" ", string.Empty).ToLower();
            FirstName = firstname;
            LastName = lastname;
            Gender = gender;
            Age = age;
        }
        #region Определение операторов равно и не равно
        public static bool operator ==(Citizen A, Citizen B)
        {
            return A.Passport == B.Passport;
        }
        public static bool operator !=(Citizen A, Citizen B)
        {
            return A == B;
        }
        #endregion
    }
    class Pensioner : Citizen
    {
        public override int Age
        {
            get => age;
            set
            {
                if (Gender == 'M' && value >= 60 && value < 120) age = value;
                if (Gender == 'W' && value >= 55 && value < 120) age = value;
                age = 0;
            }
        }
        public Pensioner(string passport, string firstname, string lastname, int age, char gender) 
            : base(passport, firstname, lastname, age, gender) { }
    }
    class Student : Citizen
    {
        public override int Age
        {
            get => age;
            set
            {
                if (value >= 16 && value < 120) age = value;
                age = 0;
            }
        }
        public Student(string passport, string firstname, string lastname, int age, char gender)
            : base(passport, firstname, lastname, age, gender) { }
    }
    class Worker : Citizen
    {
        public override int Age
        {
            get => age;
            set
            {
                if (value >= 18 && value < 120) age = value;
                age = 0;
            }
        }
        public Worker(string passport, string firstname, string lastname, int age, char gender)
            : base(passport, firstname, lastname, age, gender) { }
    }
}

