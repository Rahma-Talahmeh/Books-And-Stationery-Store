using Microsoft.AspNetCore.Mvc;

using BookStore_project.Core.Models;
using BookStore_project.Core.Services;


namespace BookStore_project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            this.publisherService = publisherService;
        }

        [HttpGet]
        public List<Publisher> GetAllPublishers()
        {
            return publisherService.GetAllPublishers();
        }

        [HttpGet]
        [Route("getById/{id}")]
        public Publisher GetPublisherById(decimal id)
        {
            return publisherService.GetPublisherById(id);
        }

        [HttpPost]
        public void CreatePublisher(Publisher publisher)
        {
            publisherService.CreatePublisher(publisher);
        }

        [HttpPut]
        public void UpdatePublisher(Publisher publisher)
        {
            publisherService.UpdatePublisher(publisher);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public void DeletePublisher(decimal id)
        {
            publisherService.DeletePublisher(id);
        }
    }
}