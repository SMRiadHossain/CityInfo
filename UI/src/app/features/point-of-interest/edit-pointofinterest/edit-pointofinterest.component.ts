import { Component, OnInit } from '@angular/core';
import { PointOfInterest, PointOfInterestEdit, cityid } from '../models/pointofinterest.mdel';
import { ActivatedRoute, Router } from '@angular/router';
import { PointofinterestService } from '../services/pointofinterest.service';
import { PointOfInterestListComponent } from '../point-of-interest-list/point-of-interest-list.component';


@Component({
  selector: 'app-edit-pointofinterest',
  templateUrl: './edit-pointofinterest.component.html',
  styleUrl: './edit-pointofinterest.component.css'
})
export class EditPointofinterestComponent implements OnInit {

  pointofinterestDetails: PointOfInterestEdit = {
    id: 0,
    name: '',
    description: '',
    cityId: 0,
    userId: 0
  };

  constructor(private route: ActivatedRoute, private pointofinterestService: 
    PointofinterestService, private router: Router) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) => {
        const cityName =params.get('cityName');
        const id = params.get('id');

        if(cityName){
          //call the api
          this.pointofinterestService.getPointOfInterest(cityName,Number(id))
          .subscribe({
            next: (response) => {
              //console.log(response)
              this.pointofinterestDetails = response;
            },
            error: (response) => {
              console.log(response);
            }
          });
        }
      }
      
    })
    
  }


  updatePointOfInterest(){
    this.route.paramMap
    .subscribe({
      next: (params) => {
        const cityName = params.get('cityName');
        if(cityName)
          this.pointofinterestService.updatePointOfInterest(cityName,this.pointofinterestDetails.id,this.pointofinterestDetails)
        this.router.navigate(['/lists/pointsofinterest']);
      },
      error: (response) =>{
        console.log(response);
      }
    });
  }

}
