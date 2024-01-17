import { TestBed } from '@angular/core/testing';

import { PointofinterestService } from './pointofinterest.service';

describe('PointofinterestService', () => {
  let service: PointofinterestService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PointofinterestService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
