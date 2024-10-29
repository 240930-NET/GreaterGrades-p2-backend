using GreaterGradesBackend.Api.Models;
using GreaterGradesBackend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GreaterGradesBackend.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InstitutionsController : ControllerBase
    {
        private readonly IInstitutionService _institutionService;

        public InstitutionsController(IInstitutionService institutionService)
        {
            _institutionService = institutionService;
        }

        // Retrieve all Institutions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InstitutionDto>>> GetAllInstitutions()
        {
            var institutions = await _institutionService.GetAllInstitutionsAsync();
            return Ok(institutions);
        }

        // Retrieve a specific Institution by its ID
        [HttpGet("{id}")]
        public async Task<ActionResult<InstitutionDto>> GetInstitutionById(int id)
        {
            var institution = await _institutionService.GetInstitutionByIdAsync(id);
            if (institution == null)
            {
                return NotFound();
            }
            return Ok(institution);
        }

        // Create a new Institution
        [HttpPost]
        public async Task<ActionResult<InstitutionDto>> CreateInstitution(CreateInstitutionDto createInstitutionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdInstitution = await _institutionService.CreateInstitutionAsync(createInstitutionDto);
            return CreatedAtAction(nameof(GetInstitutionById), new { id = createdInstitution.InstitutionId }, createdInstitution);
        }

        // Update an existing Institution
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInstitution(int id, UpdateInstitutionDto updateInstitutionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _institutionService.UpdateInstitutionAsync(id, updateInstitutionDto);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // Delete an Institution by its ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstitution(int id)
        {
            var result = await _institutionService.DeleteInstitutionAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
