using Example.Domain.PersonAggregate;

namespace Example.Domain.CityAggregate
{
    public class City
    {
        private City(string name, string district)
        {
            this.Name = name;
            this.District = district;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string District { get; set; }
        public virtual ICollection<Person> People { get; set; }

        public static City Create(string name, string district)
        {
            //if (name == null)
            //    throw new ArgumentException("Invalid " + nameof(name));

            //if (age == 0)
            //    throw new ArgumentException("Invalid " + nameof(age));


            return new City(name, district);
        }


        public void Update(string name, string district)
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
