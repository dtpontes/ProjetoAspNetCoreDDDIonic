using prmToolkit.NotificationPattern;
using System;
using YouLearn.Domain.Entities.Base;
using YouLearn.Domain.Enums;

namespace YouLearn.Domain.Entities
{
    public class Video : EntityBase
    {
        protected Video()
        {

        }

        public Video(Canal canal, PlayList playList, string titulo, string descricao, string tags, int? ordemNaPlaylist, string idVideoYoutube, Usuario usuario)
        {
            Canal = canal;
            PlayList = playList;
            Titulo = titulo;
            Descricao = descricao;
            Tags = tags;
            OrdemNaPlaylist = ordemNaPlaylist.HasValue ? ordemNaPlaylist.Value : 0;
            IdVideoYoutube = idVideoYoutube;
            Usuario = usuario;
            Status = EnumStatus.EmAnalise;

            new AddNotifications<Video>(this)
                .IfNullOrInvalidLength(x => x.Titulo, 1, 200, "Título obrigatório");

            AddNotifications(canal);

            if(playList != null)
            {
                AddNotifications(playList);
            }

        }

        public Canal Canal { get; private set; }

        public PlayList PlayList { get; private set; }

        public string  Titulo { get; private set; }

        public string Descricao { get; private set; }

        public string Tags { get; private set; }

        public int OrdemNaPlaylist { get; private set; }

        public string IdVideoYoutube { get; private set; }

        public Usuario Usuario { get; private set; }

        public EnumStatus Status { get; private set; }


    }
}
