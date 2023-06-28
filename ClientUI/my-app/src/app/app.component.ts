import { Component, OnInit } from '@angular/core';
import { IBook } from './models/book';
import { BookService } from './services/book.service';
import { Observable, tap } from 'rxjs';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  

  title = 'library'
  // books: IBook[] = []
  loading = false
  books$: Observable<IBook[]>



  constructor(private bookService: BookService) {}
  ngOnInit(): void {
    this.loading = true
    this.books$ = this.bookService.getAll().pipe(tap(()=>this.loading = false))
    // this.bookService.getAll().subscribe(books => {
    //   this.books = books
    //   this.loading = false
    // })
  }


}
