import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AddPointofinterestRequest } from '../models/add-pointofinterest-request.model';
import { Observable } from 'rxjs';
import { PointOfInterest, PointOfInterestShow } from '../models/pointofinterest.mdel';

@Injectable({
  providedIn: 'root'
})
export class PointofinterestService {

  constructor(private http: HttpClient) { }

  addPointOfInterest(cityName: string, userId: number, model: AddPointofinterestRequest): Observable<void>{
    return this.http.post<void>(`https://localhost:7156/api/cities/${cityName}/pointsofinterest/`+userId,model)
  }

  getAllPointOfInterests(cityName: string): Observable<PointOfInterest[]>{
    return this.http.get<PointOfInterest[]>(`https://localhost:7156/api/cities/${cityName}/pointsofinterest`)
  }
  getPointOfInterest(cityId: number, pointofinterestId: number): Observable<PointOfInterest> {
    return this.http.get<PointOfInterest>(`https://localhost:7156/api/cities/${cityId}/pointsofinterest/${pointofinterestId}`);
  }

  updatePointOfInterest(cityName: string, pointofinterestId: number, updatePointofInterest: PointOfInterest): Observable<PointOfInterest>{
    return this.http.put<PointOfInterest>(`https://localhost:7156/api/cities/${cityName}/pointsofinterest/${pointofinterestId}`, updatePointofInterest);
  }

  deletePoint(cityName: string,id: number): Observable<PointOfInterest>{
    return this.http.delete<PointOfInterest>(`https://localhost:7156/api/cities/${cityName}/pointsofinterest/`+id);
  }
  getPoint(): Observable<PointOfInterestShow[]>{
    return this.http.get<PointOfInterestShow[]>(`https://localhost:7156/api/cities/pointsofinterest`);
  }


}
