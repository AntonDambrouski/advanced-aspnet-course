using MudBlazor;
using MoviesManager.Shared.DTOs;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace MovieManager.Client.Pages;

public partial class Movies
{
    [Inject]
    public HttpClient httpClient { get; set; }

    private MudTable<MovieDTO> tableRef;

    private string searchString = "";
    private MovieDTO? movieBeforeEdit = null;
    private List<MovieDTO> movies = new List<MovieDTO>();

    protected override async Task OnInitializedAsync()
    {
        //movies = await httpClient.GetFromJsonAsync<List<MovieDTO>>("api/movies");
    }

    private void BackupItem(object movie)
    {
        var originalMovie = (MovieDTO)movie;
        movieBeforeEdit = new()
        {
            Id = originalMovie.Id,
            Title = originalMovie.Title,
            Description = originalMovie.Description,
            ReleaseDate = originalMovie.ReleaseDate,
            Genre = originalMovie.Genre,
            Rating = originalMovie.Rating
        };
    }

    private async void ItemHasBeenCommitted(object movie)
    {
        var editedMovie = (MovieDTO)movie;
        if(editedMovie == null)
        {
            return;
        }

        try
        {
           var response = await httpClient.PutAsJsonAsync($"api/movies/{editedMovie.Id}", editedMovie);
        }
        catch (Exception)
        {
            ResetItemToOriginalValues(movie);
        }
    }

    private void ResetItemToOriginalValues(object movie)
    {
        var currentMovie = (MovieDTO)movie;
        if (movieBeforeEdit == null)
        {
            return;
        }

        currentMovie.Id = movieBeforeEdit.Id;
        currentMovie.Title = movieBeforeEdit.Title;
        currentMovie.Description = movieBeforeEdit.Description;
        currentMovie.ReleaseDate = movieBeforeEdit.ReleaseDate;
        currentMovie.Genre = movieBeforeEdit.Genre;
        currentMovie.Rating = movieBeforeEdit.Rating;
    }

    private async Task<TableData<MovieDTO>> ServerReload(TableState state, CancellationToken token)
    {
        IEnumerable<MovieDTO> data = await httpClient.GetFromJsonAsync<List<MovieDTO>>($"api/movies?searchTerm={searchString}&pageSize={state.PageSize}&page={state.Page}", token);
        data = data.Where(FilterFunc).ToArray();

        var totalItems = data.Count();
        switch (state.SortLabel)
        {
            case "id":
                data = data.OrderByDirection(state.SortDirection, o => o.Id);
                break;
            case "title":
                data = data.OrderByDirection(state.SortDirection, o => o.Title);
                break;
        }

        var pagedData = data.Skip(state.Page * state.PageSize).Take(state.PageSize).ToArray();
        return new TableData<MovieDTO>() { TotalItems = totalItems, Items = pagedData };
    }

    private void OnSearch(string text)
    {
        searchString = text;
        tableRef.ReloadServerData();
    }

    private bool FilterFunc(MovieDTO movie)
    {
        if (string.IsNullOrWhiteSpace(searchString))
            return true;
        if (movie.Title?.Contains(searchString, StringComparison.OrdinalIgnoreCase) ?? false)
            return true;
        if (movie.Description?.Contains(searchString, StringComparison.OrdinalIgnoreCase) ?? false)
            return true;
        return false;
    }
}
