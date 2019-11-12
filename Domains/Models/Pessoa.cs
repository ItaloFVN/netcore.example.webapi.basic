using System;

namespace netcore.example.webapi.basic.Domains.Models
{
    public class Pessoa
    {
        public Pessoa()
        {
            Id = Guid.NewGuid();
        }
        public bool isValid()
        {
            return (Id != null) && (!Id.ToString().Equals(string.Empty))
                && (Nome != null) && (!String.IsNullOrEmpty(Nome))
                && (Sobrenome != null) && (!String.IsNullOrEmpty(Sobrenome));
        }
        public Guid? Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
    }
}
