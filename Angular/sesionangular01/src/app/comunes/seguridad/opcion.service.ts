import { Injectable, inject } from '@angular/core';
import { OpcionModel } from '../../componentes/menu/opcion-model';
import { StorageManagerService } from '../storage/storage-manager.service';

@Injectable({
  providedIn: 'root'
})
export class OpcionService {

  private storageService = inject(StorageManagerService)
  constructor() { }

  getOpciones(): OpcionModel[]{
    let opciones : OpcionModel[] = this.storageService.recuperar("opciones")
    return opciones
  }

  bucarOpcion(data: string): boolean{
    let opcion = this.getOpciones().find(item => item.url == data)
    console.log("Opcion", opcion)
    let posicion = this.getOpciones().findIndex(item => item.url == data)
    return posicion > -1
  }
}
