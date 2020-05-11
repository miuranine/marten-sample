using System;
using SimpleMarten.API.Commands.Dtos;

namespace SimpleMarten.API.Models
{
    public class CreatePolicyAccountRequest
    {
        public string PolicyNumber { get; set; }
        public string ProductCode { get; set; }
        public DateTime PolicyFrom { get; set; }
        public DateTime PolicyTo { get; set; }
        public PersonDto PolicyHolder { get; set; }
        public decimal TotalPremium { get; set; }
        public string AgentLogin { get; set; }
    }
}