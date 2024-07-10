import { Routes } from '@angular/router';
import { PrimerComponentComponent } from './procesos/primer-component/primer-component.component';
import { ReporteComponent } from './procesos/reporte/reporte.component';
import { ObservaComponent } from './procesos/observa/observa.component';
import { ArticuloListarComponent } from './procesos/articulo/articulo-listar/articulo-listar.component';
import { ArticuloListarDeclarativoComponent } from './procesos/articulo/articulo-listar-declarativo/articulo-listar-declarativo.component';
import { ArticuloEditarComponent } from './procesos/articulo/articulo-editar/articulo-editar.component';
import { AutenticaComponent } from './procesos/seguridad/login/autentica/autentica.component';
import { AutorizadoComponent } from './background/autorizado/autorizado.component';
import { ExternoComponent } from './background/externo/externo.component';
import { authGuard } from './comunes/seguridad/auth.guard';
import { autorizaGuard } from './comunes/seguridad/autoriza.guard';
import { NoAutorizadoComponent } from './comunes/componentes/no-autorizado/no-autorizado.component';
import { SignalsComponent } from './procesos/signals/signals.component';
import { PedidosShellComponent } from './procesos/pedidos/pedidos-shell/pedidos-shell.component';

export const routes: Routes = [

    {
        path: "",
        canActivate: [authGuard],
        data: { parametro: "algo" },
        component: AutorizadoComponent, children: [
            { path: "primera", component: PrimerComponentComponent },
            {
                path: "reporte", component: ReporteComponent,
                canActivate: [autorizaGuard],
                data: { opcion: "reporte" }
            },
            {
                path: "observable", component: ObservaComponent,
                canActivate: [autorizaGuard], data: { opcion: "observable" }
            },
            {
                path: "articulos",
                canActivate: [autorizaGuard],
                data: { opcion: "articulos" },
                loadComponent: () =>
                    import('./procesos/articulo/articulo-listar/articulo-listar.component')
                        .then(c => c.ArticuloListarComponent)
            },
            {
                path: "articulodeclara",
                loadComponent: () =>
                    import('./procesos/articulo/articulo-listar-declarativo/articulo-listar-declarativo.component')
                        .then(c => c.ArticuloListarDeclarativoComponent)

            },
            { path: "articulodetalle/:cod", component: ArticuloEditarComponent },
            { path: "articulodetalle", component: ArticuloEditarComponent },
            { path: "noautorizado", component: NoAutorizadoComponent},
            {path: "signals", component: SignalsComponent},
            {path: "pedidos", component: PedidosShellComponent}
        ]
    },
    {
        path: "ext", component: ExternoComponent, children: [
            { path: "login", component: AutenticaComponent },

        ]
    }


];
