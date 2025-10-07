using BusinessLogic.DTOs.ReviewDto;

namespace BusinessLogic.Interfaces
{
    public interface IReviewService
    {
        Task<IList<ReviewDto>> GetAll(string? Comment, string? UserName, string? MovieTitle, int pageNumber);
        Task<ReviewDto?> Get(int id);
        Task Create(CreateReviewDto model);
        Task Edit(EditReviewDto model);
        Task Delete(int id);
    }
}
