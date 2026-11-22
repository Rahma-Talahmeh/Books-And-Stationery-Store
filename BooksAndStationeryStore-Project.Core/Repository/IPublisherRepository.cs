using BooksAndStationeryStore_Project.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAndStationeryStore_Project.Core.Repository
{
    public interface IPublisherRepository
    {
        List<Publisher> GetAllPublishers();
        Publisher GetPublisherById(int id);
        void CreatePublisher(Publisher publisher);
        void UpdatePublisher(Publisher publisher);
        void DeletePublisher(int id);
    }
}
