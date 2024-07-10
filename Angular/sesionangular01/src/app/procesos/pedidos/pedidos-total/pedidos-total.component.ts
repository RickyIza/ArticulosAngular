import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { PedidoModel } from '../common/pedido-model';
import { PedidoService } from '../common/pedido.service';

@Component({
  selector: 'app-pedidos-total',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './pedidos-total.component.html',
  styleUrl: './pedidos-total.component.css'
})
export class PedidosTotalComponent {

  private pedidoService = inject(PedidoService)

  pedidoItems = this.pedidoService.pedidoItems
  subTotal = this.pedidoService.subTotal
  impuesto = this.pedidoService.impuesto
  total = this.pedidoService.total
}
