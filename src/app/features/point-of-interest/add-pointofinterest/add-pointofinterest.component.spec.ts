import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddPointofinterestComponent } from './add-pointofinterest.component';

describe('AddPointofinterestComponent', () => {
  let component: AddPointofinterestComponent;
  let fixture: ComponentFixture<AddPointofinterestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AddPointofinterestComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AddPointofinterestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
