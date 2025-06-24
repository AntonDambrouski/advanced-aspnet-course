import { Routes } from '@angular/router';
import { Home } from './pages/home/home';
import { Login } from './pages/login/login';
import { MoviesList } from './pages/movies-list/movies-list';
import { MovieDetails } from './pages/movie-details/movie-details';
import { authenticatedGuard } from './guards/authenticated-guard';

export const routes: Routes = [
  {
    path: '',
    component: Home,
  },
  {
    path: 'login',
    component: Login,
    canActivate: [],
  },
  {
    path: 'movies',
    component: MoviesList,
    canActivate: [authenticatedGuard],
  },
  {
    path: 'movies/:id',
    component: MovieDetails,
    canActivate: [authenticatedGuard],
  },
];
