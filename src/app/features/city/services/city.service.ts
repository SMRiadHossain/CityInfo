import { Injectable } from '@angular/core';
import { AddCityRequest } from '../models/add-city-request.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { City } from '../models/city.model';

@Injectable({
  providedIn: 'root'
})
export class CityService {

  constructor(private http: HttpClient) { }

  addCity(addCityRequest: AddCityRequest): Observable<AddCityRequest> {
    return this.http.post<AddCityRequest>('https://localhost:7156/api/cities',addCityRequest);
  }

  getAllCities(): Observable<City[]>{
    return this.http.get<City[]>(`https://localhost:7156/api/cities`)
  }

  getCity(id: number): Observable<City>{
    return this.http.get<City>(`https://localhost:7156/api/cities/`+id);

  }

  updateCity(id: number, updateCityRequest: City): Observable<City>{
    return this.http.put<City>(`https://localhost:7156/api/cities/`+id, updateCityRequest);
  }

  deleteCity(id: number): Observable<City>{
    return this.http.delete<City>(`https://localhost:7156/api/cities/`+id);
  }
}
