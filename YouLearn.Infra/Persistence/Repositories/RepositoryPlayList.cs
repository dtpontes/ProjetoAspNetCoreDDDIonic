﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Infra.Persistence.EF;

namespace YouLearn.Infra.Persistence.Repositories
{

    public class RepositoryPlayList : IRepositoryPlaylist
    {
        private readonly YouLearnContext _context;

        public RepositoryPlayList(YouLearnContext context)
        {
            _context = context;
        }

        public PlayList Adicionar(PlayList playList)
        {
            _context.PlayLists.Add(playList);

            return playList;
        }

        public void Excluir(PlayList playList)
        {
            //bool existe = _repositoryVideo.ExistePlayListAssociada(id)
        }

        public IEnumerable<PlayList> Listar(Guid idUsuario)
        {
            return _context.PlayLists.Where(x => x.Usuario.Id == idUsuario).ToList();
        }

        public PlayList Obter(Guid idPlayList)
        {
            return _context.PlayLists.FirstOrDefault(x => x.Id == idPlayList);
        }
    }
}
