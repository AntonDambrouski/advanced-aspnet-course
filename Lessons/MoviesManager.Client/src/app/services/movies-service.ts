import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Movie } from '../models/movie';
import { Review } from '../models/review';

@Injectable({
  providedIn: 'root',
})
export class MoviesService {
  private readonly baseUrl = 'https://localhost:7079/api/movies';
  private readonly httpClient = inject(HttpClient);

  getMovies() {
    return this.httpClient.get<Movie[]>(`${this.baseUrl}`);
  }

  getMovieById(id: number) {
    return this.httpClient.get<Movie>(`${this.baseUrl}/${id}`);
  }

  getMovieReviews(movieId: number) {
    return this.httpClient.get<Review[]>(`${this.baseUrl}/${movieId}/reviews`);
  }
}
