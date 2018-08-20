using System;
using System.Collections.Generic;
using System.Text;
using YouLearn.Domain.Entities;

namespace YouLearn.Domain.Interfaces.Repositories
{
    public interface IRepositoryUsuario
    {
        Usuario Obter(string email, string senha);

        Usuario Obter(Guid id);

        void Salvar(Usuario usuario);

        bool Existe(string Email);



    }
}
