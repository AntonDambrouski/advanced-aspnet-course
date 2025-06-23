import { Component, input } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { Movie } from '../../interfaces/movie';
import { DatePipe, NgOptimizedImage, UpperCasePipe } from '@angular/common';

@Component({
  selector: 'app-movies-card',
  imports: [
    MatButtonModule,
    MatCardModule,
    UpperCasePipe,
    DatePipe,
    NgOptimizedImage,
  ],
  templateUrl: './movies-card.html',
  styleUrl: './movies-card.css',
})
export class MoviesCard {
  movie = input<Movie>();
}
