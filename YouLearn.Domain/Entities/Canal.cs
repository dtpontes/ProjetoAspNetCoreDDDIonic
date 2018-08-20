using prmToolkit.NotificationPattern;
using System;
using YouLearn.Domain.Entities.Base;

namespace YouLearn.Domain.Entities
{
    public class Canal : EntityBase
    {

        protected Canal()
        {


        }
        public Canal(string nome, string urlLogo, Usuario usuario)
        {
            Nome = nome;
            UrlLogo = urlLogo;
            Usuario = usuario;

            new AddNotifications<Canal>(this)
                .IfNullOrInvalidLength(x => x.Nome, 2, 50, "Nome inválido")
                .IfNullOrInvalidLength(x => x.UrlLogo, 4, 255, "Logo inválida");

            AddNotifications(Usuario);
        }

        public string Nome { get; private set; }

        public string UrlLogo { get; private set; }

        public Usuario Usuario { get; private set; }
    }
}
