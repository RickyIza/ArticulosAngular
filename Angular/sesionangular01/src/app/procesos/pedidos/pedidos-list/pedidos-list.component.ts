import { Component, OnInit, inject } from '@angular/core';
import { PedidoModel } from '../common/pedido-model';
import { CommonModule } from '@angular/common';
import { PedidosItemComponent } from '../pedidos-item/pedidos-item.component';
import { PedidoService } from '../common/pedido.service';

@Component({
  selector: 'app-pedidos-list',
  standalone: true,
  imports: [CommonModule, PedidosItemComponent],
  templateUrl: './pedidos-list.component.html',
  styleUrl: './pedidos-list.component.css'
})
export class PedidosListComponent implements OnInit {

  private pedidoService = inject(PedidoService)
  pageTitle = "Carito de compra"
  pedidoItems = this.pedidoService.pedidoItems


  ngOnInit(): void {
  }
}
