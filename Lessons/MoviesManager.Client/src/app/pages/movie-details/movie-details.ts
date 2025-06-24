import { CommonModule } from '@angular/common';
import { Component, inject, OnInit, signal } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { Movie } from '../../models/movie';
import { Review } from '../../models/review';
import { MoviesService } from '../../services/movies-service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-movie-details',
  imports: [CommonModule, MatCardModule],
  templateUrl: './movie-details.html',
  styleUrl: './movie-details.css',
})
export class MovieDetails implements OnInit {
  private readonly movieService = inject(MoviesService);
  private readonly route = inject(ActivatedRoute);

  movie = signal<Movie>({} as Movie);

  ngOnInit(): void {
    const movieId = Number(this.route.snapshot.paramMap.get('id'));
    this.movieService.getMovieById(movieId).subscribe((res) => {
      this.movie.set(res);
    });
  }
}
