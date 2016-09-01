using DB1.AvaliacaoTecnica.Domain.Commands.VacancyTechnologyCommands;
using DB1.AvaliacaoTecnica.Domain.Services;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace DB1.AvaliacaoTecnica.Api.Controllers
{
    public class VacancyController : BaseController
    {
        private readonly IVacancyApplicationService _service;

        public VacancyController(IVacancyApplicationService service)
        {
            this._service = service;
        }

        [HttpGet]
        [Route("api/vacancies")]
        public Task<HttpResponseMessage> Get()
        {
            var vacancies = _service.Get();
            return CreateResponse(HttpStatusCode.Created, vacancies);
        }

        [HttpGet]
        [Route("api/vacancies/{id}")]
        public Task<HttpResponseMessage> Get(int id)
        {
            var vacancies = _service.Get(id);
            return CreateResponse(HttpStatusCode.Created, vacancies);
        }

        [HttpPost]
        [Route("api/vacancies")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var command = new CreateVacancyCommand(
                description: (string)body.description,
                vacancyTechnologies: body.vacancyTechnologies.ToObject<List<CreateVacancyTechnologyCommand>>(),
                candidates: body.candidates.ToObject<List<CreateCandidateCommand>>()
            );

            var vacancy = _service.Create(command);
            return CreateResponse(HttpStatusCode.Created, vacancy);
        }

        [HttpPut]
        [Route("api/vacancies/{id}")]
        public Task<HttpResponseMessage> Put(int id, [FromBody]dynamic body)
        {
            var command = new EditVacancyCommand(
                id: id,
                description: (string)body.description
            );

            var vacancy = _service.Update(command);
            return CreateResponse(HttpStatusCode.OK, vacancy);
        }

        [HttpDelete]
        [Route("api/vacancies/{id}")]
        public Task<HttpResponseMessage> Delete(int id)
        {
            var vacancy = _service.Delete(id);
            return CreateResponse(HttpStatusCode.OK, vacancy);
        }

        [HttpDelete]
        [Route("api/vacancies/{id}")]
        public Task<HttpResponseMessage> Finalize(int id)
        {
            var finalize = _service.Finalize(id);
            return CreateResponse(HttpStatusCode.OK, finalize);
        }
    }
}
