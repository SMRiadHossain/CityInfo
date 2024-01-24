import { Component, OnInit } from '@angular/core';
import { searchReturn } from '../home/models/home.models';
import { HomeService } from '../home/services/home.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrl: './search.component.css'
})
export class SearchComponent implements OnInit{

  
  searchReturnObj: searchReturn[] = [];
  searchObj: string = '';
  search: string ='';

  constructor(private homeService: HomeService,private route: ActivatedRoute){} 

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) =>{
        const obj = params.get('obj');

        if(obj){
          this.searchObj = obj;
          this.homeService.searchResult(obj)
          .subscribe({
            next: (searchreturn) =>{
              this.searchReturnObj = searchreturn;
              this.search = obj;
            },
            error: (er) =>{
              alert("No match Found");
            }
          });

        }
      }
    })
    
  }


  

}
