import { Component, OnInit } from '@angular/core';
import { City } from '../models/city.model';
import { CityService } from '../services/city.service';
import { Router } from '@angular/router';



@Component({
  selector: 'app-city-list',
  templateUrl: './city-list.component.html',
  styleUrl: './city-list.component.css'
})
export class CityListComponent implements OnInit{

  cities: City[] = [];

  constructor(private router: Router,private citiesService: CityService ){

  }

  deleteCity(id: number){
    this.citiesService.deleteCity(id)
    .subscribe({
      next: (response) => {
        location.reload();
        //this.router.navigate(['/admin/cities']);
        //this.location.replace(this.location.pathname);
      },
      error: (response) =>{
        console.log(response);
      }

    });
  }
  ngOnInit(): void {

    this.citiesService.getAllCities()
    .subscribe({
      next: (cities) => {
        this.cities = cities;
      },
      error: (response) => {
        console.log(response);
      }
    })
    
  }

}
