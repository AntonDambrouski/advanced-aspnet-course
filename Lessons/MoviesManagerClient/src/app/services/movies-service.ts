import { Injectable } from '@angular/core';
import { Movie } from '../interfaces/movie';

@Injectable({
  providedIn: 'root',
})
export class MoviesService {
  private movies: Movie[] = [
    {
      id: 1,
      title: 'Inception',
      genre: 'Sci-Fi',
      releaseDate: '2010-07-16',
      posterUrl:
        'https://m.media-amazon.com/images/I/81p+xe8cbnL._UF1000,1000_QL80_.jpg',
    },
    {
      id: 2,
      title: 'The Dark Knight',
      genre: 'Action',
      releaseDate: '2008-07-18',
      posterUrl: 'https://upload.wikimedia.org/wikipedia/en/8/81/Dark_Knight',
    },
    {
      id: 3,
      title: 'Interstellar',
      genre: 'Adventure',
      releaseDate: '2014-11-07',
      posterUrl:
        'https://upload.wikimedia.org/wikipedia/en/b/bc/Interstellar_film_poster.jpg',
    },
    {
      id: 4,
      title: 'The Matrix',
      genre: 'Sci-Fi',
      releaseDate: '1999-03-31',
      posterUrl:
        'https://upload.wikimedia.org/wikipedia/en/c/c1/The_Matrix_Poster.jpg',
    },
    {
      id: 5,
      title: 'Pulp Fiction',
      genre: 'Crime',
      releaseDate: '1994-10-14',
      posterUrl:
        'https://upload.wikimedia.org/wikipedia/en/8/88/Pulp_Fiction_cover.jpg',
    },
    {
      id: 6,
      title: 'The Shawshank Redemption',
      genre: 'Drama',
      releaseDate: '1994-09-23',
      posterUrl:
        'https://upload.wikimedia.org/wikipedia/en/8/81/ShawshankRedemptionMoviePoster.jpg',
    },
    {
      id: 7,
      title: 'Forrest Gump',
      genre: 'Drama',
      releaseDate: '1994-07-06',
      posterUrl:
        'https://upload.wikimedia.org/wikipedia/en/6/67/Forrest_Gump_poster.jpg',
    },
    {
      id: 8,
      title: 'The Godfather',
      genre: 'Crime',
      releaseDate: '1972-03-24',
      posterUrl:
        'https://upload.wikimedia.org/wikipedia/en/1/1c/Godfather_ver1.jpg',
    },
    {
      id: 9,
      title: 'Fight Club',
      genre: 'Drama',
      releaseDate: '1999-10-15',
      posterUrl:
        'https://upload.wikimedia.org/wikipedia/en/f/fc/Fight_Club_poster.jpg',
    },
    {
      id: 10,
      title: 'The Lord of the Rings: The Return of the King',
      genre: 'Fantasy',
      releaseDate: '2003-12-17',
      posterUrl:
        'https://upload.wikimedia.org/wikipedia/en/9/9b/The_Lord_of_the_Rings_The_Return_of_the_King.jpg',
    },
    {
      id: 11,
      title: 'Gladiator',
      genre: 'Action',
      releaseDate: '2000-05-05',
      posterUrl:
        'https://upload.wikimedia.org/wikipedia/en/8/8d/Gladiator_ver1.jpg',
    },
    {
      id: 12,
      title: 'The Silence of the Lambs',
      genre: 'Thriller',
      releaseDate: '1991-02-14',
      posterUrl:
        'https://upload.wikimedia.org/wikipedia/en/8/89/Silence_of_the_Lambs_poster.jpg',
    },
    {
      id: 13,
      title: "Schindler's List",
      genre: 'History',
      releaseDate: '1993-12-15',
      posterUrl:
        'https://upload.wikimedia.org/wikipedia/en/3/38/Schindler%27s_List_movie_poster.jpg',
    },
    {
      id: 14,
      title: 'The Social Network',
      genre: 'Biography',
      releaseDate: '2010-10-01',
      posterUrl:
        'https://upload.wikimedia.org/wikipedia/en/7/7a/Social_network_film_poster.jpg',
    },
    {
      id: 15,
      title: 'Parasite',
      genre: 'Thriller',
      releaseDate: '2019-05-30',
      posterUrl:
        'https://upload.wikimedia.org/wikipedia/en/5/53/Parasite_%282019_film%29.png',
    },
  ];

  constructor() {}

  getMovies(): Movie[] {
    return this.movies.slice();
  }
}
