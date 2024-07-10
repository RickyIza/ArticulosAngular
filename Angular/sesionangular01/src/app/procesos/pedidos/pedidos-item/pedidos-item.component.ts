import { Component, Input, computed, inject, signal } from '@angular/core';
import { PedidoModel } from '../common/pedido-model';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { PedidoService } from '../common/pedido.service';

@Component({
  selector: 'app-pedidos-item',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './pedidos-item.component.html',
  styleUrl: './pedidos-item.component.css'
})
export class PedidosItemComponent {

  private pedidoService = inject(PedidoService)

  @Input({required: true}) set pedidoItem(pi: PedidoModel){
    this.item.set(pi)
  }

  item = signal<PedidoModel>(undefined!)

  subTotal = computed(() => this.item().articulo.precio * this.item().cantidad)
  arregloNumero : number[] =  [1, 2, 3, 4]

  onCantidadSelected(cantidad: number){
    this.pedidoService.actualizaCantidad(this.item(), cantidad)
  }

  removeFromCart(){
    this.pedidoService.elimnarArticulo(this.item())
  }
}
