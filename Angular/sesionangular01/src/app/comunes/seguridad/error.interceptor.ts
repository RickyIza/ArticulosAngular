import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { catchError, throwError } from 'rxjs';
import { LoginService } from '../../procesos/seguridad/login/commons/login.service';

export const errorInterceptor: HttpInterceptorFn = (req, next) => {

  const loginService = inject(LoginService)

  return next(req).pipe(
    catchError(err => {
      if (err instanceof HttpErrorResponse) {
        if (err.status === 401) {
          console.log("no autorizado")
          loginService.cierraSesion()
        }
        else {
          console.log("Respuesta no adecuada", err)
        }
      }
      else{
        console.log("Error no manejado", err)
      }

      return throwError(() => err)
    })
  );
};
