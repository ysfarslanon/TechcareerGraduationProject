// This file can be replaced during build by using the `fileReplacements` array.
// `ng build` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  categoryApiUrl:'https://localhost:7007/api/Categories/',
  productApiUrl:'https://localhost:7007/api/Products/',
  authApiUrl:'https://localhost:7007/api/Auths/',
  shoppingListApiUrl:'https://localhost:7007/api/ShoppingLists/',
  shoppingListDetailApiUrl:'https://localhost:7007/api/ShoppingListDetails/',
  formNotValid:'Form istenen kurallara uygun girilmedi.'
};
/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/plugins/zone-error';  // Included with Angular CLI.
