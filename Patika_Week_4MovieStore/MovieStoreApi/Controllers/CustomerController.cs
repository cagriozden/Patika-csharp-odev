﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MovieStoreApi.Application.CustomerOperations.CreateCustomer;
using MovieStoreApi.DbOperations;
using MovieStoreApi.TokenOperations.Models;
using static MovieStoreApi.Application.CustomerOperations.CreateCustomer.CreateTokenCommand;



namespace MovieStoreApi.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public CustomerController(IMapper mapper, MovieStoreDbContext context, IConfiguration configuration)
        {
            _mapper = mapper;
            _context = context;
            _configuration = configuration;
        }

        // POST 
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCustomerModel newCustomer)
        {
            CreateCustomerCommand command = new CreateCustomerCommand(_context, _mapper);
            command.Model = newCustomer;
            CreateCustomerCommandValidator validator = new CreateCustomerCommandValidator();
            validator.ValidateAndThrow(command);

            await command.Handle();
            return Ok();
        }
        //POSTTOKEN
        [HttpPost("connect/token")]
        public async Task<ActionResult<Token>> CreateToken([FromBody] CreateTokenModel login)
        {
            CreateTokenCommand command = new CreateTokenCommand(_context, _mapper, _configuration);
            command.Model = login;
            var token = await command.Handle();
            return token;
        }
        //GETTOKEN
        [HttpGet("refreshToken")]
        public async Task<ActionResult<Token>> RefreshToken([FromQuery] string token)
        {
            RefreshTokenCommand command = new RefreshTokenCommand(_context, _configuration);
            command.RefreshToken = token;
            var resultToken = await command.Handle();
            return resultToken;
        }
        // DELETE
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

