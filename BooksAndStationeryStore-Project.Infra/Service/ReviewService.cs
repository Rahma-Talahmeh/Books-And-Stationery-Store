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
    public class ReviewService: IReviewService
    {
        private readonly IReviewRepository reviewRepository;

        public ReviewService(IReviewRepository _reviewRepository)
        {
            reviewRepository = _reviewRepository;
        }

        public List<Review> GetAllReviews()
        {
            return reviewRepository.GetAllReviews();
        }

        public Review GetReviewById(int id)
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

        public void DeleteReview(int id)
        {
            reviewRepository.DeleteReview(id);
        }

        public List<Review> GetReviewsByProduct(int prodId)
        {
            return reviewRepository.GetReviewsByProduct(prodId);
        }
    }
}
