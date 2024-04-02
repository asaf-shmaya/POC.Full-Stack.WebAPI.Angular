using ASP.NET_Core_Web_API.Interfaces;
using ASP.NET_Core_Web_API.Models;
using ASP.NET_Core_Web_API.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASP.NET_Core_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsurancePoliciesController : ControllerBase
    {
        private readonly IInsurancePolicyRepository _policyRepository;

        public InsurancePoliciesController(IInsurancePolicyRepository policyRepository)
        {
            _policyRepository = policyRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InsurancePolicy>>> GetAllInsurancePolicies()
        {
            var policies = await _policyRepository.GetAllInsurancePolicies();
            return Ok(policies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InsurancePolicy>> GetInsurancePolicyById(int id)
        {
            var policy = await _policyRepository.GetInsurancePolicyById(id);
            if (policy == null)
            {
                return NotFound();
            }
            return Ok(policy);
        }

        //[HttpPost]
        //public async Task<ActionResult<InsurancePolicy>> CreateInsurancePolicy(InsurancePolicy policy)
        //{
        //    await _policyRepository.CreateInsurancePolicy(policy);
        //    return CreatedAtAction(nameof(GetInsurancePolicyById), new { id = policy.ID }, policy);
        //}

        [HttpPost]
        public async Task<ActionResult<InsurancePolicy>> CreateInsurancePolicy([FromBody] CreateInsurancePolicyDto createDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Map DTO to InsurancePolicy entity
            var policy = new InsurancePolicy
            {
                PolicyNumber = createDto.PolicyNumber,
                InsuranceAmount = (decimal)createDto.InsuranceAmount,
                StartDate = createDto.StartDate,
                EndDate = createDto.EndDate,
                UserID = createDto.UserID
            };

            // Create the insurance policy
            await _policyRepository.CreateInsurancePolicy(policy);

            // Return the created policy
            return CreatedAtAction(nameof(GetInsurancePolicyById), new { id = policy.ID }, policy);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInsurancePolicy(int id, [FromBody] InsurancePolicyUpdateDto updateDto)
        {
            var policy = await _policyRepository.GetInsurancePolicyById(id);
            if (policy == null)
            {
                return NotFound();
            }

            // Update policy properties
            policy.PolicyNumber = updateDto.PolicyNumber;
            policy.InsuranceAmount = (decimal)updateDto.InsuranceAmount;
            policy.StartDate = updateDto.StartDate;
            policy.EndDate = updateDto.EndDate;

            await _policyRepository.UpdateInsurancePolicy(policy);

            return NoContent(); // 204 No Content
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInsurancePolicy(int id)
        {
            await _policyRepository.DeleteInsurancePolicy(id);
            return NoContent();
        }
    }
}
