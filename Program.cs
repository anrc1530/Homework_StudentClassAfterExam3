using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkStudentClassLatest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> studentList = new List<Student> {
                new Student("Dino", "Praso", "dopo@auvih.edu.ba", "Sarajevo"),
                new Student("Stefan", "Vujovic", "snvc@aubih.edu.ba", "Other"),
                new Student("Amina", "Bajrektarevic", "aabc@aubih.edu.ba", "Sarajevo"),
                new Student("Kemal", "Secic", "klsc@aubih.edu.ba", "Tuzla"),
                new Student("Semir", "Masic", "srmc@aubih.edu.ba", "Other"),
                new Student("Adnan", "Rahic", "anrc@aubih.edu.ba", "Tuzla"),
            };

            studentList.Sort();
            studentList.ForEach(student => Console.WriteLine(student.getStudentInfo()));

            Console.WriteLine("Press Enter to Exit...");
            Console.ReadLine();
        }
    }

    class Person
    {
        protected string name, lastName;

        protected Person(string name, string lastName)
        {
            this.name = name;
            this.lastName = lastName;
        }

        protected string getPersonInfo()
        {
            return name + ", " + lastName;
        }
    }

    class Student : Person, IComparable<Student>
    {
        public string email { get; set; }
        private string Location;
        private string location
        {
            get
            {
                if (Location == "SA")
                {
                    return "Sarajevo";
                }
                else if (Location == "TZ")
                {
                    return "Tuzla";
                }
                else
                {
                    return "Other";
                }
            }
            set
            {
                if (value == "SA" || value == "SARAJEVO" || value == "Sarajevo")
                {
                    Location = "Sarajevo";
                }
                else if (value == "TZ" || value == "TUZLA" || value == "Tuzla")
                {
                    Location = "Tuzla";
                }
                else
                {
                    Location = "NA";
                }
            }
        }


        public Student(string name, string lastname, string email, string location)
            : base(name, lastname)
        {
            this.email = email;
            this.Location = location;
        }


        ~Student()
        {

        }

        

        public bool setName(string input)
        {
            if (input.Length <= 2)
            {
                Console.WriteLine("Name must be at least two characters long");
                return false;
            }

            char[] cArray = input.ToCharArray();
            foreach (char c in cArray)
            {
                if (!char.IsLetter(c))
                {
                    Console.WriteLine("Name can only have letters");
                    return false;
                }
            }

            if (char.IsUpper(cArray[0]))
            {
                Console.WriteLine("Name must start with an uppercase letter");
                return false;
            }

            return true;
        }

        public string getStudentInfo()
        {
            return base.getPersonInfo() + ", " + this.email + ", " + this.Location;
        }

        public override string ToString()
        {
            return getStudentInfo();
        }

        public int CompareTo(Student student)
        {
            return Location.CompareTo(student.Location);
        }
    }
}
