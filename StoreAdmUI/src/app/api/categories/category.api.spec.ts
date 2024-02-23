import { TestBed } from '@angular/core/testing';
import { CategoryApi } from './category.api';

describe('CategoryApi', () => {
  let service: CategoryApi;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CategoryApi);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
