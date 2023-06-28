import { HttpClient, HttpErrorResponse, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { IBook } from "../models/book";
import {Observable, catchError, delay, throwError} from 'rxjs'
import { ErrorService } from "./error.service";

@Injectable({
    providedIn: 'root'
})

export class BookService {
    constructor(private http: HttpClient,
        private errorService: ErrorService){
    }


    getAll(): Observable<IBook[]> {
        const params = new HttpParams().set('limit', 5);
        return this.http.get<IBook[]>('http://localhost:5221/api/Book/GetFullBook', { params }).pipe(delay(2000),
        catchError(this.errorHandler));
    }

    private errorHandler(error: HttpErrorResponse){
        this.errorService.handle(error.message)
        return throwError(()=>error.message)
    }
    



}
