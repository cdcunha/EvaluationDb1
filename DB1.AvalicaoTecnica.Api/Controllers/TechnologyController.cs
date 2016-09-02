using DB1.AvaliacaoTecnica.Domain.Commands.TechnologyCommands;
using DB1.AvaliacaoTecnica.Domain.Services;
using DB1.AvalicaoTecnica.Api;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace DB1.AvaliacaoTecnica.Api.Controllers
{
    [HeaderFilterConfig]
    public class TechnologyController : BaseController
    {
        private readonly ITechnologyApplicationService _service;

        public TechnologyController(ITechnologyApplicationService service)
        {
            this._service = service;
        }
        
        [HttpGet]
        [Route("api/technologies")]
        public Task<HttpResponseMessage> Get()
        {
            var technologies = _service.Get();
            return CreateResponse(HttpStatusCode.Created, technologies);
        }

        [HttpGet]
        [Route("api/technologies/{id}")]
        public Task<HttpResponseMessage> Get(int id)
        {
            var technologies = _service.Get(id);
            return CreateResponse(HttpStatusCode.Created, technologies);
        }

        [HttpPost]
        [Route("api/technologies")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var technology = _service.Create((string)body.description);
            return CreateResponse(HttpStatusCode.Created, technology);
        }

        [HttpPut]
        [Route("api/technologies/{id}")]
        public Task<HttpResponseMessage> Put(int id, [FromBody]dynamic body)
        {
            var command = new EditTechnologyCommand(
                id: id,
                description: (string)body.description
            );

            var technology = _service.Update(command);
            return CreateResponse(HttpStatusCode.OK, technology);
        }

        [HttpDelete]
        [Route("api/technologies/{id}")]
        public Task<HttpResponseMessage> Delete(int id)
        {
            var technology = _service.Delete(id);
            return CreateResponse(HttpStatusCode.OK, technology);
        }
    }
}
