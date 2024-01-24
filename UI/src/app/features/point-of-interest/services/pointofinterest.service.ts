import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AddPointofinterestRequest } from '../models/add-pointofinterest-request.model';
import { Observable } from 'rxjs';
import { PointOfInterest, PointOfInterestEdit, PointOfInterestShow } from '../models/pointofinterest.mdel';

@Injectable({
  providedIn: 'root'
})
export class PointofinterestService {

  constructor(private http: HttpClient) { }

  addPointOfInterest(cityName: string, userName: string, model: AddPointofinterestRequest): Observable<void>{
    return this.http.post<void>(`https://localhost:7156/api/cities/${cityName}/pointsofinterest/`+userName,model)
  }

  getAllPointOfInterests(cityName: string): Observable<PointOfInterest[]>{
    return this.http.get<PointOfInterest[]>(`https://localhost:7156/api/cities/${cityName}/pointsofinterest`)
  }
  getPointOfInterest(cityName: string, pointofinterestId: number): Observable<PointOfInterestEdit> {
    return this.http.get<PointOfInterestEdit>(`https://localhost:7156/api/cities/${cityName}/pointsofinterest/${pointofinterestId}`);
  }

  updatePointOfInterest(cityName: string, pointofinterestId: number, updatePointofInterest: PointOfInterestEdit): Observable<PointOfInterestEdit>{
    return this.http.put<PointOfInterestEdit>(`https://localhost:7156/api/cities/${cityName}/pointsofinterest/${pointofinterestId}`, updatePointofInterest);
  }

  deletePoint(cityName: string,id: number): Observable<PointOfInterest>{
    return this.http.delete<PointOfInterest>(`https://localhost:7156/api/cities/${cityName}/pointsofinterest/`+id);
  }
  getPoint(): Observable<PointOfInterestShow[]>{
    return this.http.get<PointOfInterestShow[]>(`https://localhost:7156/api/cities/pointsofinterest`);
  }


}
