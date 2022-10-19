import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShoppingListDetailAddComponent } from './shopping-list-detail-add.component';

describe('ShoppingListDetailAddComponent', () => {
  let component: ShoppingListDetailAddComponent;
  let fixture: ComponentFixture<ShoppingListDetailAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShoppingListDetailAddComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShoppingListDetailAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
