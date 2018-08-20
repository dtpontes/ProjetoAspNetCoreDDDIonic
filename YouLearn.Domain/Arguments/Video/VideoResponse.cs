using System;
using System.Collections.Generic;
using System.Text;
using YouLearn.Domain.Entities;

namespace YouLearn.Domain.Arguments.Video
{
    public  class VideoResponse
    {
        public string NomeCanal { get; set; }

        public string Descricao { get; set; }

        public Guid? IdPlaylist { get; set; }

        public string NomePlayList { get; set; }

        public string Titulo { get; set; }

        public string ThumbNail { get; set; }

        public string IdVideoYouTube { get; set; }

        public int? OrdemNaPlaylist { get; set; }

        public string Url { get; set; }

        public static explicit operator VideoResponse(Entities.Video entidade)
        {
            return new VideoResponse()
            {
                Descricao = entidade.Descricao,
                Url = string.Concat("https://www.youtube.com/embed/", entidade.IdVideoYoutube),
                NomeCanal = entidade.Canal.Nome,
                IdVideoYouTube = entidade.IdVideoYoutube,
                ThumbNail = string.Concat("https://img.youtube.com/vi/", entidade.IdVideoYoutube, "/mqdefault.jpg"),
                Titulo = entidade.Titulo,
                IdPlaylist = entidade.PlayList?.Id,
                NomePlayList = entidade.PlayList?.Nome,
                OrdemNaPlaylist = entidade.OrdemNaPlaylist


            };
        }
    }
}
