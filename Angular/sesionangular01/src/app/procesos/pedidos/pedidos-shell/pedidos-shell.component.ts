import { Component } from '@angular/core';
import { PedidosListComponent } from '../pedidos-list/pedidos-list.component';
import { PedidosTotalComponent } from '../pedidos-total/pedidos-total.component';

@Component({
  selector: 'app-pedidos-shell',
  standalone: true,
  imports: [PedidosListComponent, PedidosTotalComponent],
  templateUrl: './pedidos-shell.component.html',
  styleUrl: './pedidos-shell.component.css'
})
export class PedidosShellComponent {

}
