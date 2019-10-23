using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PairProgramming.model;
using PairRest.Controllers;


namespace ControllerTest
{
    [TestClass]
    public class MRecordTest
    {

        private static MRecordController _controller;


        [TestInitialize]
        public void Init()
        {
            _controller = new MRecordController();
        }

        [TestMethod]
        public void TestGet()
        {
            Assert.AreEqual(4, _controller.Get().Count());
        }

        [TestMethod]
        public void GetIdTest()
        {
            MRecord testRecord = _controller.Get("123456789");
            Assert.AreEqual(testRecord.Title, "Be I G");
        }

        [TestMethod]
        public void PostTest()
        {
            MRecord added = new MRecord("456328795", "steve", "kek", "2:30", 1993, "testPub");
            int amount = _controller.Get().Count();
            _controller.Post(added);
            Assert.AreNotEqual(amount, _controller.Get().Count());
            MRecord getVal = _controller.Get("456328795");
            Assert.AreEqual(added, getVal);
        }

        [TestMethod]
        public void PutTest()
        {
            MRecord old = _controller.Get("234567891");
            MRecord altered =  new MRecord("234567891", "TEST", "TEST", "20:12",1999,"TEST");
            _controller.Put("234567891", altered);
            MRecord newRecord = _controller.Get("234567891");
            Assert.AreEqual("TEST", newRecord.Title);
        }

        [TestMethod]
        public void DeleteTest()
        {
            MRecord testRecord = _controller.Get("123456789");
            Assert.AreEqual(testRecord.Title, "Be I G");
            _controller.Delete("123456789");
            MRecord testRecord2 = _controller.Get("123456789");
            Assert.AreEqual(testRecord2, null);
        }

        [TestMethod]
        public void SearchTest()
        {
            IEnumerable<MRecord> artistList = _controller.GetFromSubstringArtist("nickel"); //2
            IEnumerable<MRecord> titleList = _controller.GetFromSubstringTitle("we be"); //1
            IEnumerable<MRecord> publisherList = _controller.GetFromSubstringPublisher("OP reco"); //2
            IEnumerable<MRecord> yopList = _controller.GetFromSubstringYearOP(2010); //1

            Assert.AreEqual(artistList.Count(), 2);
            Assert.AreEqual(titleList.Count(), 1);
            Assert.AreEqual(publisherList.Count(), 2);
            Assert.AreEqual(yopList.Count(), 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullTestArtist()
        {
            MRecord record1 = new MRecord("123456781","Henrik Nielsen", "IDK", "3:40", 2019, "IP Records");
            Assert.AreEqual(record1.Artist, "Henrik Nielsen");
            MRecord record = new MRecord("123456781",null,"IDK","3:40",2019,"IP Records");
            _controller.Put("123456789", record);
            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullTestTitle()
        {
            MRecord record1 = new MRecord("123456781", "Henrik Nielsen", "Henrik Nielsen", "3:40", 2019, "IP Records");
            Assert.AreEqual(record1.Title, "Henrik Nielsen");
            MRecord record = new MRecord("123456781","Henrik Nielsen", null, "3:40", 2019, "IP Records");
            _controller.Put("123456789", record);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullTestId()
        {
            MRecord record1 = new MRecord("123456781", "Henrik Nielsen", "Henrik Nielsen", "3:40", 2019, "IP Records");
            Assert.AreEqual(record1.Id, "123456781");
            MRecord record = new MRecord(null, "Henrik Nielsen", "IDK", "3:40", 2019, "IP Records");
            _controller.Put("123456789", record);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullTestPublisher()
        {
            MRecord record1 = new MRecord("123456781", "Henrik Nielsen", "Henrik Nielsen", "3:40", 2019, "IP Records");
            Assert.AreEqual(record1.Publisher, "IP Records");
            MRecord record = new MRecord("123456781", "Henrik Nielsen", "IDK", "3:40", 2019, null);
            _controller.Put("123456789", record);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullTestDuration()
        {
            MRecord record1 = new MRecord("123456781", "Henrik Nielsen", "Henrik Nielsen", "3:40", 2019, "IP Records");
            Assert.AreEqual(record1.Duration, "3:40");
            MRecord record = new MRecord("123456781", "Henrik Nielsen", "IDK", null, 2019, "IP Records");
            _controller.Put("123456789", record);
        }

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void NullTestYearOP()
        //{
        //    MRecord record1 = new MRecord("123456781", "Henrik Nielsen", "Henrik Nielsen", "3:40", 2019, "IP Records");
        //    Assert.AreEqual(record1.YearOPub, 2019);
        //    MRecord record = new MRecord("123456781", "Henrik Nielsen", "IDK", "3:40", null, "IP Records");
        //    _controller.Put("123456789", record);
        //}

    }
}
