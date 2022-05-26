using Example.Domain.CityAggregate;

namespace Example.Domain.PersonAggregate
{
    public class Person
    {
        private Person(string name, string documentNumber, int age, int idCity)
        {
            this.Name = name;
            this.DocumentNumber = documentNumber;
            this.Age = age;
            this.IdCity = idCity;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string DocumentNumber { get; set; }
        public int Age { get; set; }
        public int IdCity {get; set; }
        public virtual City City { get; set; }

        public static Person Create(string name, string documentNumber, int age, int idCity)
        {
            //if (name == null)
            //    throw new ArgumentException("Invalid " + nameof(name));

            //if (age == 0)
            //    throw new ArgumentException("Invalid " + nameof(age));


            return new Person(name,documentNumber,age,idCity);
        }


        public void Update(string name, string documentNumber, int age, int idCity)
        {
            //if (name != null)
            //    Name = name;

            //if (age > 50)
            //    throw new InvalidAgeExceptions();

            //if (age != 0)
            //    Age = age;
        }


    }
}
