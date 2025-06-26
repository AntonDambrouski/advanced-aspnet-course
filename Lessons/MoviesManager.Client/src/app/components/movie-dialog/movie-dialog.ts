import { Component, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import {
  MAT_DIALOG_DATA,
  MatDialogModule,
  MatDialogRef,
} from '@angular/material/dialog';
import { MatLabel, MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { Movie } from '../../models/movie';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-movie-dialog',
  imports: [
    CommonModule,
    MatDialogModule,
    MatLabel,
    MatFormFieldModule,
    ReactiveFormsModule,
    MatInputModule,
  ],
  templateUrl: './movie-dialog.html',
  styleUrl: './movie-dialog.css',
})
export class MovieDialog {
  private readonly fb = inject(FormBuilder);
  private dialogRef = inject(MatDialogRef<MovieDialog>);
  movie: Movie | null = inject(MAT_DIALOG_DATA);

  movieForm = this.fb.group({
    title: [this.movie?.title ?? '', Validators.required],
    description: [this.movie?.description ?? '', Validators.required],
    genre: [this.movie?.genre ?? '', Validators.required],
  });

  saveMovie() {
    this.dialogRef.close(this.movieForm.value);
  }

  cancelForm() {
    this.dialogRef.close(null);
  }
}
