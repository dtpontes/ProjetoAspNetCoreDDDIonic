using System;
using System.Collections.Generic;
using System.Linq;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using YouLearn.Domain.Arguments.Base;
using YouLearn.Domain.Arguments.PlayList;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Domain.Interfaces.Services;

namespace YouLearn.Domain.Services
{
    public class ServicePlayList : Notifiable, IServicePlaylist
    {
        private readonly IRepositoryUsuario _repositoryUsuario;
        private readonly IRepositoryPlaylist _repositoryPlayList;
        private readonly IRepositoryVideo _repositoryVideo;

        public ServicePlayList(IRepositoryUsuario repositoryUsuario, IRepositoryPlaylist repositoryPlayList, IRepositoryVideo repositoryVideo)
        {
            _repositoryUsuario = repositoryUsuario;
            _repositoryPlayList = repositoryPlayList;
            _repositoryVideo = repositoryVideo;
        }

        public PlayListResponse AdicionarPlayList(AdicionarPlayListRequest request, Guid idUsuario)
        {
            Usuario usuario = _repositoryUsuario.Obter(idUsuario);

            PlayList playList = new PlayList(request.Nome, usuario);

            AddNotifications(playList);

            if (this.IsInvalid()) return null;

            playList = _repositoryPlayList.Adicionar(playList);

            return (PlayListResponse)playList;
        }

        public Response ExcluirPlayList(Guid idPlayList)
        {
            bool existe = _repositoryVideo.ExistePlayListAssociada(idPlayList);

            if (existe)
            {
                AddNotification("PlayList", "MSG.NAO_E_POSSIVEL_EXCLUIR_UMA_Playlist");
                return null;
            }

            PlayList playList = _repositoryPlayList.Obter(idPlayList);

            if (playList == null)
            {
                AddNotification("PlayList", "DADOS_NAO_ENCONTRADOS");
            }

            if (this.IsInvalid()) return null;

            _repositoryPlayList.Excluir(playList);

            return new Response() { Message = "OPERACAO_REALIZADA_COM_SUCESSO" };
        }

        public IEnumerable<PlayListResponse> Listar(Guid idUsuario)
        {
            IEnumerable<PlayList> playListCollection = _repositoryPlayList.Listar(idUsuario);

            var response = playListCollection.ToList().Select(entidade => (PlayListResponse)entidade);

            return response;
        }
    }
}
