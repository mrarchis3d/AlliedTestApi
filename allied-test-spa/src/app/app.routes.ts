import { Routes } from '@angular/router';
import { MoviesComponent } from './views/movies/movies.component';

export const routes: Routes = [
    {
        path: 'movies',
        component: MoviesComponent,
        data: { title: 'Home details' }, 
    },
    {
        path: '',
        redirectTo: '/movies',
        pathMatch: 'full', 
    },

];
