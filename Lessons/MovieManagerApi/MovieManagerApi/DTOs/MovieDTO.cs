﻿namespace MovieManagerApi.DTOs;

public class MovieDTO
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public string? PosterFileName { get; set; }
    public List<ReviewDTO> Reviews { get; set; } = [];
}
