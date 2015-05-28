using System;
using System.Linq;
using Localiser;
using NUnit.Framework;
using PharrellAPI;
using RegionLoader;

namespace UnitTestProject
{
    [TestFixture]
    public class LocaliserTests
    {
        public SpatialHelper Sut { get; set; }

        [SetUp]
        public void Init()
        {
            // Arrange
            Sut = new SpatialHelper();            
        }

        [Test]
        public void Localiser_Exists()
        {
            // Act
            var actual = Sut.GetType();

            // Assert
            Assert.That(actual, Is.Not.Null);
        }

        [Test]
        public void PointInPolygon_Exists()
        {
            // Act
            Type actual = Sut.GetType();

            // Assert
            Assert.That(actual.GetMethod("PointInPolygon"), Is.Not.Null);
        }

        [Test]
        public void PointInPolygon_Returns_True_If_Point_Inside_Polygon()
        {
            // Arrange
            var db = new HiDbContext();

            // Willis Street-Cambridge Terrace
            Region region = db.Regions.Single(r => r.AU12 == 573101);

            //var tePapa = SqlGeography.STPointFromText(new SqlChars("POINT(-41.290272 174.781982)"), 4326);
            double tePapaLat = 174.781982;
            double tePapaLong = -41.290272;
            bool expected = true;

            // Act
            bool actual = Sut.PointInPolygon(region, tePapaLat, tePapaLong);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void PointInPolygon_Returns_False_If_Point_Outside_Polygon()
        {
            // Arrange
            var db = new HiDbContext();

            // Willis Street-Cambridge Terrace
            Region region = db.Regions.Single(r => r.AU12 == 573101);

            double eiffelTowerLat = 2.2945;
            double eiffelTowerLong = 48.8582;

            bool expected = false;

            // Act
            bool actual = Sut.PointInPolygon(region, eiffelTowerLat, eiffelTowerLong);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void PointInPolygon_Returns_False_If_Point_Adjacent_To_Polygon()
        {
            // Arrange
            var db = new HiDbContext();

            // Kelburn
            Region region = db.Regions.Single(r => r.AU12 == 575300);

            double beehiveLat = 174.7767;
            double beehiveLong = -41.2784;

            bool expected = false;

            // Act
            bool actual = Sut.PointInPolygon(region, beehiveLat, beehiveLong);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }


    }
}