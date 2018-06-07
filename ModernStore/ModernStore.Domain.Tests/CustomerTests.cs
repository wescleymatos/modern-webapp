using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModernStore.Domain.Entities;

namespace ModernStore.Domain.Tests
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidFirstNameShouldReturnAnyNotification()
        {
            var user = new User("wescleymatos", "1q2w3e4r");
            var customer = new Customer("", "Matos", "wescleymatos@gmail.com", user);

            Assert.IsFalse(customer.IsValid());
        }

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidLastNameShouldReturnAnyNotification()
        {
            var user = new User("wescleymatos", "1q2w3e4r");
            var customer = new Customer("Wescley", "", "wescleymatos@gmail.com", user);

            Assert.IsFalse(customer.IsValid());
        }

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidEmailShouldReturnAnyNotification()
        {
            var user = new User("wescleymatos", "1q2w3e4r");
            var customer = new Customer("Wescley", "Matos", "wescleymatos@gmail", user);

            Assert.IsFalse(customer.IsValid());
        }
    }
}
