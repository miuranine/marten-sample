using System.Threading.Tasks;
using Marten;
using SimpleMarten.API.Domain;

namespace SimpleMarten.API.DataAccess.Marten
{
    public class MartenPolicyAccountRepository : IPolicyAccountRepository
    {
        private readonly IDocumentSession documentSession;

        public MartenPolicyAccountRepository(IDocumentSession documentSession)
        {
            this.documentSession = documentSession;
        }
        
        public void Add(PolicyAccount policyAccount)
        {
            documentSession.Insert(policyAccount);
        }

        public void Update(PolicyAccount policyAccount)
        {
            documentSession.Update(policyAccount);
        }

        public async Task<PolicyAccount> FindByNumber(string accountNumber)
        {
            return await documentSession
                .Query<PolicyAccount>()
                .FirstOrDefaultAsync(p => p.PolicyNumber == accountNumber);
        }

        public async Task<bool> ExistsWithPolicyNumber(string policyNumber)
        {
            return await documentSession
                .Query<PolicyAccount>()
                .AnyAsync(p => p.PolicyNumber == policyNumber);
        }
    }
}