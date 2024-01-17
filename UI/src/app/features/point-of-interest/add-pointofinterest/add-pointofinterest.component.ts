import { Component, OnDestroy } from '@angular/core';
import { AddPointofinterestRequest } from '../models/add-pointofinterest-request.model';
import { Subscription } from 'rxjs';
import { PointofinterestService } from '../services/pointofinterest.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-pointofinterest',
  templateUrl: './add-pointofinterest.component.html',
  styleUrl: './add-pointofinterest.component.css'
})
export class AddPointofinterestComponent {
  addPointofinterestRequest: AddPointofinterestRequest;

  constructor(private router:Router ,private pointofinterestService: PointofinterestService ) {
    this.addPointofinterestRequest = {
      Id: 0,
      name: '',
      description: '',
      userId: 0
    };
    
    
  }
  
  onFormSubmit(){
    this. pointofinterestService.addPointOfInterest(this.addPointofinterestRequest.Id, this.addPointofinterestRequest.userId, this.addPointofinterestRequest)
    .subscribe({
      next: (response) => {
        this.router.navigate(['admin/pointsofinterest']);
      },
      error: (response) =>{
        console.log(response);
        alert("UserId or City not Exist");
      }
    })
  }
  

}
