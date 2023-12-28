using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;
using WorldAPI.Data;
using WorldAPI.DTO.Country;
using WorldAPI.Models;
using WorldAPI.Repository.IRepository;

namespace WorldAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CountryController> _logger;

        public CountryController(ICountryRepository countryRepository, IMapper mapper, ILogger<CountryController> logger)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetCountry")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<CountryDTO>>> GetAll()
        {
            var countries = await _countryRepository.GetAll();
            
            var countryDto = _mapper.Map<List<CountryDTO>>(countries);
            
            if (countries == null)
            {
                return NoContent();
            }
            return Ok(countryDto);
        }

        [HttpGet("ID:int")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<CountryDTO>> GetById(int id)
        {
            var country = await _countryRepository.Get(id);

            

            if (country == null)
            {
                _logger.LogError($"Unable To Fetch ID: {id}");
                return NoContent();
            }
            var countryDto = _mapper.Map<CountryDTO>(country);
            return Ok(countryDto);
        }


        [HttpPost]
        [Route("CreateCountry")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<CreateCountryDTO>> Create([FromBody]CreateCountryDTO countryDTO)
        {
            var result = _countryRepository.IsRecordExists(x => x.CountryName == countryDTO.CountryName);

            if (result)
            {
                return Conflict("Country Exist In DataBase");
            }
            
            //Countries country = new();
            /*country.CountryName = countryDTO.CountryName;
            country.CountryCode = countryDTO.CountryCode;
            country.CountrySmallName = countryDTO.CountrySmallName;*/

            var country = _mapper.Map<Countries>(countryDTO);

            await _countryRepository.Create(country);
            return CreatedAtAction("GetByID", new {id=country.ID},country);
        }

        [HttpPut]

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Countries>> Update(int id,[FromBody] UpdateCountryDTO countryDto)
        {
            if (countryDto == null || id != countryDto.ID)
            {
                return BadRequest();
            }

            var country = _mapper.Map<Countries>(countryDto);

           

            await _countryRepository.Update(country);
            return NoContent();

        }

        [HttpDelete]

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteById(int id)
        {
            var country = await _countryRepository.Get(id);

            if (id == 0)
            {
                return BadRequest();
            }

            if (country == null)
            {
                return NotFound();
            }


            await _countryRepository.Delete(country);
            return NoContent();    
        }

    }
}
 
