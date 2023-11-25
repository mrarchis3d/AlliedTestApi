import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Movie } from '../models/movie';
import { Observable, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MoviesService {
  private apiUrl = 'https://localhost:7266/api/movies';

  constructor(private http: HttpClient) {}

  getMovies(page:number, size: number, filter: string): Observable<Movie[]> {
    const params = new HttpParams()
      .set('p', page) 
      .set('s', size)
      .set('filter', filter);
    return this.http.get<Movie[]>(this.apiUrl, { params });
  }
}
