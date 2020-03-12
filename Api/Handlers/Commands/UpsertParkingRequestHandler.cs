using Api.Requests;
using Api.Responses;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Handlers.Commands
{
    public class UpsertParkingRequestHandler : IRequestHandler<UpsertParkingRequest, Response>
    {
        private readonly IParkingRepository _parkingRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpsertParkingRequestHandler(IParkingRepository parkingRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _parkingRepository = parkingRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> Handle(UpsertParkingRequest request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
                await _parkingRepository.Add(_mapper.Map<Parking>(request));
            else
            {
                var parking = await _parkingRepository.GetById(request.Id);
                if (parking != null)
                    _mapper.Map(request, parking);
                else
                    return new NotFoundResult($"Parking not found to Parking Id: {request.Id}");
            }

            await _unitOfWork.SaveChangesAsync();
            return new OkResult($"Parking {request.Name} Created Succesfully");
        }
    }
}
