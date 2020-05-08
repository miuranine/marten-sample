using System.Threading.Tasks;
using Marten.Service.Services;
using NUnit.Framework;

namespace Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void CreateUser()
        {
            var service = new UserService();
            service.Create();
            
            Assert.Pass("test pass.");
        }
        
        [Test]
        public async Task GetUserSingle()
        {
            var service = new UserService();
            var user = await service.GetSingle();

            Assert.IsNotEmpty(user.FirstName);
        }
        
        [Test]
        public async Task GetUserById()
        {
            var service = new UserService();
            var user = await service.GetById();

            Assert.IsNotNull(user);
        }
        
        [Test]
        public async Task UpdateUser()
        {
            var service = new UserService();
            await service.Update();

            Assert.Pass("test update");
        }
    }
}