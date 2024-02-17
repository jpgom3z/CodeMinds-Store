import { Router, RouterModule, Routes } from '@angular/router';
import { MainLayout } from './modules/shared/layouts/main/main.layout';
import { NgModule } from '@angular/core';

export const routes: Routes = [
    {
        path: '',
        component: MainLayout,
        children: [
            {
                path: '',
                loadChildren: () => import('@products/products.module').then(m => m.ProductsModule)

            },
            {
                path: 'orders',
                loadChildren: () => import('@orders/orders.module').then(m => m.OrdersModule)
            },
            {
                path: 'categories',
                loadChildren: () => import('@categories/category.module').then(m => m.CategoryModule)
            },
        ]
    }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule {}

