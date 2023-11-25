import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Movie } from '../../models/movie';
import { CardsComponent } from '../../components/cards/cards.component';
import { MoviesService } from '../../services/movies.service';
import { FormsModule } from '@angular/forms';


@Component({
  selector: 'app-movies',
  standalone: true,
  imports: [CommonModule, CardsComponent, FormsModule],
  templateUrl: './movies.component.html',
  styleUrl: './movies.component.scss'
})
export class MoviesComponent implements OnInit {

  movies: Movie[] = [];
  moviesService: MoviesService = inject(MoviesService);
  private page: number = 0;
  searchTerm: string = '';
  searchTimeout: any;
  constructor() {}
  ngOnInit(): void {
    this.loadMore();
  }

  onSearchInput() {
    this.page = 0;
    this.movies = [];
    clearTimeout(this.searchTimeout);
    this.searchTimeout = setTimeout(() => {
      this.loadMore();
    }, 200);
  }

  loadMore() {
    this.page++;
    this.moviesService.getMovies(this.page,5, this.searchTerm).subscribe((movies)=>{
      this.movies.push(... movies);
    })
    
  }
}
