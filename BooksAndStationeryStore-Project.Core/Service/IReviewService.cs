using BooksAndStationeryStore_Project.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAndStationeryStore_Project.Core.Service
{
    public interface IReviewService
    {
        List<Review> GetAllReviews();
        Review GetReviewById(int id);
        void CreateReview(Review review);
        void UpdateReview(Review review);
        void DeleteReview(int id);
        List<Review> GetReviewsByProduct(int prodId);
    }
}
