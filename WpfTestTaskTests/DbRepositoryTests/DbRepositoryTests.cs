using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.DbRepository;
using WpfApp2.Model;

namespace WpfTestTaskTests.DbRepositoryTests
{
    [TestFixture]
    internal class DbRepositoryTests
    {
        private DbRepository _dbRepository;
        private Customer _customerToDelete;

        [SetUp]
        public void SetUp()
        {
            _dbRepository = DbRepositorySingelton.GetInstance().GetDbRepository();
            _customerToDelete = new Customer();
        }

        [TearDown]
        public void TearDown()
        {
            if (_customerToDelete.Id != 0)
            {
                _dbRepository.DeleteData(_customerToDelete);
            }
        }

        [Test]
        public void AddCustomerTest()
        {
            // Arrange
            Customer customer = new Customer()
            {
                Name = "TestName",
                CompanyName = "TestCompanyName",
                Phone = "TestPhone",
                Email = "TestEmail"
            };

            // Act
            _dbRepository.AddData(customer);
            List<Customer> customerList = _dbRepository.FetchData();
            var addedCustomer = customerList.FirstOrDefault(t => t.Name.Equals(customer.Name));
            _customerToDelete = addedCustomer;

            // Assert
            Assert.AreEqual(customer.Name, addedCustomer.Name);
            Assert.AreEqual(customer.CompanyName, addedCustomer.CompanyName);
            Assert.AreEqual(customer.Phone, addedCustomer.Phone);
            Assert.AreEqual(customer.Email, addedCustomer.Email);
        }

        [Test]
        public void UpdateCustomerTest()
        {
            // Arrange
            Customer customer = new Customer()
            {
                Name = "TestName",
                CompanyName = "TestCompanyName",
                Phone = "TestPhone",
                Email = "TestEmail"
            };

            // Act
            _dbRepository.AddData(customer);
            List<Customer> customerList = _dbRepository.FetchData();
            var addedCustomer = customerList.FirstOrDefault(t => t.Name.Equals(customer.Name));
            addedCustomer.Name = "TestName1";
            addedCustomer.CompanyName = "TestCompanyName1";
            addedCustomer.Phone = "TestPhone1";
            addedCustomer.Email = "TestEmail1";
            _dbRepository.UpdateDate(addedCustomer);
            var updatedCustomer = customerList.FirstOrDefault(t => t.Name.Equals(addedCustomer.Name));
            _customerToDelete = updatedCustomer;

            // Assert
            Assert.AreEqual(addedCustomer.Name, updatedCustomer.Name);
            Assert.AreEqual(addedCustomer.CompanyName, updatedCustomer.CompanyName);
            Assert.AreEqual(addedCustomer.Phone, updatedCustomer.Phone);
            Assert.AreEqual(addedCustomer.Email, updatedCustomer.Email);
        }

        [Test]
        public void DeleteCustomerTest()
        {
            // Arrange
            Customer customer = new Customer()
            {
                Name = "TestName",
                CompanyName = "TestCompanyName",
                Phone = "TestPhone",
                Email = "TestEmail"
            };

            // Act
            _dbRepository.AddData(customer);
            List<Customer> customerList = _dbRepository.FetchData();
            var addedCustomer = customerList.FirstOrDefault(t => t.Name.Equals(customer.Name));
            _dbRepository.DeleteData(addedCustomer);
            customerList = _dbRepository.FetchData();
            var deletedCustomer = customerList.FirstOrDefault(t => t.Name.Equals(customer.Name));

            // Assert
            Assert.IsNull(deletedCustomer);
        }
    }
}
