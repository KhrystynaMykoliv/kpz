using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using AdvertisingAgencyApi.Repositories;
using AdvertisingAgencyApi.Models;
using AdvertisingAgencyApi.DTOs;

[ApiController]
[Route("api/[controller]")]
public class ClientsController : ControllerBase
{
    private readonly IClientRepository _repository;
    private readonly IMapper _mapper;

    public ClientsController(IClientRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClientDto>>> GetClients()
    {
        var Clients = await _repository.GetAllAsync();

        var ClientDtos = _mapper.Map<IEnumerable<ClientDto>>(Clients);

        return Ok(ClientDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ClientDto>> GetClient(int id)
    {
        var Client = await _repository.GetByIdAsync(id);
        if (Client == null)
        {
            return NotFound();
        }

        var ClientDto = _mapper.Map<ClientDto>(Client);
        return Ok(ClientDto);
    }

    [HttpPost]
    public async Task<ActionResult<ClientDto>> PostClient([FromBody] CreateClientDto createClientDto)
    {
        var Client = _mapper.Map<Client>(createClientDto);

        try
        {
            await _repository.AddAsync(Client);
            await _repository.SaveChangesAsync();
        }
        catch
        {
            return StatusCode(500, "A problem happened while handling your request.");
        }

        var ClientDto = _mapper.Map<ClientDto>(Client);
        return CreatedAtAction(nameof(GetClient), new { id = ClientDto.PersonId }, ClientDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutClient(int id, [FromBody] CreateClientDto clientDto)
    {
        var existingClient = await _repository.GetByIdAsync(id);
        if (existingClient == null)
        {
            return NotFound("Client not found.");
        }

        _mapper.Map(clientDto, existingClient);

        try
        {
            await _repository.UpdateAsync(existingClient);
            await _repository.SaveChangesAsync();
        }
        catch
        {
            return StatusCode(500, "A problem happened while handling your request.");
        }

        var resultDto = _mapper.Map<ClientDto>(existingClient);

        return CreatedAtAction(nameof(GetClient), new { id = resultDto.PersonId }, resultDto);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteClient(int id)
    {
        var Client = await _repository.GetByIdAsync(id);
        
        if (Client == null)
        {
            return NotFound();
        }
        
        await _repository.DeleteAsync(id);
        await _repository.SaveChangesAsync();
        
        return Ok();
    }
}
