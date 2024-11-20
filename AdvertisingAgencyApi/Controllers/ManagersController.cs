using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using AdvertisingAgencyApi.Repositories;
using AdvertisingAgencyApi.Models;
using AdvertisingAgencyApi.DTOs;

[ApiController]
[Route("api/[controller]")]
public class ManagersController : ControllerBase
{
    private readonly IManagerRepository _repository;
    private readonly IMapper _mapper;

    public ManagersController(IManagerRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ManagerDto>>> GetManagers()
    {
        var Managers = await _repository.GetAllAsync();

        var ManagerDtos = _mapper.Map<IEnumerable<ManagerDto>>(Managers);

        return Ok(ManagerDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ManagerDto>> GetManager(int id)
    {
        var Manager = await _repository.GetByIdAsync(id);
        if (Manager == null)
        {
            return NotFound();
        }

        var ManagerDto = _mapper.Map<ManagerDto>(Manager);
        return Ok(ManagerDto);
    }

    [HttpPost]
    public async Task<ActionResult<ManagerDto>> PostManager([FromBody] CreateManagerDto createManagerDto)
    {
        var Manager = _mapper.Map<Manager>(createManagerDto);

        try
        {
            await _repository.AddAsync(Manager);
            await _repository.SaveChangesAsync();
        }
        catch
        {
            return StatusCode(500, "A problem happened while handling your request.");
        }

        var ManagerDto = _mapper.Map<ManagerDto>(Manager);
        return CreatedAtAction(nameof(GetManager), new { id = ManagerDto.PersonId }, ManagerDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutManager(int id, ManagerDto ManagerDto)
    {
        if (id != ManagerDto.PersonId)
        {
            return BadRequest();
        }

        var Manager = _mapper.Map<Manager>(ManagerDto);
        Manager.PersonId = id;

        if (Manager.Person == null)
        {
            Manager.Person = new Person();
        }

        try
        {
            await _repository.UpdateAsync(Manager);
            await _repository.SaveChangesAsync();
        }
        catch
        {
            return StatusCode(500, "A problem happened while handling your request.");
        }

        var resultDto = _mapper.Map<ManagerDto>(Manager);

        return CreatedAtAction(nameof(GetManager), new { id = resultDto.PersonId }, resultDto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteManager(int id)
    {
        var Manager = await _repository.GetByIdAsync(id);
        
        if (Manager == null)
        {
            return NotFound();
        }
        
        await _repository.DeleteAsync(id);
        
        return Ok();
    }
}
