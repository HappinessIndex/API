using System;
using System.Linq;
using SpatialHelpers;
using NUnit.Framework;
using PharrellAPI;
using PharrellAPI.Models;

namespace UnitTestProject
{
    [TestFixture]
    public class LocaliserTests
    {
        private Localiser _sut;
        private HiDbContext _db;

        [SetUp]
        public void Init()
        {
            // Arrange
            this._sut = new Localiser();            
            this._db = new HiDbContext();
        }

        [Test]
        public void Localiser_Exists()
        {
            // Act
            var actual = _sut.GetType();

            // Assert
            Assert.That(actual, Is.Not.Null);
        }

        [Test]
        public void PointInPolygon_Exists()
        {
            // Act
            Type actual = _sut.GetType();

            // Assert
            Assert.That(actual.GetMethod("PointInPolygon"), Is.Not.Null);
        }

        [Test]
        public void PointInPolygon_Returns_True_If_Point_Inside_Polygon()
        {
            // Arrange
            Region willisStreet = _db.Regions.Single(r => r.AU12 == 573101);
            double tePapaLat = 174.781982;
            double tePapaLong = -41.290272;
            bool expected = true;

            // Act
            bool actual = _sut.PointInPolygon(willisStreet, tePapaLat, tePapaLong);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void PointInPolygon_Returns_False_If_Point_Outside_Polygon()
        {
            // Arrange
            Region willisStreet = _db.Regions.Single(r => r.AU12 == 573101);
            double eiffelTowerLat = 2.2945;
            double eiffelTowerLong = 48.8582;
            bool expected = false;

            // Act
            bool actual = _sut.PointInPolygon(willisStreet, eiffelTowerLat, eiffelTowerLong);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void PointInPolygon_Returns_False_If_Point_Adjacent_To_Polygon()
        {
            // Arrange
            Region kelburn = _db.Regions.Single(r => r.AU12 == 575300);
            double beehiveLat = 174.7767;
            double beehiveLong = -41.2784;
            bool expected = false;

            // Act
            bool actual = _sut.PointInPolygon(kelburn, beehiveLat, beehiveLong);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Region_HAS_MANY_Sentiments()
        {
            var regionType = typeof (Region);
            Assert.That(regionType.GetProperty("Sentiments"), Is.Not.Null);
        }
    }
}