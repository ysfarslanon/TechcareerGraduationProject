import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms'; //
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; //

import { AppRoutingModule } from './app-routing.module';
import { ToastrModule } from 'ngx-toastr';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/auth/login/login.component';
import { RegisterComponent } from './components/auth/register/register.component';
import { AuthInterceptor } from './interceptors/auth.interceptor';
import { WelcomeComponent } from './components/static/welcome/welcome.component';
import { CategoryAddComponent } from './components/category/category-add/category-add.component';
import { CategoryListComponent } from './components/category/category-list/category-list.component';
import { CategoryUpdateComponent } from './components/category/category-update/category-update.component';
import { ProductListComponent } from './components/product/product-list/product-list.component';
import { ProductFilterTextPipe } from './pipes/product/product-filter-text.pipe';
import { ProductAddComponent } from './components/product/product-add/product-add.component';
import { ProductUpdateComponent } from './components/product/product-update/product-update.component';
import { ShoppingListListComponent } from './components/shoppingList/shopping-list-list/shopping-list-list.component';
import { ShoppingListAddComponent } from './components/shoppingList/shopping-list-add/shopping-list-add.component';
import { ShoppingListDetailListComponent } from './components/shoppingListDetail/shopping-list-detail-list/shopping-list-detail-list.component';
import { FooterComponent } from './components/static/footer/footer.component';
import { ShoppingListDetailAddComponent } from './components/shoppingListDetail/shopping-list-detail-add/shopping-list-detail-add.component';
import { ShoppingListDetailUpdateComponent } from './components/shoppingListDetail/shopping-list-detail-update/shopping-list-detail-update.component';
import { NavbarComponent } from './components/static/navbar/navbar.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    WelcomeComponent,
    CategoryAddComponent,
    CategoryListComponent,
    CategoryUpdateComponent,
    ProductListComponent,
    ProductFilterTextPipe,
    ProductAddComponent,
    ProductUpdateComponent,
    ShoppingListListComponent,
    ShoppingListAddComponent,
    ShoppingListDetailListComponent,
    FooterComponent,
    ShoppingListDetailAddComponent,
    ShoppingListDetailUpdateComponent,
    NavbarComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule, //
    ReactiveFormsModule, //
    BrowserAnimationsModule, //
    ToastrModule.forRoot({ positionClass: 'toast-bottom-left' }), //
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
