import { ArticuloListaModel } from "../../articulo/common/models/articulo-lista-model";

export interface PedidoModel{
    articulo: ArticuloListaModel
    cantidad: number
}