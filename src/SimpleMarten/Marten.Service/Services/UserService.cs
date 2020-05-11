using System;
using System.Linq;
using System.Threading.Tasks;
using Marten.Service.Domains;

namespace Marten.Service.Services
{
    public class UserService
    {
        private DocumentStore _store;

        public UserService()
        {
            _store = DocumentStore
                .For("host=localhost;database=marten_test;password=lcvaX45nQb;username=postgres");
        }

        public async Task Create()
        {
            // Open a session for querying, loading, and
            // updating documents
            using (var session = _store.LightweightSession()) 
            {
                var user = new User { FirstName = "Test", LastName = "Solo" };
                session.Store(user);
            
                await session.SaveChangesAsync();
            }
        }

        public async Task<User> GetSingle()
        {
            // Open a session for querying, loading, and
            // updating documents with a backing "Identity Map"
            using var session = _store.OpenSession();
            var existing = await session
                .Query<User>()
                .SingleAsync(x => x.FirstName == "Han" && x.LastName == "Solo");

            return existing;
        }

        public async Task<User> GetById()
        {
            using var session = _store.OpenSession();
            var userId = Guid.Parse("0171f3dc-1b24-4318-b034-b9674fd51e41");
            var user = await session.LoadAsync<User>(userId);

            return user;
        }

        public async Task Update()
        {
            // Open a session for querying, loading, and
            // updating documents with a backing "Identity Map"
            using var session = _store.LightweightSession();
            var existing = await session
                .Query<User>()
                .SingleAsync(x => x.FirstName == "Han" && x.LastName == "Solo");

            existing.Department = "department";
                
            session.Store(existing);
            await session.SaveChangesAsync();
        }
    }
}