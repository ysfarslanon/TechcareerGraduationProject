import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/auth/login/login.component';
import { RegisterComponent } from './components/auth/register/register.component';
import { CategoryAddComponent } from './components/category/category-add/category-add.component';
import { CategoryListComponent } from './components/category/category-list/category-list.component';
import { CategoryUpdateComponent } from './components/category/category-update/category-update.component';
import { ProductAddComponent } from './components/product/product-add/product-add.component';
import { ProductListComponent } from './components/product/product-list/product-list.component';
import { ProductUpdateComponent } from './components/product/product-update/product-update.component';
import { ShoppingListAddComponent } from './components/shoppingList/shopping-list-add/shopping-list-add.component';
import { ShoppingListListComponent } from './components/shoppingList/shopping-list-list/shopping-list-list.component';
import { ShoppingListDetailAddComponent } from './components/shoppingListDetail/shopping-list-detail-add/shopping-list-detail-add.component';
import { ShoppingListDetailListComponent } from './components/shoppingListDetail/shopping-list-detail-list/shopping-list-detail-list.component';
import { ShoppingListDetailUpdateComponent } from './components/shoppingListDetail/shopping-list-detail-update/shopping-list-detail-update.component';
import { WelcomeComponent } from './components/static/welcome/welcome.component';
import { AdminUserGuard } from './guards/adminUser/admin-user.guard';
import { LoggedGuard } from './guards/logged/logged.guard';
import { NormalUserGuard } from './guards/normalUser/normal-user.guard';

const routes: Routes = [
  {
    path: 'login',
    pathMatch: 'full',
    component: LoginComponent,
    canActivate: [LoggedGuard],
  },
  {
    path: 'register',
    pathMatch: 'full',
    component: RegisterComponent,
    canActivate: [LoggedGuard],
  },
  {
    path: 'category/add',
    pathMatch: 'full',
    component: CategoryAddComponent,
    canActivate: [AdminUserGuard],
  },
  {
    path: 'categories',
    pathMatch: 'full',
    component: CategoryListComponent,
    canActivate: [AdminUserGuard]
  },
  {
    path: 'category/update/:categoryId',
    pathMatch: 'full',
    component: CategoryUpdateComponent,
    canActivate: [AdminUserGuard]
  },
  {
    path: 'products',
    pathMatch: 'full',
    component: ProductListComponent,
    canActivate: [AdminUserGuard]
  },
  {
    path: 'products/category/:categoryId',
    pathMatch: 'full',
    component: ProductListComponent,
    canActivate: [AdminUserGuard],
  },
  {
    path: 'product/add',
    pathMatch: 'full',
    component: ProductAddComponent
    ,canActivate: [AdminUserGuard],
  },
  {
    path: 'product/update/:productId',
    pathMatch: 'full',
    component: ProductUpdateComponent,
    canActivate: [AdminUserGuard],
  },
  {
    path: 'shoppinglist',
    pathMatch: 'full',
    component: ShoppingListListComponent
    ,canActivate: [NormalUserGuard],
  },
  {
    path: 'shoppinglist/add',
    pathMatch: 'full',
    component: ShoppingListAddComponent,
    canActivate: [NormalUserGuard],
  },
  {
    path: 'shoppinglistdetail/:shoppingListId',
    pathMatch: 'full',
    component: ShoppingListDetailListComponent,
    canActivate: [NormalUserGuard],
  },
  {
    path: 'shoppinglistdetail/:shoppingListId/products/category/:categoryId',
    pathMatch: 'full',
    component: ShoppingListDetailListComponent,
    canActivate: [NormalUserGuard],
  },
  {
    path: 'shoppinglistdetail/:shoppingListId/add/:productId',
    pathMatch: 'full',
    component: ShoppingListDetailAddComponent,
    canActivate: [NormalUserGuard],
  },
  {
    path: 'shoppinglistdetail/update/:shoppingListDetailId',
    pathMatch: 'full',
    component: ShoppingListDetailUpdateComponent,
    canActivate: [NormalUserGuard],
  },
  {
    path: '',
    pathMatch: 'full',
    component: WelcomeComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
