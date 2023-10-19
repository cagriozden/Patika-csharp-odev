﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStoreApi.Application.DirectorOperations.CreateDirector;
using MovieStoreApi.Application.DirectorOperations.DeleteDirector;
using MovieStoreApi.Application.DirectorOperations.GetDirectorDetail;
using MovieStoreApi.Application.DirectorOperations.GetDirectors;
using MovieStoreApi.Application.DirectorOperations.UpdateDirector;
using MovieStoreApi.DbOperations;


namespace MovieStoreApi.Controllers
{
    [Route("api/[controller]")]
    public class DirectorController : Controller
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public DirectorController(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            GetDirectorQuery query = new(_context, _mapper);
            var result = await query.Handle();
            return Ok(result);
        }

        // GET 
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            DirectorDetailQuery query = new(_context, _mapper);
            query.DirectorId = id;
            DirectorDetailQueryValidator validator = new DirectorDetailQueryValidator();
            validator.ValidateAndThrow(query);
            var result = await query.Handle();
            return Ok(result);
        }

        // POST 
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateDirectorModel newDirector)
        {
            CreateDirectorCommand command = new(_context, _mapper);
            command.Model = newDirector;
            CreateDirectorCommandValidator validator = new CreateDirectorCommandValidator();
            validator.ValidateAndThrow(command);
            await command.Handle();

            return Ok();
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateDirectorModel updateDirector)
        {
            UpdateDirectorCommand command = new(_context);
            command.Model = updateDirector;
            command.DirectorId = id;
            UpdateDirectorCommandValidator validator = new UpdateDirectorCommandValidator();
            validator.ValidateAndThrow(command);

            await command.Handle();
            return Ok();
        }

        // DELETE 
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            DeleteDirectorCommand command = new(_context);
            command.DirectorId = id;
            DeleteDirectorCommandValidator validator = new DeleteDirectorCommandValidator();
            validator.ValidateAndThrow(command);

            await command.Handle();
            return Ok();
        }
    }
}

