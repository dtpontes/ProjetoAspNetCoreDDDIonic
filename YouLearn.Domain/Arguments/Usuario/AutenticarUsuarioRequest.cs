using System;
using System.Collections.Generic;
using System.Text;

namespace YouLearn.Domain.Arguments.Usuario
{
    public class AutenticarUsuarioRequest
    {
        public AutenticarUsuarioRequest(string email, string senha)
        {            
            Email = email;
            Senha = senha;
        }       

        public string Email { get; set; }

        public string Senha { get; set; }
    }
}
