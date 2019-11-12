using netcore.example.webapi.basic.Domains.Models;
using System;
using System.Collections.Generic;

namespace netcore.example.webapi.basic.Domains.Services
{
    public interface IPessoaService
    {
        Pessoa Post(Pessoa pessoa);
        IReadOnlyList<Pessoa> Get();
        void Delete(Guid? id);
        void Put(Pessoa pessoa);
    }
}
