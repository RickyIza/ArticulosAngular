import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class NetworkManagerService {

  private http = inject(HttpClient)

  constructor() { }

  
  get(url: string) : Observable<any>{
    const header = new HttpHeaders({"content-type": "application/json"})
    const opciones = {headers: header}
   
    return this.http.get<any>(url, opciones)

  }

  post(url: string, parameter: any) : Observable<any>{
    const header = new HttpHeaders({"content-type": "application/json"})
    const opciones = {headers: header}
    var param = parameter || null

    return this.http.post<any>(url, JSON.stringify(param), opciones)

  }

  put(url: string, parameter: any) : Observable<any>{
    const header = new HttpHeaders({"content-type": "application/json"})
    const opciones = {headers: header}
    var param = parameter || null

    return this.http.put<any>(url, JSON.stringify(param), opciones)

  }
}
