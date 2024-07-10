import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { ArticuloListaModel } from './models/articulo-lista-model';
import { Observable } from 'rxjs';
import { ArticuloEditModel} from './models/articulo-edit-model'
import { environment } from '../../../../environments/environment'
import { NetworkManagerService } from '../../../comunes/networking/network-manager.service';
import { toSignal, toObservable } from '@angular/core/rxjs-interop'
@Injectable({
  providedIn: 'root'
})
export class ArticuloService {

  private rutaServer = environment.urlServer
  private http = inject(HttpClient)
  private network = inject(NetworkManagerService)

  getArticulos() : Observable<ArticuloListaModel[]> {
    return this.http.get<ArticuloListaModel[]>(this.rutaServer + "articulos")
  }


  //variable declarativa
  readonly articulos$ = this.http.get<ArticuloListaModel[]>(this.rutaServer + "articulos")
  readonly articulos2$ = (this.network.get(this.rutaServer + "articulos") as Observable<ArticuloListaModel[]>)

  getArticuloSignal = toSignal(this.getArticulos())

  getArticuloSignal2 = toSignal(this.articulos$)

  getById(cod: number): Observable<ArticuloEditModel>{
    return this.network.get(`${this.rutaServer}articulos/${cod}`) as Observable<ArticuloEditModel>
  }

  insert(articulo: Partial<ArticuloEditModel>){
    return this.network.post(`${this.rutaServer}articulos/`, articulo) as Observable<ArticuloEditModel>
  }

  update(articulo: Partial<ArticuloEditModel>){
    return this.network.put(`${this.rutaServer}articulos/`, articulo) as Observable<ArticuloEditModel>

  }

}
