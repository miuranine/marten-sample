using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleMarten.API.Commands;
using SimpleMarten.API.Models;

namespace SimpleMarten.API.Controllers
{
    [Route("api/[controller]")]
    public class PolicyAccountController : Controller
    {
        private readonly IMediator _mediator;

        public PolicyAccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> CreateAccount([FromBody]CreatePolicyAccountRequest request)
        {
            await _mediator.Send(
                new PolicyAccountCommand(
                    request.PolicyNumber, 
                    request.ProductCode,
                    request.PolicyFrom,
                    request.PolicyTo,
                    request.PolicyHolder,
                    request.TotalPremium,
                    request.AgentLogin));
            
            return new JsonResult(new { success = true });
        }
        
        /*[HttpGet("accounts/{policyNumber}")]
        public async Task<ActionResult> AccountBalance(string policyNumber)
        {
            var result = await _mediator.Send(new GetAccountBalanceQuery {PolicyNumber = policyNumber});
            return new JsonResult(result);
        } */
    }
}