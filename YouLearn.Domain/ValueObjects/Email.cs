using prmToolkit.NotificationPattern;

namespace YouLearn.Domain.ValueObjects
{
    public class Email :Notifiable
    {
        public Email(string endereco)
        {
            Endereco = endereco;
            new AddNotifications<Email>(this).IfNotEmail(x => x.Endereco, "Formato de email inválido");

        }

        public string Endereco { get; private set; }


    }
}
