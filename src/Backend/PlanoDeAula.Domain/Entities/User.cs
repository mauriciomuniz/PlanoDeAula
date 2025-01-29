namespace PlanoDeAula.Domain.Entities
{
    public class User : Basis
    {   
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty ;
        public string Password { get; set; } = string.Empty;

    }
}
