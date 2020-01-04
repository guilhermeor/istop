using System;
using System.Threading.Tasks;
using Api.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Api.Controllers.Extensions;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingController : Controller
    {
        private readonly IMediator _mediator;
        public ParkingController(IMediator mediator) => _mediator = mediator;

        // GET: api/Parking
        [HttpGet]
        public async Task<IActionResult> Get() => this.ToActionResult(await _mediator.Send(new ParkingRequest()));

        // GET: api/Parking/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(Guid id) => this.ToActionResult(await _mediator.Send(new ParkingRequest { Id = id }));

        // POST: api/Parking
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UpsertParkingRequest request) => this.ToActionResult(await _mediator.Send(request));

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return this.ToActionResult(await _mediator.Send(new RemoveParkingRequest { Id = id}));
        }

        // PUT: api/Parking/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, UpsertParkingRequest request)
        {
            request.Id = id;
            return this.ToActionResult(await _mediator.Send(request));
        }

    }
}
