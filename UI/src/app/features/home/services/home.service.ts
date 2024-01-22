import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { searchReturn } from '../models/home.models';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  constructor(private http: HttpClient) { }

  searchResult(obj: string): Observable<searchReturn[]>{
    return this.http.get<searchReturn[]>(`https://localhost:7156/home/`+obj);
  }
}
