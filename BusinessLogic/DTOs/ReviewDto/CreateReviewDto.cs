namespace BusinessLogic.DTOs.ReviewDto
{
    public class CreateReviewDto
    {
        public string Comment { get; set; }

        public int MovieId { get; set; }

        public string UserId { get; set; }
    }
}
