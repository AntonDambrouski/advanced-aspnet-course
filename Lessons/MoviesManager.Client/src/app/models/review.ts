export interface Review {
  id: number;
  movieId: number;
  rating: number; // Assuming rating is a number
  content: string; // Optional comment
  createdAt: Date; // Timestamp of when the review was created
}
