import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditPointofinterestComponent } from './edit-pointofinterest.component';

describe('EditPointofinterestComponent', () => {
  let component: EditPointofinterestComponent;
  let fixture: ComponentFixture<EditPointofinterestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [EditPointofinterestComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(EditPointofinterestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
