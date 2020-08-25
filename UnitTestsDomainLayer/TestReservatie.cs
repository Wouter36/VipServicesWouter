using DataLayer;
using DomainLayer;
using DomainLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestsDomainLayer
{
    [TestClass]
    public class TestReservatie
    {
        Klant klant;
        Limosine limosine;

        [TestInitialize]
        public void Initialize()
        {
            klant = new Klant() { Naam = "Gerrit", BTWNummer = "be1233552", KlantCategorie = Categorie.Concertpromotor, WoonAdres = "china" };
            limosine = new Limosine() { Naam = "De naamloze limo", EersteUurPrijs = 100, NightLifePrijs = 200, WeddingPrijs = 200, WellnessPrijs = 200 };
        }

        [TestCleanup]
        public void Cleanup()
        {
            UnitOfWork uow = UnitOfWork.GetUnitOfWork();
            uow.context.Reservaties.RemoveRange(uow.context.Reservaties);
            uow.context.Klanten.RemoveRange(uow.context.Klanten);
            uow.context.Limosines.RemoveRange(uow.context.Limosines);
            uow.Complete();
        }

        [TestMethod]
        public void TestGetPriceBusinessReservatie()
        {
            // Arrange
            IReservatiePrijzing prijzing = new BusinessReservatiePrijzing();
            DateTime date = DateTime.Now;
            Reservatie reservatie = new Reservatie(klant,"Gent","Antwerpen",date, 2, limosine, ReservatieType.Business, prijzing, 0, 10);
            // Act Assert
            Assert.AreEqual(170 , reservatie.GetPrice());
        }
        [TestMethod]
        public void TestGetPriceAirportReservatie()
        {
            // Arrange
            IReservatiePrijzing prijzing = new AirportReservatiePrijzing();
            DateTime date = DateTime.Now;
            Reservatie reservatie = new Reservatie(klant, "Gent", "Antwerpen", date, 2, limosine, ReservatieType.Airport, prijzing, 0, 10);
            // Act Assert
            Assert.AreEqual(170, reservatie.GetPrice());
        }
        [TestMethod]
        public void TestGetPriceWellnessReservatie()
        {
            // Arrange
            IReservatiePrijzing prijzing = new WellnessReservatiePrijzing();
            DateTime date = DateTime.Now;
            Reservatie reservatie = new Reservatie(klant, "Gent", "Antwerpen", date, 2, limosine, ReservatieType.Wellness, prijzing, 0, 10);
            // Act Assert
            Assert.AreEqual(210, reservatie.GetPrice());
        }
        [TestMethod]
        public void TestGetNightLifeReservatie()
        {
            // Arrange
            IReservatiePrijzing prijzing = new NightLifeReservatiePrijzing();
            DateTime date = DateTime.Now;
            Reservatie reservatie = new Reservatie(klant, "Gent", "Antwerpen", date, 2, limosine, ReservatieType.NightLife, prijzing, 1, 10);
            // Act Assert
            Assert.AreEqual(360, reservatie.GetPrice());
        }
        [TestMethod]
        public void TestGetWeddingReservatie()
        {
            // Arrange
            IReservatiePrijzing prijzing = new WeddingReservatiePrijzing();
            DateTime date = DateTime.Now;
            Reservatie reservatie = new Reservatie(klant, "Gent", "Antwerpen", date, 2, limosine, ReservatieType.Wedding, prijzing, 1, 10);
            // Act Assert
            Assert.AreEqual(280, reservatie.GetPrice());
        }
        [TestMethod]
        public void TestGetPriceMetVipKorting()
        {
            // Arrange
            Klant klant = new Klant() { Naam = "Gerrit", BTWNummer = "be1233552", KlantCategorie = Categorie.Vip, WoonAdres = "china" };
            IReservatiePrijzing prijzing = new BusinessReservatiePrijzing();
            DateTime date = DateTime.Now;
            Reservatie reservatie = new Reservatie(klant, "Gent", "Antwerpen", date, 2, limosine, ReservatieType.Business, prijzing, 0, 10);
            // Act Assert
            Assert.AreEqual(160, reservatie.GetPrice());
        }
        [TestMethod]
        public void TestGetPriceMetHuwelijksplannerKorting()
        {
            // Arrange
            Klant klant = new Klant() { Naam = "Gerrit", BTWNummer = "be1233552", KlantCategorie = Categorie.Huwelijksplanner, WoonAdres = "china" };
            IReservatiePrijzing prijzing = new BusinessReservatiePrijzing();
            DateTime date = DateTime.Now;
            Reservatie reservatie = new Reservatie(klant, "Gent", "Antwerpen", date, 2, limosine, ReservatieType.Business, prijzing, 0, 10);
            // Act Assert
            Assert.AreEqual(160, reservatie.GetPrice());
        }
        [TestMethod]
            public void TestGetReservatieInfo()
            {
                // Arrange
                IReservatiePrijzing prijzing = new BusinessReservatiePrijzing();
                DateTime date = new DateTime(2020,3,20);
                Reservatie reservatie = new Reservatie(klant, "Gent", "Antwerpen", date, 2, limosine, ReservatieType.Business, prijzing, 0, 10);
                UnitOfWork.GetUnitOfWork().Limosines.AddLimosine(limosine);
                UnitOfWork.GetUnitOfWork().Klanten.AddKlant(klant);
                UnitOfWork.GetUnitOfWork().Reservaties.AddReservatie(reservatie);
                UnitOfWork.GetUnitOfWork().Complete();
                ReservatieManager reservatieManager = new ReservatieManager(UnitOfWork.GetUnitOfWork());

                string text = $"Klant ID: {reservatie.KlantId}{Environment.NewLine}" +
                $"Klant naam: Gerrit{Environment.NewLine}" +
                $"Klant categorie: Concertpromotor{Environment.NewLine}" +
                $"Klant adres: china{Environment.NewLine}" +
                $"Klant BTW-nummer: be1233552{Environment.NewLine}" +
                $"Limosine ID: {reservatie.LimosineId}{Environment.NewLine}" +
                $"Limosine Naam: De naamloze limo{Environment.NewLine}" +
                $"Reservatie ID: {reservatie.Id}{Environment.NewLine}" +
                $"Reservatie begin: 20/03/2020 0:00:00{Environment.NewLine}" +
                $"Reservatie uren: 02:00:00{Environment.NewLine}" +
                $"Reservatie type: Business{Environment.NewLine}" +
                $"Reservatie vertrek: Antwerpen{Environment.NewLine}" +
                $"Reservatie aankomst: Gent{Environment.NewLine}" +
                $"Reservatie prijs: 170";
                // Act Assert
                Assert.IsTrue(text.Equals(reservatieManager.GetReservatieInfo(reservatie)), reservatieManager.GetReservatieInfo(reservatie) + text);
            }
    }
}
