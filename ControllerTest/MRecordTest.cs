using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PairProgramming.model;
using PairRest.Controllers;


namespace ControllerTest
{
    [TestClass]
    public class MRecordTest
    {

        private static MRecordController _controller;
        private MRecord testDelete;
        private MRecord testPut;
        

        [TestInitialize]
        public void Init()
        {
            _controller = new MRecordController();
            testDelete = new MRecord("919191919", "test", "test", "1:00", 1999, "OP");
            _controller.Post(testDelete);
            testPut = new MRecord("919191911", "GokWan", "test", "1:00", 1999, "PP");
            _controller.Post(testPut);
        }

        [TestCleanup]
        public void After()
        {
            _controller.Delete("919191919");
            _controller.Delete("919191911");
            _controller.Delete("919191918");
            _controller.Delete("191919191");
        }
        

        [TestMethod]
        public void TestGet()
        {
            //Assert.AreEqual(5, _controller.Get().Count());
            int length = _controller.Get().Count();
            MRecord temp = new MRecord("191919191", "temp", "temp", "1:44", 521, "temp");
            _controller.Post(temp);
            int newlength = _controller.Get().Count();
            Assert.AreNotEqual(length, newlength);
        }

        [TestMethod]
        public void GetIdTest()
        {
            MRecord testRecord = _controller.Get("919191911");
            Assert.AreEqual("GokWan", testRecord.Artist);
        }

        [TestMethod]
        public void PostTest()
        {
            MRecord added = new MRecord("919191918", "steve", "kek", "2:30", 1993, "testPub");
            int amount = _controller.Get().Count();
            _controller.Post(added);
            Assert.AreNotEqual(amount, _controller.Get().Count());
            MRecord getVal = _controller.Get("919191918");
            Assert.AreEqual(added.Id, getVal.Id);
        }

        [TestMethod]
        public void PutTest()
        {
            MRecord old = _controller.Get("919191911");
            MRecord altered =  new MRecord("919191911", "GokWan", "Popo", "20:12",1999,"TEST");
            _controller.Put("919191911", altered);
            MRecord newRecord = _controller.Get("919191911");
            Assert.AreEqual("Popo", newRecord.Title);
        }

        [TestMethod]
        public void DeleteTest()
        {
            int length = _controller.Get().Count();
            //MRecord testRecord = _controller.Get("919191919");
            //Assert.AreEqual("test", testRecord.Title);
            _controller.Delete("919191919");
            //Thread.Sleep(5000);
            int newlength = _controller.Get().Count();
            //MRecord testRecord2 = _controller.Get("919191919");
            Assert.AreNotEqual(length, newlength);
        }

        //[TestMethod]
        //public void SearchTest()
        //{
        //    IEnumerable<MRecord> artistList = _controller.GetFromSubstringArtist("nickel"); //2
        //    IEnumerable<MRecord> titleList = _controller.GetFromSubstringTitle("we be"); //1
        //    IEnumerable<MRecord> publisherList = _controller.GetFromSubstringPublisher("OP reco"); //2
        //    IEnumerable<MRecord> yopList = _controller.GetFromSubstringYearOP(2010); //1

        //    Assert.AreEqual(artistList.Count(), 2);
        //    Assert.AreEqual(titleList.Count(), 1);
        //    Assert.AreEqual(publisherList.Count(), 2);
        //    Assert.AreEqual(yopList.Count(), 1);
        //}

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
