using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PairProgramming.model;

namespace PairRest.Controllers
{
    [Route("api/Record")]
    [ApiController]
    public class MRecordController : ControllerBase
    {

        public static List<MRecord> records = new List<MRecord>()
        {
            new MRecord("123456789", "Prince", "Be I G", "3:16", 1981, "BG Records"),
            new MRecord("234567891", "Nickelback", "Humpy", "3:00", 2010, "OP Records"),
            new MRecord("345678912", "Nickelback", "Pictures", "9:59", 2018, "PO Records"),
            new MRecord("456789123", "Metallica", "We be old", "5:16", 2019, "OP Records")
        };
        // GET: api/MRecord
        [HttpGet]
        public IEnumerable<MRecord> Get()
        {
            return records;
        }

        [HttpGet]
        [Route("SearchTitle/{substring}")]
        public IEnumerable<MRecord> GetFromSubstringTitle(string substring)
        {
            return records.FindAll(record => record.Title.ToLower().Contains(substring.ToLower()));

        }

        [HttpGet]
        [Route("SearchArtist/{substring}")]
        public IEnumerable<MRecord> GetFromSubstringArtist(string substring)
        {
            return records.FindAll(record => record.Artist.ToLower().Contains(substring.ToLower()));

        }

        [HttpGet]
        [Route("SearchPublisher/{substring}")]
        public IEnumerable<MRecord> GetFromSubstringPublisher(string substring)
        {
            return records.FindAll(record => record.Publisher.ToLower().Contains(substring.ToLower()));

        }

        [HttpGet]
        [Route("SearchYearOP/{substring}")]
        public IEnumerable<MRecord> GetFromSubstringYearOP(int substring)
        {
            return records.FindAll(record => record.YearOPub.Equals(substring));

        }



        // GET: api/MRecord/5
        [HttpGet("{id}", Name = "Get")]
        public MRecord Get(string id)
        {
            return records.Find(r => r.Id == id);
        }

        // POST: api/MRecord
        [HttpPost]
        public void Post([FromBody] MRecord value)
        {
            if (records.Find(record => record.Id == value.Id) == null)
            {
                records.Add(value);
            }
            else
            {
                throw new ArgumentException("Bollocks");
            }
        }

        // PUT: api/MRecord/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] MRecord value)
        {
            MRecord record = Get(id);
            if (record != null)
            {
                record.Id = value.Id;
                record.Title = value.Title;
                record.Artist = value.Artist;
                record.Duration = value.Duration;
                record.Publisher = value.Publisher;
                record.YearOPub = value.YearOPub;
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            MRecord record = Get(id);
            if (record != null)
            {
                records.Remove(record);
            }
        }
    }
}
