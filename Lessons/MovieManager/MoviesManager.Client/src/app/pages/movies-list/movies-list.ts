import { CommonModule } from '@angular/common';
import { Component, inject, OnInit, signal } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { RouterModule } from '@angular/router';
import { Movie } from '../../models/movie';
import { MoviesService } from '../../services/movies-service';
import { environment } from '../../../environments/environment';
import { ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import { MovieDialog } from '../../components/movie-dialog/movie-dialog';

@Component({
  selector: 'app-movies-list',
  imports: [
    CommonModule,
    MatCardModule,
    MatButtonModule,
    RouterModule,
    MatDialogModule,
    MatFormFieldModule,
    ReactiveFormsModule,
    MatInputModule,
  ],
  templateUrl: './movies-list.html',
  styleUrl: './movies-list.css',
})
export class MoviesList implements OnInit {
  movies = signal<Movie[]>([]);
  private readonly moviesService = inject(MoviesService);

  readonly dialog = inject(MatDialog);

  editingMovie: Movie | null = null;
  formVisible = false;

  ngOnInit(): void {
    this.moviesService.getMovies().subscribe((res) => this.movies.set(res));
  }

  GetPosterUrl(posterFileName: string): string {
    return `${environment.posterBaseUrl}/${posterFileName}`;
  }

  onFileSelected(event: Event, movieId: number) {
    var fileInput = event.target as HTMLInputElement;
    if (fileInput.files && fileInput.files.length > 0) {
      const file = fileInput.files[0];
      if (file) {
        this.moviesService
          .uploadPoster(movieId, file)
          .subscribe((_) => this.fetchMovies());
      }
    }
  }

  fetchMovies() {
    this.moviesService.getMovies().subscribe((res) => this.movies.set(res));
  }

  editMovie(movie: Movie) {
    this.editingMovie = movie;
    this.openDialog(movie);
  }

  saveMovie(movie: Movie | null) {
    if (this.editingMovie) {
      this.moviesService
        .updateMovie(movie as Movie, this.editingMovie.id)
        .subscribe(() => {
          this.fetchMovies();
          this.editingMovie = null;
        });
    } else {
      this.moviesService.addMovie(movie as Movie).subscribe(() => {
        this.fetchMovies();
      });
    }
  }

  cancelForm() {
    this.editingMovie = null;
  }

  deleteMovie(movieId: number) {
    this.moviesService.deleteMovie(movieId).subscribe(() => {
      this.fetchMovies();
    });
  }

  openCreateForm() {
    this.openDialog(null);
  }

  openDialog(movie: Movie | null): void {
    const dialogRef = this.dialog.open(MovieDialog, {
      data: movie,
      maxWidth: '700px',
    });

    dialogRef.afterClosed().subscribe((result) => {
      console.log('The dialog was closed');
      if (result) {
        this.saveMovie(result);
      }
    });
  }
}
