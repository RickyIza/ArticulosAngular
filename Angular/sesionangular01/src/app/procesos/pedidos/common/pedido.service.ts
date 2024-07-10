import { Injectable, computed, effect, signal } from '@angular/core';
import { PedidoModel } from './pedido-model';
import { ArticuloListaModel } from '../../articulo/common/models/articulo-lista-model';

@Injectable({
  providedIn: 'root'
})
export class PedidoService {

  pedidoItems = signal<PedidoModel[]>([])

  constructor() { }

  cant = effect(() => {
    console.log("cambio", this.pedidoItems().length)
  })

  cantidadBase = computed(() => this.pedidoItems().length)

  cantidadTotal = computed(() => this.pedidoItems().reduce((acum, item) => acum + item.cantidad, 0))

  subTotal = computed(
    () => this.pedidoItems().reduce(
      (acum, item) => acum + item.cantidad * item.articulo.precio, 0))

  impuesto = computed(() => Math.round(this.subTotal() * 18) / 100)

  total = computed(() => this.subTotal() + this.impuesto())

  addToCar(art: ArticuloListaModel) {
    let item: PedidoModel = { articulo: art, cantidad: 1 }
    this.pedidoItems.update(values => [...values, item])
  }

  addToCar2(art: ArticuloListaModel) {
    const index = this.pedidoItems().findIndex(t => t.articulo.codigo === art.codigo)
    if (index === -1) {
      this.pedidoItems.update(values => [...values, { articulo: art, cantidad: 1 }])
    }
    else {
      this.pedidoItems.update(values =>
        [
          ...values.slice(0, index),
          { ...values[index], cantidad: values[index].cantidad + 1 },
          ...values.slice(index + 1)
        ])
    }
  }

  actualizaCantidad(pedidoItem: PedidoModel, cantidad: number) {
    this.pedidoItems.update(items =>
      items.map(item => item.articulo.codigo === pedidoItem.articulo.codigo ? { ...item, cantidad } : item)
    )
  }

  elimnarArticulo(pedidoItem: PedidoModel) {
    this.pedidoItems.update(items =>
      items.filter(item => item.articulo.codigo !== pedidoItem.articulo.codigo))
  }
}
