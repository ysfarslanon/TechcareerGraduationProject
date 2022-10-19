import { TestBed } from '@angular/core/testing';

import { ShoppingListDetailService } from './shopping-list-detail.service';

describe('ShoppingListDetailService', () => {
  let service: ShoppingListDetailService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ShoppingListDetailService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
