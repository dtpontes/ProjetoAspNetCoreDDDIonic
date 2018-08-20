using System;
using System.Collections.Generic;
using System.Text;

namespace YouLearn.Domain.Arguments.Video
{
    public  class AdicionarVideoRequest
    {
        public Guid IdCanal { get; set; }

        public Guid IdPlaylist { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public string Tags { get; set; }

        public int? OrdemNaPlaylist { get; set; }

        public string IdVideoYoutube { get; set; }
    }
}
