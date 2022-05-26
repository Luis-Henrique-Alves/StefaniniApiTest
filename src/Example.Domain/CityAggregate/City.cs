using Example.Domain.PersonAggregate;

namespace Example.Domain.CityAggregate
{
    public class City
    {
        private City(string name, string state)
        {
            this.Name = name;
            this.State = state;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string State { get; set; }
        public virtual ICollection<Person> People { get; set; }

        public static City Create(string name, string state)
        {
            ValidateCityRequest(name, state);

            return new City(name, state);
        }

        public void Update(string name, string state)
        {
            ValidateCityRequest(name, state);

            Name = name;
            State = state;
        }

        private static void ValidateCityRequest(string name, string state)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }

            if (state.Length != 2)
            {
                throw new ArgumentException();
            }
        }
    }
}
