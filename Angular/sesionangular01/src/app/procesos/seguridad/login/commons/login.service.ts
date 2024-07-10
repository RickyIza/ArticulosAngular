import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { AutenticaReqModel } from './models/autentica-req-model';
import { AutenticaRespModel } from './models/autentica-resp-models';
import { Observable } from 'rxjs';
import { NetworkManagerService } from '../../../../comunes/networking/network-manager.service';
import {environment } from  '../../../../../environments/environment'
import { MenuModel } from './models/menu-model';
import { StorageManagerService } from '../../../../comunes/storage/storage-manager.service';
import { Router } from '@angular/router';
@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private rutaServer = environment.urlServer
  private http = inject(HttpClient)
  private networkManager = inject(NetworkManagerService)
  private storageManager = inject(StorageManagerService)
  private router = inject(Router)

  constructor() { }

  autentica(user: AutenticaReqModel) : Observable<AutenticaRespModel>{
    return this.networkManager.post(this.rutaServer + 'auth', user) as Observable<AutenticaRespModel>
  }

  getMenus(): Observable<MenuModel[]>{
    
    return this.networkManager.get(`${this.rutaServer}opciones`) as Observable<MenuModel[]>
  }

  cierraSesion(){
    this.storageManager.eliminar("usertoken")
    this.storageManager.eliminar("opciones")
    this.router.navigate(["ext", "login"])
  }
}
