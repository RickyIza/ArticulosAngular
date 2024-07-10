import { HttpInterceptorFn } from '@angular/common/http';
import { StorageManagerService } from '../storage/storage-manager.service';
import { inject } from '@angular/core';
import { Router } from '@angular/router';

export const tokenInterceptor: HttpInterceptorFn = (req, next) => {

  const storageManager = inject(StorageManagerService)
  const router = inject(Router)


  if (req.url.indexOf("/auth")> 0) {
    return next(req); 
  }

  const token = storageManager.recuperar("usertoken")
 
  if (token !== "") {

    const nuevoReq = req.clone({
      setHeaders: {
        Authorization: `Bearer ${token}`
      }
    })

    return next(nuevoReq);
  }
  else{
    router.navigate(["ext", "login"])
    return next(req);
  }


};
