import { TestBed } from '@angular/core/testing';

import { MainservService } from './mainserv.service';

describe('MainservService', () => {
  let service: MainservService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MainservService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
