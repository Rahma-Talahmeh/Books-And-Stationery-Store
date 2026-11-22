using BooksAndStationeryStore_Project.Core.Models;
using BooksAndStationeryStore_Project.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksAndStationeryStore_Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService publisherService;

        public PublisherController(IPublisherService _publisherService)
        {
            publisherService = _publisherService;
        }

        [HttpGet]
        public List<Publisher> GetAllPublishers()
        {
            return publisherService.GetAllPublishers();
        }

        [HttpPost]
        public void CreatePublisher(Publisher publisher)
        {
            publisherService.CreatePublisher(publisher);
        }

        [HttpPut]
        [Route("Update/{id}")]
        public void UpdatePublisher(Publisher publisher)
        {
            publisherService.UpdatePublisher(publisher);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public void DeletePublisher(int id)
        {
            publisherService.DeletePublisher(id);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public Publisher GetPublisherById(int id)
        {
            return publisherService.GetPublisherById(id);
        }
    }
}
