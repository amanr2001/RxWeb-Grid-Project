import { TestBed } from '@angular/core/testing';

import { CloudservService } from './cloudserv.service';

describe('CloudservService', () => {
  let service: CloudservService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CloudservService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
