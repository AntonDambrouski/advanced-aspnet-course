import {
  AfterViewInit,
  Component,
  inject,
  OnInit,
  ViewChild,
} from '@angular/core';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { Movie } from '../interfaces/movie';
import { MoviesService } from '../services/movies-service';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MoviesCard } from './movies-card/movies-card';

@Component({
  selector: 'app-movies-table',
  imports: [MatPaginatorModule, MatTableModule, MatSortModule, MoviesCard],
  templateUrl: './movies-table.html',
  styleUrl: './movies-table.css',
})
export class MoviesTable implements OnInit, AfterViewInit {
  moviesService = inject(MoviesService);
  dataSource!: MatTableDataSource<Movie>;
  displayedColumns: string[] = ['id', 'title', 'genre', 'releaseDate'];
  selectedMovie?: Movie;

  ngOnInit(): void {
    let movies = this.moviesService.getMovies();
    this.dataSource = new MatTableDataSource<Movie>(movies);
  }

  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  onMovieSelect(movie: Movie) {
    this.selectedMovie = movie;
  }
}
