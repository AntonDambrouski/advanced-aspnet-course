import { CommonModule } from '@angular/common';
import { Component, inject, OnInit, signal } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { RouterModule } from '@angular/router';
import { Movie } from '../../models/movie';
import { MoviesService } from '../../services/movies-service';

@Component({
  selector: 'app-movies-list',
  imports: [CommonModule, MatCardModule, MatButtonModule, RouterModule],
  templateUrl: './movies-list.html',
  styleUrl: './movies-list.css',
})
export class MoviesList implements OnInit {
  movies = signal<Movie[]>([]);
  private readonly moviesService = inject(MoviesService);

  ngOnInit(): void {
    this.moviesService.getMovies().subscribe((res) => this.movies.set(res));
  }
}
