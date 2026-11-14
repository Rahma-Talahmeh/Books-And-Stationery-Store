using BookStore_project.Core.Models;
using BookStore_project.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore_project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService reviewService;

        public ReviewController(IReviewService reviewService)
        {
            this.reviewService = reviewService;
        }

        [HttpGet]
        public List<Review> GetAllReviews()
        {
            return reviewService.GetAllReviews();
        }

        [HttpGet]
        [Route("getById/{id}")]
        public Review GetReviewById(decimal id)
        {
            return reviewService.GetReviewById(id);
        }

        [HttpPost]
        public void CreateReview(Review review)
        {
            reviewService.CreateReview(review);
        }

        [HttpPut]
        public void UpdateReview(Review review)
        {
            reviewService.UpdateReview(review);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public void DeleteReview(decimal id)
        {
            reviewService.DeleteReview(id);
        }

        [HttpGet]
        [Route("GetReviewsByProduct/{prodId}")]
        public List<Review> GetReviewsByProduct(decimal prodId)
        {
            return reviewService.GetReviewsByProduct(prodId);
        }
    }
}