using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BookStore_project.Core.Models;
using BookStore_project.Core.Repository;
using BookStore_project.Core.Services;

namespace BookStore_project.Infra.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository publisherRepository;

        public PublisherService(IPublisherRepository publisherRepository)
        {
            this.publisherRepository = publisherRepository;
        }

        public List<Publisher> GetAllPublishers()
        {
            return publisherRepository.GetAllPublishers();
        }

        public Publisher GetPublisherById(decimal id)
        {
            return publisherRepository.GetPublisherById(id);
        }

        public void CreatePublisher(Publisher publisher)
        {
            publisherRepository.CreatePublisher(publisher);
        }

        public void UpdatePublisher(Publisher publisher)
        {
            publisherRepository.UpdatePublisher(publisher);
        }

        public void DeletePublisher(decimal id)
        {
            publisherRepository.DeletePublisher(id);
        }
    }
}