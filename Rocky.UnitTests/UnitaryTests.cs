using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rocky.Controllers;
using Rocky.Data;

namespace Rocky.UnitTests
{
    [TestClass]
    public class UnitaryTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var connectionstring = "Server=WIN-S12PPN71OHI\\CRISTIAN;Database=Rocky;Trusted_Connection=True;MultipleActiveResultSets=true";
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (var db = new ApplicationDbContext(optionsBuilder.Options))
            {
                var categoryController = new CategoryController(db);

                Assert.AreEqual(1, categoryController.GetCategoryById(1).Id);
            }
        }

        [TestMethod]
        public void TestMethod2()
        {
            var connectionstring = "Server=WIN-S12PPN71OHI\\CRISTIAN;Database=Rocky;Trusted_Connection=True;MultipleActiveResultSets=true";
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (var db = new ApplicationDbContext(optionsBuilder.Options))
            {
                var applicationController = new ApplicationTypeController(db);

                Assert.AreEqual("clothing", applicationController.GetApplicationByName("clothing").Name);
            }
        }

        [TestMethod]
        public void TestMethod3()
        {
            var connectionstring = "Server=WIN-S12PPN71OHI\\CRISTIAN;Database=Rocky;Trusted_Connection=True;MultipleActiveResultSets=true";
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (var db = new ApplicationDbContext(optionsBuilder.Options))
            {
                var categoryController = new CategoryController(db);

                Assert.AreEqual("shoes", categoryController.GetCategoryByName("shoes").Name);
            }
        }
    }
}
