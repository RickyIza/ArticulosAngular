import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { OpcionService } from './opcion.service';

export const autorizaGuard: CanActivateFn = (route, state) => {

  const opcionService = inject(OpcionService)
  const router = inject(Router)

  let name = route.data["opcion"]

  if(name){
    if (!opcionService.bucarOpcion(name)){
      router.navigate(['noautorizado'])
    }
  }


  return true;
};
