using Api.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Api.Requests
{
    public class ParkingRequest : IRequest<Response>
    {
        public Guid Id { get; set; }
    }
}
