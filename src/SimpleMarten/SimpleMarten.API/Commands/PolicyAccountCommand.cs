using System;
using MediatR;
using SimpleMarten.API.Commands.Dtos;

namespace SimpleMarten.API.Commands
{
    public class PolicyAccountCommand : IRequest<PolicyAccountResponse>
    {
        public string PolicyNumber { get; private set; }
        public string ProductCode { get; private set; }
        public DateTime PolicyFrom { get; private set; }
        public DateTime PolicyTo { get; private set; }
        public PersonDto PolicyHolder { get; private set; }
        public decimal TotalPremium { get; private set; }
        public string AgentLogin { get; private set; }

        public PolicyAccountCommand(
            string policyNumber, 
            string productCode, 
            DateTime policyFrom, 
            DateTime policyTo,
            PersonDto policyHolder, decimal totalPremium, string agentLogin)
        {
            PolicyNumber = policyNumber;
            ProductCode = productCode;
            PolicyFrom = policyFrom;
            PolicyTo = policyTo;
            TotalPremium = totalPremium;
            AgentLogin = agentLogin;
            PolicyHolder = policyHolder;
        }
    }
}