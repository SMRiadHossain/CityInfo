import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CityService } from '../services/city.service';
import { City } from '../models/city.model';

@Component({
  selector: 'app-edit-city',
  templateUrl: './edit-city.component.html',
  styleUrl: './edit-city.component.css'
})
export class EditCityComponent implements OnInit{

  cityDetails: City = {
    id: 0,
    name: '',
    description: ''

  };

  constructor(private route: ActivatedRoute, private cityService: CityService, private router: Router) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id');

        if(id){
          //call the api
          this.cityService.getCity(Number(id))
          .subscribe({
            next: (response) => {
              this.cityDetails = response;
            }
          });
        }
      }
      
    })
  }

  updateCity(){
    this.cityService.updateCity(this.cityDetails.id,this.cityDetails)
    .subscribe({
      next: (response) => {
        this.router.navigate(['/lists/cities']);
      }
    });
  }

}
