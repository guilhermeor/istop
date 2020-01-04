using Api.Requests;
using Api.Responses;
using Domain.Interfaces;
using Infrastructure;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Handlers.Commands
{
    public class RemoveParkingRequestHandler : IRequestHandler<RemoveParkingRequest, Response>
    {
        private readonly IParkingRepository _parkingRepository;
        private readonly IUnitOfWork _unitOfWork;
        public RemoveParkingRequestHandler(IParkingRepository parkingRepository, IUnitOfWork unitOfWork)
        {
            _parkingRepository = parkingRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> Handle(RemoveParkingRequest request, CancellationToken cancellationToken)
        {
            var parking = await _parkingRepository.GetById(request.Id);
            if (parking == null)
                return new NotFoundResult($"Parking not found to Parking Id: {request.Id}");
            
            _parkingRepository.Delete(parking);
            await _unitOfWork.SaveChangesAsync();

            return new OkResult($"Parking {request.Id} remove sucessfully");
        }
    }
}
