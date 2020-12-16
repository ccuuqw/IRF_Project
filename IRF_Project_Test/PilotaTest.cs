using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using IRF_Project;
using IRF_Project.Entities;
using Moq;

namespace IRF_Project_Test
{
    public class PilotaTest
    {
        [
            Test,
            TestCase(25,3,0,0,true),
            TestCase(0, 17, 1, 0, true),
            TestCase(0, 17, 1, 1, false),
            TestCase(0,18,0,0,false)
        ]
        //true: felvesszük a pilotak listába
        //false: nem vesszük fel a listába
        public void TestValidatePilota(int pontszam, int legjobb, int egyeb, int szerzodes, bool expectedResult)
        {
            var pilota = new Pilota();
            var actualResult = pilota.ValidatePilota(pontszam, legjobb, egyeb, szerzodes);
            Assert.AreEqual(expectedResult, actualResult);
        }
        [
            Test,
            TestCase(1.5, 1, 1, 1.2, false),
            TestCase(0.8, 50, 1, 1, true),
            TestCase(1, 17, 1.3, 1, false),
            TestCase(1, 5, 1, 1.2, false)
        ]
        public void TestValidateVersenyzo(double kor, int pontszam, double tapasztalat, double nem, bool expectedResult)
        {
            var kateg = new Kategoria();
            var actualResult = kateg.ValidateVersenyzo(kor, pontszam, tapasztalat, nem);
            Assert.AreEqual(expectedResult, actualResult);
        }
        [
            Test,
            TestCase(1.5, 1, 1, 1.2, false),
            TestCase(0.8, 50, 1, 1, true),
            TestCase(1, 17, 1.3, 1, true),
            TestCase(1, 5, 1, 1.2, false)
        ]
        public void TestValidateTesztpilota(double kor, int pontszam, double tapasztalat, double nem, bool expectedResult)
        {
            var kateg = new Kategoria();
            var actualResult = kateg.ValidateTesztpilota(kor, pontszam, tapasztalat, nem);
            Assert.AreEqual(expectedResult, actualResult);
        }
        [
            Test,
            TestCase(1.5, 1, 1, 1.2, true),
            TestCase(0.8, 50, 1, 1, false),
            TestCase(1, 17, 1.3, 1, false),
            TestCase(1, 5, 1, 1.2, false)
        ]
        public void TestValidateJunior(double kor, int pontszam, double tapasztalat, double nem, bool expectedResult)
        {
            var kateg = new Kategoria();
            var actualResult = kateg.ValidateJunior(kor, pontszam, tapasztalat, nem);
            Assert.AreEqual(expectedResult, actualResult);
        }
        [
            Test,
            TestCase(1.5, 1, 1, 1.2, true),
            TestCase(0.8, 50, 1, 1, true),
            TestCase(1, 17, 1.3, 1, true),
            TestCase(1, 5, 1, 1.2, false)
        ]
        public void TestValidateKategoriak(double kor, int pontszam, double tapasztalat, double nem, bool expectedResult)
        {
            var kateg = new Kategoria();
            var actualResult = kateg.ValidateKategoriak(kor, pontszam, tapasztalat, nem);
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
