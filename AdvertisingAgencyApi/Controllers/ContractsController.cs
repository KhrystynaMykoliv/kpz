using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using AdvertisingAgencyApi.Repositories;
using AdvertisingAgencyApi.Models;
using AdvertisingAgencyApi.DTOs;

[ApiController]
[Route("api/[controller]")]
public class ContractsController : ControllerBase
{
    private readonly IContractRepository _repository;
    private readonly IMapper _mapper;

    public ContractsController(IContractRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ContractDto>>> GetContracts()
    {
        var contracts = await _repository.GetAllAsync();
        var contractDtos = _mapper.Map<IEnumerable<ContractDto>>(contracts);

        return Ok(contractDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ContractDto>> GetContract(int id)
    {
        var contract = await _repository.GetByIdAsync(id);
        if (contract == null)
        {
            return NotFound();
        }

        var contractDto = _mapper.Map<ContractDto>(contract);
        return Ok(contractDto);
    }

    [HttpPost]
    public async Task<ActionResult<ContractDto>> PostContract([FromBody] CreateContractDto createContractDto)
    {
        var contract = _mapper.Map<Contract>(createContractDto);

        try
        {
            await _repository.AddAsync(contract);
            await _repository.SaveChangesAsync();
        }
        catch
        {
            return StatusCode(500, "A problem happened while handling your request.");
        }

        var contractDto = _mapper.Map<ContractDto>(contract);
        return CreatedAtAction(nameof(GetContract), new { id = contractDto.ContractCode }, contractDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutContract(int id, [FromBody] ContractDto contractDto)
    {
        if (id != contractDto.ContractCode)
        {
            return BadRequest("Contract ID mismatch");
        }

        var contract = _mapper.Map<Contract>(contractDto);
        contract.ContractCode = id;

        try
        {
            await _repository.UpdateAsync(contract);
            await _repository.SaveChangesAsync();
        }
        catch
        {
            return StatusCode(500, "A problem happened while handling your request.");
        }

        var resultDto = _mapper.Map<ContractDto>(contract);
        return Ok(resultDto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteContract(int id)
    {
        var contract = await _repository.GetByIdAsync(id);
        
        if (contract == null)
        {
            return NotFound();
        }
        
        await _repository.DeleteAsync(id);
        await _repository.SaveChangesAsync();
        
        return NoContent();
    }
}
