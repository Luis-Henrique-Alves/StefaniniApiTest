namespace Example.Domain.CityAggregate.CityExceptions
{
    public class CityExceptionsMessages
    {
        public const string CityAlreadyExists = "Cidade já cadastrada!";
        public const string NameIsRequired = "O nome da cidade é obrigatório, não podendo ser vazio.Favor preencha o campo e tente novamente.";
        public const string StateIsInvalid = "Estado não se parece no padrão de estados Brasileiros, valor validar e tente novamente. ";
        public const string RequestIsEmpty = " Corpo de requisição está vazia, favor verificar corpo de requisição e tente novamente.";
    }
}
