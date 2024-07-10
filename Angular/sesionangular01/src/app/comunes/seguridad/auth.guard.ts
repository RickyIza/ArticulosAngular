import { inject } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivateFn, Router } from '@angular/router';
import { StorageManagerService } from '../storage/storage-manager.service';

export const authGuard: CanActivateFn = (route, state) => {

  const storageManager = inject(StorageManagerService)
  const router = inject(Router)

  // let name = route.data["opcion"]
  // let name2 = extractDataFromRoute(state.root)
  // let param = route.data["parametro"]

  // console.log("name", name)
  // console.log("name2", name2)
  // console.log("param", param)
  if (!storageManager.recuperar("usertoken")) {
    router.navigate(["ext", "login"])
    //router.navigateByUrl("/ext/login")
  }
  return true;
};



const extractDataFromRoute = (route: ActivatedRouteSnapshot): any => {
  if (route.data['opcion']) {
    return route.data['opcion'];
  }

  if (route.firstChild) {
    return extractDataFromRoute(route.firstChild);
  }

  return null;
}