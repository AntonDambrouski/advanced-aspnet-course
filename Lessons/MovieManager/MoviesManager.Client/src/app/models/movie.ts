import { Review } from './review';

export interface Movie {
  id: number;
  title: string;
  description: string;
  genre: string;
  posterFileName?: string;
  reviews: Review[]; // Assuming a movie can have multiple reviews
}
