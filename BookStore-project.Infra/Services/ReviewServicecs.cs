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
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            this.reviewRepository = reviewRepository;
        }

        public List<Review> GetAllReviews()
        {
            return reviewRepository.GetAllReviews();
        }

        public Review GetReviewById(decimal id)
        {
            return reviewRepository.GetReviewById(id);
        }

        public void CreateReview(Review review)
        {
            reviewRepository.CreateReview(review);
        }

        public void UpdateReview(Review review)
        {
            reviewRepository.UpdateReview(review);
        }

        public void DeleteReview(decimal id)
        {
            reviewRepository.DeleteReview(id);
        }

        public List<Review> GetReviewsByProduct(decimal prodId)
        {
            return reviewRepository.GetReviewsByProduct(prodId);
        }
    }
}