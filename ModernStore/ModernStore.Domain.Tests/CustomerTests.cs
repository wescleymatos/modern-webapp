using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModernStore.Domain.Entities;
using ModernStore.Domain.ValueObjects;

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
            var name = new Name("", "Matos");
            var email = new Email("wescleymatos@gmail.com");
            var document = new Document("12988821259");
            var customer = new Customer(name, email, document, user);

            Assert.IsFalse(customer.IsValid());
        }

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidLastNameShouldReturnAnyNotification()
        {
            var user = new User("wescleymatos", "1q2w3e4r");
            var name = new Name("Wescley", "");
            var email = new Email("wescleymatos@gmail.com");
            var document = new Document("12988821259");
            var customer = new Customer(name, email, document, user);

            Assert.IsFalse(customer.IsValid());
        }

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidEmailShouldReturnAnyNotification()
        {
            var user = new User("wescleymatos", "1q2w3e4r");
            var name = new Name("Wescley", "Matos");
            var email = new Email("wescleymatos@gmail");
            var document = new Document("12988821259");
            var customer = new Customer(name, email, document, user);

            Assert.IsFalse(customer.IsValid());
        }

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidDocumentShouldReturnAnyNotification()
        {
            var user = new User("wescleymatos", "1q2w3e4r");
            var name = new Name("Wescley", "Matos");
            var email = new Email("wescleymatos@gmail.com");
            var document = new Document("11111111111");
            var customer = new Customer(name, email, document, user);

            Assert.IsFalse(customer.IsValid());
        }
    }
}
