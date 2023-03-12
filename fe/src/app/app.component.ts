import { Component, OnInit } from '@angular/core';
import { DataService } from './dataService';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  movies!: Movie[];

  constructor(private dataService: DataService) {}

  ngOnInit(): void {
    this.dataService.getMovies().subscribe((response) => {
      this.movies = response;
    });
  }
}

export class Movie {
  id!: number;
  name!: string;
  genre!: string;
  year!: number;
}
