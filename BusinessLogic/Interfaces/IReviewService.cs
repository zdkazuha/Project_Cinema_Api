using BusinessLogic.DTOs.ReviewDto;

namespace BusinessLogic.Interfaces
{
    public interface IReviewService
    {
        IList<ReviewDto> GetAll();
        ReviewDto? Get(int id);
        void Create(CreateReviewDto model);
        void Edit(EditReviewDto model);
        void Delete(int id);
    }
}
