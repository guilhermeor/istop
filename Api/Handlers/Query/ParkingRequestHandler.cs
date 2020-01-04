using Api.Requests;
using Api.Responses;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Handlers.Query
{
    public class ParkingRequestHandler : IRequestHandler<ParkingRequest, Response>
    {
        private readonly IParkingRepository _parkingRepository;
        public ParkingRequestHandler(IParkingRepository parkingRepository) => _parkingRepository = parkingRepository;
        public async Task<Response> Handle(ParkingRequest request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
                return new Response(await _parkingRepository.Get());

            return new Response(await _parkingRepository.GetById(request.Id));
        }
    }
}
