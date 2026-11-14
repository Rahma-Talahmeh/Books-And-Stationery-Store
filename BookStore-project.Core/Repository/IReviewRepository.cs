using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BookStore_project.Core.Models;

namespace BookStore_project.Core.Repository
{
    public interface IReviewRepository
    {
        List<Review> GetAllReviews();
        Review GetReviewById(decimal id);
        void CreateReview(Review review);
        void UpdateReview(Review review);
        void DeleteReview(decimal id);
        List<Review> GetReviewsByProduct(decimal prodId);
    }
}
