using BooksAndStationeryStore_Project.Core.Models;
using BooksAndStationeryStore_Project.Core.Service;
using BooksAndStationeryStore_Project.Infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksAndStationeryStore_Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService reviewService; 

        public ReviewController(IReviewService _reviewService) 
        {
            reviewService = _reviewService;
        }

        [HttpGet]
        public List<Review> GetAllReviews()
        {
            return reviewService.GetAllReviews();
        }

        [HttpPost]
        public void CreateReview(Review review)
        {
            reviewService.CreateReview(review);
        }

        [HttpPut]
        [Route("Update/{id}")]
        public void UpdateReview(Review review)
        {
            reviewService.UpdateReview(review);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public void DeleteReview(int id)
        {
            reviewService.DeleteReview(id);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public Review GetReviewById(int id)
        {
            return reviewService.GetReviewById(id);
        }

        [HttpGet]
        [Route("GetByProduct/{prodId}")]
        public List<Review> GetReviewsByProduct(int prodId)
        {
            return reviewService.GetReviewsByProduct(prodId);
        }
    }
}
