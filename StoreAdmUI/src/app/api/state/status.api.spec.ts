import { TestBed } from '@angular/core/testing';

import { StatusApi } from './status.api';

describe('StateApi', () => {
  let service: StatusApi;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StatusApi);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
