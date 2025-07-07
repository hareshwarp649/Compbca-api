using AutoMapper;
using bca.api.Data.Entities;
using bca.api.DTOs;
using bca.api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bca.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BanksController : ControllerBase
    {
        private readonly IBankService _bankService;

        private readonly ILogger<BanksController> _logger;

        private readonly IMapper _mapper;

        public BanksController(IBankService bankService, ILogger<BanksController> logger, IMapper mapper)
        {
            _bankService = bankService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<BankDetails>>> GetAll()
        {
            var banks = await _bankService.GetAllBanksAsync();
            var bankDetailsList = _mapper.Map<List<BankDetails>>(banks);

            return Ok(bankDetailsList);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<BankDetails>> GetById(int id)
        {
            var bank = await _bankService.GetBankByIdAsync(id);
            if (bank == null)
                return NotFound();


            var bankDetails = _mapper.Map<BankDetails>(bank);

            return Ok(bankDetails);
        }

        [HttpPost]
        public async Task<ActionResult<BankDetails>> Create([FromBody] BankInput bankInput)
        {
            Bank bank = _mapper.Map<Bank>(bankInput);
            var createdBank = await _bankService.CreateBankAsync(bank);
            var bankDetails = _mapper.Map<BankDetails>(createdBank);
            return CreatedAtAction(nameof(GetById), new { id = createdBank.Id }, bankDetails);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BankInput bankInput)
        {
            _logger.LogInformation($"Update request received for ID: {id}");

            var bank = await _bankService.GetBankByIdAsync(id);
            if (bank == null)
            {
                _logger.LogInformation($"Bank with ID {id} not found.");
                return NotFound();
            }

            bank.Name = bankInput.Name;
            bank.ODCode = bankInput.ODCode;
            bank.ShortName = bankInput.ShortName;

            var updatedBank = await _bankService.UpdateBankAsync(bank);

            if (updatedBank == null)
            {
                _logger.LogInformation($"Failed to update bank with ID {id}.");
                return NotFound();
            }

            var bankDetails = _mapper.Map<BankDetails>(updatedBank);
            _logger.LogInformation($"Bank with ID {id} successfully updated.");
            return Ok(bankDetails);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await _bankService.DeleteBankAsync(id) ? NoContent() : NotFound();
        }
    }
}
