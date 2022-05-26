namespace Example.Domain.PersonAggregate.PersonExceptionsMessages
{
    public class PersonExceptionMessages
    {
        public const string PersonAlreadyExists = "Pessoa já cadastrada!";
        public const string IdCityIsInvalid = "Cidade inválida, favor verificar se os campos foram preenchidos corretamente.";
        public const string NameIsRequired = "O nome de pessoa é obrigatório, não podendo ser vazio.Favor preencha o campo e tente novamente.";
        public const string CPFIsInvalid = "CPF inválido, favor cadastrar apenas documentos válidos. ";
        public const string RequestIsEmpty = " Corpo de requisição está vazia, favor verificar corpo de requisição e tente novamente.";
        public const string AgeIsInvalid = "Idade com valor ou formato inválido. Favor verificar";
    }
}
