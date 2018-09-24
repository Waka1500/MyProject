using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyProject.Dtos;
using MyProject.Models;
using System.Data.Entity;
using AutoMapper;

namespace MyProject.Controllers.Api
{
    public class CharactersController : ApiController
    {
        private ApplicationDbContext _context;

        public CharactersController()
        {
            _context = new ApplicationDbContext();
        }

        /*/ GET /api/characters/id
        public IHttpActionResult GetCharacters(int id)
        {

        }*/

        // POST /api/characters/id
        public IHttpActionResult CreateCharacter(CharacterDto characterDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var character = Mapper.Map<CharacterDto, Character>(characterDto);
            _context.Characters.Add(character);
            _context.SaveChanges();

            characterDto.Id = character.Id;

            return Created(new Uri(Request.RequestUri + "/" + character.Id), characterDto);
        }
    }
}
