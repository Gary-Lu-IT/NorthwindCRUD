using NorthwindControl.Models.ClientModel;
using NorthwindControl.Services;
namespace Northwind單元測試
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ClsSupplier test1 = new ClsSupplier
            {
                Name = "GaryFoods",
                ContactName = "Gary Lu",
                ContactTitle = "Chief Executive Officer",
                Country = "Taiwan",
                City = "Taipei",
                Region = "Nankang",
                Address = "5F,19-11,Sanchong Rd.",
                Homepage = "http://www.google.com",
                PostalCode = "11111",
                Phone = "02-0000-0000",
                Fax = "02-0001-0001"
            };
            SvcSupplier ss = new();
            ss.AddSupplier(test1);
            List<ClsSupplier> suppliers = ss.QuerySupplier(new ClsSupplier
            {
                Name = "Gary"
            });
            Assert.IsTrue(suppliers.Any());
            Assert.IsFalse(suppliers[0].id == 0);
            suppliers[0].Fax = "02-0002-0002";
            suppliers[0].Phone = "02-0000-0001";
            ss.UpdateSupplier(suppliers[0]);
            suppliers = ss.QuerySupplier(new ClsSupplier
            {
                Name = "Gary"
            });
            Assert.IsTrue(suppliers[0].Fax == "02-0002-0002");
            Assert.IsFalse(suppliers[0].Phone != "02-0000-0001");
            ss.DeleteSupplier(suppliers[0].id);
            suppliers = ss.QuerySupplier(new ClsSupplier
            {
                Name = "Gary"
            });
            Assert.IsFalse(suppliers.Any());
        }
    }
}