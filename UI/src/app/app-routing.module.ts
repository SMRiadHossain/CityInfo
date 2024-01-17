import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CityListComponent } from './features/city/city-list/city-list.component';
import { AddCityComponent } from './features/city/add-city/add-city.component';
import { PointOfInterestListComponent } from './features/point-of-interest/point-of-interest-list/point-of-interest-list.component';
import { AddPointofinterestComponent } from './features/point-of-interest/add-pointofinterest/add-pointofinterest.component';
import { EditCityComponent } from './features/city/edit-city/edit-city.component';
import { EditPointofinterestComponent } from './features/point-of-interest/edit-pointofinterest/edit-pointofinterest.component';
import { HomeComponent } from './features/home/home/home.component';
import { LoginComponent } from './features/login/login.component';
import { SignupComponent } from './features/signup/signup.component';


const routes: Routes = [
  {
    path: 'admin/cities',
    component: CityListComponent
  },
  {
    path: 'admin/cities/add',
    component: AddCityComponent
  },
  {
    path: 'admin/pointsofinterest',
    component: PointOfInterestListComponent
  },
  {
    path: 'admin/pointofinterest/add',
    component: AddPointofinterestComponent
  },
  {
    path: 'admin/cities/edit/:id',
    component: EditCityComponent
  },
  {
    path: 'admin/pointsofinterest/edit/:cityId/:id',
    component: EditPointofinterestComponent
  },
  {
    path: '',
    component: HomeComponent
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'signup',
    component: SignupComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
