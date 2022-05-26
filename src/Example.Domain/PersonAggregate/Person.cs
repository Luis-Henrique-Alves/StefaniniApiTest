using Example.Domain.CityAggregate;
using Example.Domain.PersonAggregate.PersonExceptionsMessages;

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
            ValidatePersonRequest(name, documentNumber, age, idCity);
            return new Person(name,documentNumber,age,idCity);
        }


        public void Update(string name, string documentNumber, int age, int idCity)
        {
            ValidatePersonRequest(name, documentNumber, age, idCity);
            Name = name;
            DocumentNumber = documentNumber;
            Age = age;
        }

        private static void ValidatePersonRequest(string name, string documentNumber, int age, int idCity)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(PersonExceptionMessages.NameIsRequired);
            }

            if (!IsCpf(documentNumber))
            {
                throw new ArgumentException(PersonExceptionMessages.CPFIsInvalid);
            }

            if(age <=0 && age > 120)
            {
                throw new ArgumentException(PersonExceptionMessages.AgeIsInvalid);
            }

            if(idCity <= 0)
            {
                throw new ArgumentException(PersonExceptionMessages.IdCityIsInvalid);
            }
        }
    
        private static bool IsCpf(string cpf)
            {
                int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                string tempCpf;
                string digito;
                int soma;
                int resto;
                cpf = cpf.Trim();
                cpf = cpf.Replace(".", "").Replace("-", "");
                if (cpf.Length != 11)
                    return false;
                tempCpf = cpf.Substring(0, 9);
                soma = 0;

                for (int i = 0; i < 9; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
                resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                digito = resto.ToString();
                tempCpf = tempCpf + digito;
                soma = 0;
                for (int i = 0; i < 10; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
                resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                digito = digito + resto.ToString();
                return cpf.EndsWith(digito);
            }
        }
}
