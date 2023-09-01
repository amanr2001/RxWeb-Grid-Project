import { TestBed } from '@angular/core/testing';

import { VerifiedGuardGuard } from './verified-guard.guard';

describe('VerifiedGuardGuard', () => {
  let guard: VerifiedGuardGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(VerifiedGuardGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
