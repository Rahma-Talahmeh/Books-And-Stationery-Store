using BooksAndStationeryStore_Project.Core.Models;
using BooksAndStationeryStore_Project.Core.Repository;
using BooksAndStationeryStore_Project.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAndStationeryStore_Project.Infra.Service
{
   public class PublisherService :IPublisherService
    {
        private readonly IPublisherRepository publisherRepository;

        public PublisherService(IPublisherRepository _publisherRepository)
        {
            publisherRepository = _publisherRepository;
        }

        public List<Publisher> GetAllPublishers()
        {
            return publisherRepository.GetAllPublishers();
        }

        public Publisher GetPublisherById(int id)
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

        public void DeletePublisher(int id)
        {
            publisherRepository.DeletePublisher(id);
        }
    }
}
