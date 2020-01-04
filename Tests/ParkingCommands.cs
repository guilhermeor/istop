using Api.Handlers.Commands;
using Api.Requests;
using Api.Responses;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ValueObjects;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Xunit;

namespace Tests
{
    public class ParkingCommands
    {
        private List<Parking> parkings;
        private const string parkingIdFake = "565378a0-2006-4bdf-9e17-0aa01f3cb49b";
        private readonly Mock<IParkingRepository> _mockParkingRepository;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly Mock<DbSet<Parking>> _mockSet;
        private readonly RemoveParkingRequestHandler _commandHandler;
        public ParkingCommands()
        {
            parkings = new List<Parking>() {
                new Parking(Guid.Parse(parkingIdFake), "Parking1", new Address("carambola","123") ,5),
                new Parking(Guid.NewGuid(), "Parking2", new Address("acerola","456"), 15)
            };
            _mockParkingRepository = new Mock<IParkingRepository>();
            _mockUow = new Mock<IUnitOfWork>();
            _commandHandler = new RemoveParkingRequestHandler(_mockParkingRepository.Object, _mockUow.Object);
            _mockSet = new Mock<DbSet<Parking>>();
        }

        [Theory]
        [InlineData(parkingIdFake)]
        [InlineData("bb488a8d-60ad-42b7-aef8-9f85f6b995e1")]
       public async void ShouldRemoveParkingWhenItExists(string id)
        {
            _mockParkingRepository.Setup(m => m.GetById(It.IsAny<Guid>()))
                .ReturnsAsync(parkings.FirstOrDefault(_ => _.Id.ToString() == id));

            var result = await _commandHandler.Handle(new RemoveParkingRequest { Id = Guid.Parse(id) }, CancellationToken.None);

            void Verify<T>(Times times, Response response) where T : Response
            {
                Assert.IsType<T>(result);
                _mockUow.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), times);
                _mockParkingRepository.Verify(m => m.Delete(It.IsAny<Parking>()), times);
            }

            if (parkings.Any(p => p.Id.ToString() == id))
                Verify<OkResult>(Times.Once(), result);

            else
                Verify<NotFoundResult>(Times.Never(), result);
        }
    }
}
