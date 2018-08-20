using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using YouLearn.Domain.Arguments.Base;
using YouLearn.Domain.Arguments.Canal;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Domain.Interfaces.Services;

namespace YouLearn.Domain.Services
{
    public class ServiceCanal : Notifiable, IServiceCanal
    {
        private readonly IRepositoryUsuario _repositoryUsuario;
        private readonly IRepositoryCanal _repositoryCanal;
        private readonly IRepositoryVideo _repositoryVideo;

        public ServiceCanal(IRepositoryUsuario repositoryUsuario, IRepositoryCanal repositoryCanal, IRepositoryVideo repositoryVideo)
        {
            _repositoryUsuario = repositoryUsuario;
            _repositoryCanal = repositoryCanal;
            _repositoryVideo = repositoryVideo;
        }

        public CanalResponse AdicionarCanal(AdicionarCanalRequest request, Guid idUsuario)
        {
            Usuario usuario = _repositoryUsuario.Obter(idUsuario);

            Canal canal = new Canal(request.Nome, request.UrlLogo, usuario);

            AddNotifications(canal);

            if (this.IsInvalid()) return null;

            canal = _repositoryCanal.Adicionar(canal);

            return (CanalResponse)canal;

        }

        public Response ExcluirCanal(Guid idCanal)
        {
            bool existe = _repositoryVideo.ExisteCanalAssociado(idCanal);

            if (existe)
            {
                AddNotification("Canal", "NAO_E_POSSIVEL_EXCLUIR_UM_canal ");
                return null;
            }

            Canal canal = _repositoryCanal.Obter(idCanal);

            if (canal == null)
            {
                AddNotification("Canal", "DADOS_NAO_ENCONTRADOS");
            }

            if (IsInvalid()) return null;

            _repositoryCanal.Excluir(canal);

            return new Response() { Message = "OPERACAO_REALIZADA_COM_SUCESSO" };
        }

        public IEnumerable<CanalResponse> Listar(Guid idUsuario)
        {
            IEnumerable<Canal> canalCollection = _repositoryCanal.Listar(idUsuario);

            var response = canalCollection.ToList().Select(entidade => (CanalResponse)entidade);

            return response;
        }
    }
}
