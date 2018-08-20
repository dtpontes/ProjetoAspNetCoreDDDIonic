using Microsoft.AspNetCore.Mvc;

namespace YouLearn.Api.Controllers
{
    public class UtilController
    {
        [HttpGet]
        [Route("")]
        public object Versao()
        {
            return new { Desenvolvedor = "Daniel", VersaoApi = "0.0.1" };
        }

        [HttpGet]
        [Route(@"Listar/Usuario")]
        public object VersaoUsuario()
        {
            return new { Desenvolvedor = "Daniel", VersaoApi = "0.0.1", Usuario = "Usuario teste" };
        }

        [HttpPost]
        [Route("")]
        public string Post()
        {
            return "Inseriu uma nova informação";
        }

        [HttpPut]
        [Route("")]
        public string Put()
        {
            return "Atualizou uma nova informação";
        }

        [HttpDelete]
        [Route("")]
        public string Delete()
        {
            return "Excluiu uma nova informação";
        }
    }
}
