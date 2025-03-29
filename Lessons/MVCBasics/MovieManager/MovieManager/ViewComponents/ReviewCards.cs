using Microsoft.AspNetCore.Mvc;
using MovieManager.Services;

namespace MovieManager.ViewComponents;

public class ReviewCards : ViewComponent
{
    private readonly IReviewManagerService _reviewManagerService;

    public ReviewCards(IReviewManagerService reviewManagerService)
    {
        _reviewManagerService = reviewManagerService;
    }

    public Task<IViewComponentResult> InvokeAsync(int movieId)
    {
        var reviews = _reviewManagerService.GetReviewsByMovieId(movieId);
        var componentName = "Default";
        if (reviews.Count == 0)
        {
            componentName = "Empty";
        }

        return Task.FromResult((IViewComponentResult)View(reviews));
    }
}
