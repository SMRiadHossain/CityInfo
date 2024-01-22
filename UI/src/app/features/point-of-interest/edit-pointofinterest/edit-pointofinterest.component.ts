import { Component, OnInit } from '@angular/core';
import { PointOfInterest, cityid } from '../models/pointofinterest.mdel';
import { ActivatedRoute, Router } from '@angular/router';
import { PointofinterestService } from '../services/pointofinterest.service';
import { PointOfInterestListComponent } from '../point-of-interest-list/point-of-interest-list.component';


@Component({
  selector: 'app-edit-pointofinterest',
  templateUrl: './edit-pointofinterest.component.html',
  styleUrl: './edit-pointofinterest.component.css'
})
export class EditPointofinterestComponent implements OnInit {

  pointofinterestDetails: PointOfInterest = {
    id: 0,
    name: '',
    description: '',
    cityName: '',
    userId: 0
  };

  constructor(private route: ActivatedRoute, private pointofinterestService: 
    PointofinterestService, private router: Router) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) => {
        const cityId =params.get('cityId');
        const id = params.get('id');

        if(cityId){
          //call the api
          this.pointofinterestService.getPointOfInterest(Number(cityId),Number(id))
          .subscribe({
            next: (response) => {
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
    this.pointofinterestService.updatePointOfInterest(this.pointofinterestDetails.cityName,this.pointofinterestDetails.id,this.pointofinterestDetails)
    .subscribe({
      next: (response) => {
        this.router.navigate(['/admin/pointsofinterest']);
      },
    });
  }

}
