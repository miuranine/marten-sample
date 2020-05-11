using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleMarten.API.Commands;
using SimpleMarten.API.Domain;

namespace SimpleMarten.API.Listeners
{
    public class PolicyAccountCreatedHandler : IRequestHandler<PolicyAccountCommand, PolicyAccountResponse>
    {
        private readonly IDataStore _dataStore;

        public PolicyAccountCreatedHandler(IDataStore dataStore)
        {
            _dataStore = dataStore;
        }
        
        public async Task<PolicyAccountResponse> Handle(PolicyAccountCommand request, CancellationToken cancellationToken)
        {
            var policyAccountNumber = Guid.NewGuid().ToString();
            var policy = new PolicyAccount
            (
                request.PolicyNumber, 
                policyAccountNumber,
                request.PolicyHolder.FirstName,
                request.PolicyHolder.LastName
            );

            using (_dataStore)
            {
                if (await _dataStore.PolicyAccounts.ExistsWithPolicyNumber(request.PolicyNumber))
                    return new PolicyAccountResponse();
                
                _dataStore.PolicyAccounts.Add(policy);
                await _dataStore.CommitChanges();

                return new PolicyAccountResponse();
            }
            
        }
    }
}