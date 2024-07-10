import { Component, OnDestroy, OnInit, inject } from '@angular/core';
import { ArticuloService } from '../common/articulo.service';
import { Subscription } from 'rxjs';
import { ArticuloListaModel } from '../common/models/articulo-lista-model';
import { CommonModule } from '@angular/common';
import { Router, RouterModule } from '@angular/router';
import { PedidoService } from '../../pedidos/common/pedido.service';

@Component({
  selector: 'app-articulo-listar',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './articulo-listar.component.html',
  styleUrl: './articulo-listar.component.css'
})
export class ArticuloListarComponent implements OnInit, OnDestroy {
 
  private pedidoService = inject(PedidoService)
  private articuloService = inject(ArticuloService)
  private router = inject(Router)

  private subs! : Subscription
  articuloLista : ArticuloListaModel[] = []

  ngOnInit(): void {
    this.subs = this.articuloService.getArticulos().subscribe(
      res => { 
        this.articuloLista = res
       }
    )

  }

  ngOnDestroy(): void {
    this.subs.unsubscribe()
    
  }

  mostrarArticulo(item: ArticuloListaModel){
    console.log(item)
    this.router.navigate(["articulodetalle", item.codigo])

  }

  nuevoArticulo(){
    this.router.navigate(["articulodetalle"])

  }

  agregarCarrito(item: ArticuloListaModel){
    //this.pedidoService.addToCar(item)
    this.pedidoService.addToCar2(item)
  }

  eliminar(item: ArticuloListaModel){
    
  }
}
