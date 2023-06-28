import { Component, Input } from '@angular/core';
import { IBook } from 'src/app/models/book';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html'
})
export class BookComponent {
  @Input() book: IBook
}
