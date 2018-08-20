using System;
using YouLearn.Domain.Entities.Base;
using YouLearn.Domain.ValueObjects;
using prmToolkit.NotificationPattern;
using YouLearn.Domain.Extensions;

namespace YouLearn.Domain.Entities
{
    public class Usuario : EntityBase
    {

        protected Usuario()
        {

        }
        
        public Usuario(Email email, string senha)
        {
            Email = email;
            Senha = senha.ConvertToMD5();                        
            AddNotifications(email);

        }

        public Usuario(Nome nome, Email email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha.ConvertToMD5();

            AddNotifications(nome, email);

            new AddNotifications<Usuario>(this).IfNullOrInvalidLength(x => x.Senha, 3, 32, "Senha nula ou com quantidade de caratcteres inválidos");
        }

        public Nome Nome { get; private  set; }

        public Email Email { get; private set; }

        public string Senha { get; private set; }
    }
}
