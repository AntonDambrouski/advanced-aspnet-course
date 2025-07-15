import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Movie } from '../models/movie';
import { Review } from '../models/review';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class MoviesService {
  private readonly httpClient = inject(HttpClient);

  getMovies() {
    return this.httpClient.get<Movie[]>(`${environment.apiUrl}/movies`);
  }

  getMovieById(id: number) {
    return this.httpClient.get<Movie>(`${environment.apiUrl}/movies/${id}`);
  }

  getMovieReviews(movieId: number) {
    return this.httpClient.get<Review[]>(
      `${environment.apiUrl}/movies/${movieId}/reviews`
    );
  }

  addMovie(movie: Movie) {
    return this.httpClient.post<Movie>(`${environment.apiUrl}/movies`, movie);
  }

  updateMovie(movie: Movie, id: number) {
    return this.httpClient.put<Movie>(
      `${environment.apiUrl}/movies/${id}`,
      movie
    );
  }

  deleteMovie(id: number) {
    return this.httpClient.delete<void>(`${environment.apiUrl}/movies/${id}`);
  }

  uploadPoster(movieId: number, file: File) {
    const formData = new FormData();
    formData.append('file', file);
    return this.httpClient.post(
      `${environment.apiUrl}/movies/${movieId}/upload-poster`,
      formData
    );
  }
}
