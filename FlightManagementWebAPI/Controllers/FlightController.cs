﻿using DomainModel.Models;
using FlightManagementWebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightManagementWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly FlightRepository _flightRepository;
        public FlightController(FlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }
        [HttpGet]
        public IActionResult GetFlights()
        {
            try
            {
                var flights = _flightRepository.GetFlights();
                return Ok(flights);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult AddFlight([FromBody] Flight flight)
        {
            if (flight == null)
                return BadRequest();

            try
            {
                _flightRepository.InsertFlight(flight);
                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public IActionResult UpdateFlight([FromBody] Flight flight)
        {
            if (flight == null)
                return BadRequest();
            try
            {
                _flightRepository.UpdateFlight(flight);
                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{flightId:int}")]
        public IActionResult GetFlight(int flightId)
        {
            try
            {
                var flight = _flightRepository.GetFlight(flightId);
                return Ok(flight);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            
        }
    }
}
