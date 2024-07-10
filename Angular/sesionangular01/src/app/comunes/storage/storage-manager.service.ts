import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StorageManagerService {

  constructor() { }

  asignar(key: string, value: any) {
    sessionStorage.setItem(key, JSON.stringify(value))
  }

  recuperar(key: string) {
    let item = sessionStorage.getItem(key)
    if (item && item !== 'undefined') {
      return JSON.parse(sessionStorage.getItem(key) || "")
    }
    return ""
  }

  eliminar(key: string) {
    sessionStorage.removeItem(key)
  }
}
