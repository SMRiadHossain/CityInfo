import { Component } from '@angular/core';
import { City } from '../../city/models/city.model';
import { CityService } from '../../city/services/city.service';
import { PointOfInterestShow } from '../../point-of-interest/models/pointofinterest.mdel';
import { PointofinterestService } from '../../point-of-interest/services/pointofinterest.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

  citiesHome: City[] = [];

  pointsHome: PointOfInterestShow[] = []

  constructor(private citiyService: CityService, private pointService: PointofinterestService){} 

  ngOnInit(): void {

    this.citiyService.getAllCities()
    .subscribe({
      next: (cities) => {
        this.citiesHome = cities;
      },
      error: (response) => {
        console.log(response);
      }

    })
    this.pointService.getPoint()
    .subscribe({
      next: (points) => {
        this.pointsHome = points;
      }
    })
    
  }
  

}
