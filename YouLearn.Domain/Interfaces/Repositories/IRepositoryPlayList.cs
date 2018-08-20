using System;
using System.Collections.Generic;
using System.Text;
using YouLearn.Domain.Entities;

namespace YouLearn.Domain.Interfaces.Repositories
{
    public interface IRepositoryPlaylist
    {

        IEnumerable<PlayList> Listar(Guid idUsuario);

        PlayList Obter(Guid idPlaylist);

        PlayList Adicionar(PlayList playlist);

        void Excluir(PlayList playlist);

        
    }
}
