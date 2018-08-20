using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouLearn.Domain.Arguments.Base;
using YouLearn.Domain.Arguments.Canal;
using YouLearn.Domain.Arguments.Usuario;
using YouLearn.Domain.Arguments.Video;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Domain.ValueObjects;

namespace YouLearn.Domain.Services
{
    public class ServiceVideo : Notifiable, IServiceVideo
    {
        private readonly IRepositoryVideo _repositoryVideo;
        private readonly IRepositoryUsuario _repositoryUsuario;
        private readonly IRepositoryCanal _repositoryCanal;
        private readonly IRepositoryPlaylist _repositoryPlaylist;

        public ServiceVideo(IRepositoryVideo repositoryVideo, IRepositoryUsuario repositoryUsuario, IRepositoryCanal repositoryCanal, IRepositoryPlaylist repositoryPlayList)
        {
            _repositoryVideo = repositoryVideo;
            _repositoryUsuario = repositoryUsuario;
            _repositoryCanal = repositoryCanal;
            _repositoryPlaylist = repositoryPlayList;
        }

        public AdicionarVideoResponse AdicionarVideo(AdicionarVideoRequest request, Guid idUsuario)
        {
            if(request == null)
            {
                AddNotification("RegistrarVideoRequest", "Objeto usuário obrigatório ");
                return null;
            }

            Usuario usuario = _repositoryUsuario.Obter(idUsuario);
            if(usuario == null)
            {
                AddNotification("Usuário", "Usuário não localizado");
                return null;
            }

            Canal canal = _repositoryCanal.Obter(request.IdCanal);
            if (canal == null)
            {
                AddNotification("Canal", "Canal não localizado");
                return null;
            }

            PlayList playList = null;
            if(request.IdPlaylist != Guid.Empty)
            {
                playList = _repositoryPlaylist.Obter(request.IdPlaylist);
                if (playList == null)
                {
                    AddNotification("PlayList", "PlayList não localizado");
                    return null;
                }
            }

            var video = new Video(canal, playList, request.Titulo, request.Descricao, request.Tags, request.OrdemNaPlaylist, request.IdVideoYoutube, usuario);

            AddNotifications(video);

            if(this.IsInvalid())
            {
                return null;
            }

            _repositoryVideo.Adicionar(video);

            return new AdicionarVideoResponse() { Id = video.Id};
        }

        public IEnumerable<VideoResponse> Listar(string tags)
        {
            var videoCollection =  _repositoryVideo.Listar(tags);

            var response = videoCollection.Select(x => (VideoResponse)x);

            return response;
        }

        public IEnumerable<VideoResponse> Listar(Guid idPlayList)
        {
            var videoCollection = _repositoryVideo.Listar(idPlayList);

            var response = videoCollection.Select(x => (VideoResponse)x);

            return response;
        }

        
    }
}
