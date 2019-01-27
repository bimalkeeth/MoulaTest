import { TestBed, inject } from '@angular/core/testing';

import { DrawingService as DrawingserviceService } from './drawingservice.service';

describe('DrawingserviceService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [DrawingserviceService]
    });
  });

  it('should be created', inject([DrawingserviceService], (service: DrawingserviceService) => {
    expect(service).toBeTruthy();
  }));
});
