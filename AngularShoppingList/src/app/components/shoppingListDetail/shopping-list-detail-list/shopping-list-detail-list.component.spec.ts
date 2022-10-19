import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShoppingListDetailListComponent } from './shopping-list-detail-list.component';

describe('ShoppingListDetailListComponent', () => {
  let component: ShoppingListDetailListComponent;
  let fixture: ComponentFixture<ShoppingListDetailListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShoppingListDetailListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShoppingListDetailListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
