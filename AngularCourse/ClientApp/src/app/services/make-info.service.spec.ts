import { TestBed, inject } from '@angular/core/testing';

import { MakeInfoService } from './make-info.service';

describe('MakeInfoService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [MakeInfoService]
    });
  });

  it('should be created', inject([MakeInfoService], (service: MakeInfoService) => {
    expect(service).toBeTruthy();
  }));
});
