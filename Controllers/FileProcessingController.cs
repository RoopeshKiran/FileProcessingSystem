using FileProcessingSystem.Data.DTO;
using FileProcessingSystem.Data.Entities;
using FileProcessingSystem.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using FileProcessingSystem.Service.Services;
using FileProcessingSystem.Data.DTO;

namespace FileProcessingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileProcessingController : ControllerBase
    {
        private readonly IFileUploadProcessingServices _fileService;
        public FileProcessingController(IFileUploadProcessingServices fileService) => _fileService = fileService;

        [HttpPost("start")]
        public async Task<IActionResult> Start([FromBody] string path)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var id = await _fileService.StartFileProcessingAsync(path);
            return Ok(new { jobId = id });
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetStatus(Guid id)
        {
            var status = await _fileService.GetStatusAsync(id);
            if (status == null) return NotFound();
            return Ok(status);
        }
    }
}
