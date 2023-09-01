import { TestBed } from '@angular/core/testing';

import { SearchserService } from './searchser.service';

describe('SearchserService', () => {
  let service: SearchserService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SearchserService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
