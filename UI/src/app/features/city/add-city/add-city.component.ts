import { Component, OnDestroy } from '@angular/core';
import { AddCityRequest } from '../models/add-city-request.model';
import { CityService } from '../services/city.service';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-city',
  templateUrl: './add-city.component.html',
  styleUrl: './add-city.component.css'
})
export class AddCityComponent {

  addCityRequest: AddCityRequest;

  constructor(private cityService: CityService, private router: Router) {
    this.addCityRequest = {
      name: '',
      description: '',
      userId: 0
    };
  }
  
  formAddCity(){
    this.cityService.addCity(this.addCityRequest)
    .subscribe({
      next: (addCityRequest) => {
        this.router.navigate(['admin/cities'])

      },
      error: (Response) =>{
        alert("UserId not Exist");
      }
    })
  }
  

}
