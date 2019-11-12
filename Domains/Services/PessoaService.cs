using netcore.example.webapi.basic.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace netcore.example.webapi.basic.Domains.Services
{
    public class PessoaService: IPessoaService
    {
        private readonly List<Pessoa> pessoas;
        private static readonly string MSG_INVALID = 
			"É necessário informar um identificador, nome e sobrenome para o registro da pessoa.";
        public PessoaService()
        {
            pessoas = new List<Pessoa>();
        }
        private Pessoa GetPessoa(Guid? id)
        {
            if (id == null)
            {
                return null;
            } else
            {
                List<Pessoa> pessoasById =
                    pessoas.Where(p => (p.Id != null) && (p.Id.Equals(id))).ToList();
                if (pessoasById.Count > 0)
                {
                    return pessoasById[0];
                } else
                {
                    return null;
                }
            }
        }
        public Pessoa Post(Pessoa pessoa)
        {
            if (!pessoa.isValid())
            {
                throw new Exception(MSG_INVALID);
            }
            else if (GetPessoa(pessoa.Id) != null)
            {
                throw new Exception("O identificador informado já está sendo utilizado por outra pessoa.");
            }
            else
            {
                pessoas.Add(pessoa);
                return pessoa;
            }
        }
        public IReadOnlyList<Pessoa> Get()
        {
            return pessoas.AsReadOnly();
        }
        public void Delete(Guid? id)
        {
            Pessoa pessoaOld = GetPessoa(id);
            if (pessoaOld == null)
            {
                throw new Exception("Registro de pessoa não encontrado.");
            }
            else
            {
                pessoas.Remove(pessoaOld);
            }
        }
        public void Put(Pessoa pessoa)
        {
            Delete(pessoa.Id);
            pessoas.Add(pessoa);
        }
    }
}
