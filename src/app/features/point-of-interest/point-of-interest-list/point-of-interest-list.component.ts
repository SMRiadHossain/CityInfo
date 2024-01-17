import { Component, OnInit } from '@angular/core';
import { PointOfInterest, cityid } from '../models/pointofinterest.mdel';
import { PointofinterestService } from '../services/pointofinterest.service';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-point-of-interest-list',
  templateUrl: './point-of-interest-list.component.html',
  styleUrl: './point-of-interest-list.component.css'
})

export class PointOfInterestListComponent implements OnInit{

  pointsofinterests: PointOfInterest[] = [];

  // pointCityId: cityid = {
  //   cityId: 0
  // };
  pointCityId: number = 0;
  
  static cId: number;

  static assignValueToStatic(instance: PointOfInterestListComponent) {
    PointOfInterestListComponent.cId = instance.pointCityId;
  }


  constructor(private router: Router, private pointOfInterestService: PointofinterestService){
    //PointOfInterestListComponent.pointCityId = 0;
    
  }

  

  ngOnInit(): void {

    this.pointOfInterestService.getAllPointOfInterests(this.pointCityId)
    .subscribe({
      next: (pointsofinterests) => {
        this.pointsofinterests= pointsofinterests;
        //console.log(pointsofinterests);
      },
      error: (response) => {
        console.log(response);
      }
    })
    

  }


  deletePoint(cityId: number,id: number){
    this.pointOfInterestService.deletePoint(cityId,id)
    .subscribe({
      next: (response) => {
        location.reload();
        //this.router.navigate(['/admin/pointsofinterest']);
        //this.location.replace(this.location.pathname);
      },
      error: (response) =>{
       
        console.log(response);
      }

    });
  }

}

//PointOfInterestListComponent.pointCityId = 0;