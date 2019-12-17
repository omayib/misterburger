using Microsoft.VisualStudio.TestTools.UnitTesting;
using MisterBurger;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MisterBurgerTest
{
    [TestClass]
    public class BurgerCreationTest
    {
        [TestMethod]
        public void burger_berhasil_diinisiasi()
        {
            Burger burger = new Burger("Chrispy Z", 29000);
            Assert.AreEqual("Chrispy Z", burger.getTitle());
        }
        [TestMethod]
        public void oven_berhasil_disetup()
        {
            Oven oven = new Oven();
            Assert.AreEqual(0, oven.countBurger());
        }
        [TestMethod]
        public void oven_berhasil_dinyalakan()
        {
            Oven oven = new Oven();
            oven.turnOn();
            Assert.IsTrue(oven.getPowerStatus());
        }
        [TestMethod]
        public void oven_berhasil_dimatikan()
        {
            Oven oven = new Oven();
            oven.turnOn();
            oven.turnOff();
            Assert.IsFalse(oven.getPowerStatus());
        }
        [TestMethod]
        public async Task oven_tidak_bisa_mulai_memasak_jika_power_belum_dinyalakan()
        {
            Oven oven = new Oven();
            oven.addBurger(new Burger("Chicken Yummy", 200));
            List<Burger> bgs = oven.getBurgers();

            var response = await oven.startCooking();

            Assert.AreEqual(-1, response);
        }
        [TestMethod]
        public async Task  oven_berhasil_mati_otomatis_dalam_3detik()
        {
            Oven oven = new Oven();
            oven.addBurger(new Burger("Chicken Yummy", 200));
            List<Burger> bgs = oven.getBurgers();
            oven.turnOn();

            var afterCoocking3Second = await oven.startCooking();

            Assert.IsFalse(oven.getPowerStatus());
        }
        [TestMethod]
        public void oven_berhasil_ditambahkan_burger()
        {
            Oven oven = new Oven();
            oven.addBurger(new Burger("Chicken Yummy", 200));
            oven.addBurger(new Burger("Beef Yummy", 3200));
            List<Burger> burgers = oven.getBurgers();
            Assert.AreEqual(2, oven.getBurgers().Count);
        }
        [TestMethod]
        public void oven_gagal_ditambahkan_burger_karena_batas_maksimal()
        {
            Oven oven = new Oven();
            oven.addBurger(new Burger("Chicken Yummy", 200));
            oven.addBurger(new Burger("Beef Yummy", 3200));
            oven.addBurger(new Burger("Udang Yummy", 3200));
            var result = oven.addBurger(new Burger("Spicy Chicken Yummy", 3200));
            Assert.IsFalse(result);
        }

        [TestMethod]
        public async Task burger_berhasil_dimasak_3detik_dalam_oven()
        {
            Oven oven = new Oven();
            oven.addBurger(new Burger("Chicken Yummy", 200));
            List<Burger> burgers = oven.getBurgers();
            oven.turnOn();
            var result = await oven.startCooking();
            Assert.IsTrue(burgers[0].isCoocked());
        }
    }
}
