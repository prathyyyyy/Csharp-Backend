using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Text.Json.Nodes;
using WorldAPI.Data;
using WorldAPI.DTO.Country;
using WorldAPI.DTO.State;
using WorldAPI.Models;
using WorldAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;


namespace WorldAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {
        private readonly IStatesRepository _statesRepository;
        private readonly IMapper _mapper;

        public StatesController(IStatesRepository statesRepository, IMapper mapper)
        {
            _statesRepository = statesRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetState")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<StatesDTO>>> GetAll()
        {
            var countries = await _statesRepository.GetAll();
            var countryDto = _mapper.Map<List<StatesDTO>>(countries);

            if (countries == null)
            {
                return NoContent();
            }
            return Ok(countryDto);
        }

        [HttpGet]
        [Route("GetStateWithCountry")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]

       


        [HttpGet("{Country}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<List<State>>> GetByCont(string Country)
        {
            var result = await _statesRepository.GetStateWCountry(Country);

            if (result == null)
            {
                return NoContent();
            }

            return Ok(result);
        }




        [HttpGet("ID:int")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<StatesDTO>> GetById(int id)
        {
            var states = await _statesRepository.Get(id);

            var statesDTO = _mapper.Map<StatesDTO>(states);

            if (states == null)
            {
                return NoContent();
            }
            return Ok(statesDTO);
        }

        [HttpGet("Lstate:String")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]



        [HttpPost]
        [Route("CreateState")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<CreateStatesDTO>> Create([FromBody] CreateStatesDTO statesDTO)
        {
            var result = _statesRepository.IsRecordExists(x => x.Name == statesDTO.Name);

            if (result)
            {
                return Conflict("States Exist In DataBase");
            }

            //Countries country = new();
            /*country.CountryName = countryDTO.CountryName;
            country.CountryCode = countryDTO.CountryCode;
            country.CountrySmallName = countryDTO.CountrySmallName;*/

            var states = _mapper.Map<State>(statesDTO);

            await _statesRepository.Create(states);
            return CreatedAtAction("GetByID", new { id = states.Id }, states);
        }

        [HttpPut]
        [Route("UpdateStatebyID")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<State>> Update(int id, [FromBody] UpdateStatesDTO statesDTO)
        {
            if (statesDTO == null || id != statesDTO.Id)
            {
                return BadRequest();
            }

            var states = _mapper.Map<State>(statesDTO);



            await _statesRepository.Update(states);
            return NoContent();

        }

        [HttpDelete]
        [Route("DeleteState")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteById(int id)
        {
            var states = await _statesRepository.Get(id);

            if (id == 0)
            {
                return BadRequest();
            }

            if (states == null)
            {
                return NotFound();
            }


            await _statesRepository.Delete(states);
            return NoContent();
        }

    }
}

