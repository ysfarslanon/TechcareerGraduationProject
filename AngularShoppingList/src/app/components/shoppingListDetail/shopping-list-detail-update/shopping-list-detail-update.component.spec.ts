import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShoppingListDetailUpdateComponent } from './shopping-list-detail-update.component';

describe('ShoppingListDetailUpdateComponent', () => {
  let component: ShoppingListDetailUpdateComponent;
  let fixture: ComponentFixture<ShoppingListDetailUpdateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShoppingListDetailUpdateComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShoppingListDetailUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
