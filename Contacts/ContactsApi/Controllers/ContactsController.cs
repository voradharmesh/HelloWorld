using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContactsModels;
using System.Globalization;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactsApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class GenericController<T> : ControllerBase where T : class
    {
        protected internal List<T> modelList;
        public GenericController():base()
        {

        }

        // GET: api/<ContactsController>
        [HttpGet]
        public IEnumerable<T> Get()
        {
            return modelList;
        }

        // GET api/<ContactsController>/5
        [HttpGet("{id}")]
        public T Get(int id)
        {
            return modelList[0];
        }

        // POST api/<ContactsController>
        [HttpPost]
        public void Post([FromBody] T entity)
        {
        }

        // PUT api/<ContactsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] T entity)
        {
        }

        // DELETE api/<ContactsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }

    public class BookController : GenericController<Book>
    {
        public BookController() : base()
        {
            modelList = new List<Book> { new Book { Id = 1, Name = "Test" } };
        }
    }

    public class AlbumController : GenericController<Album>
    {
        public AlbumController() : base()
        {
            modelList = new List<Album> { new Album { Id = 1, Name = "Test" } };
        }
    }

    public class ContactsController : GenericController<Contact>
    {
        public ContactsController() : base()
        {
            modelList = new List<Contact>
            {
                new Contact{ ContactId=1, DateOfBirth=DateTime.Today.AddYears(-45), FristName="Test1FirstName", LastName="Test1LastName", MiddleName="Test1MiddleName", Email="Test1@contactsdomain.com", Gender=1}
                , new Contact{ ContactId=1, DateOfBirth=DateTime.Today.AddYears(-40), FristName="Test2FirstName", LastName="Test2LastName", MiddleName="Test2MiddleName", Email="Test2@contactsdomain.com", Gender=2}
            };
        }

    }


}
