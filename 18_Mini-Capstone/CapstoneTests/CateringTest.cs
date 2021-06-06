using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CapstoneTests
{ 

    [TestClass]
    public class CateringTest
    {
        CateringItem catering;

        [TestInitialize]

        public void Setup()
        {
            catering = new CateringItem();
        }

        [TestMethod]
        public void Check_that_catering_object_is_created()
        {
            // Arrange 
            Catering catering = new Catering();

            // Act

            //Assert
            Assert.IsNotNull(catering);
        }

        [TestMethod]

        public void ItemConstructor()
        {
            Assert.IsNotNull(catering);
        }


        [TestMethod]

        public void CateringItemProperties()
        {
            Assert.AreEqual(01, catering.ProductCode, "Product Code Doesnt Exist");
            Assert.AreEqual(51, catering.Quantity, "Not enough in stock.");
        }
    }
}
