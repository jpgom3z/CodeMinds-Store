import { RouterModule, Routes } from '@angular/router';
import { MainLayout } from './modules/shared/layouts/main/main.layout';

export const routes: Routes = [
    {
        path: '',
        component: MainLayout
    }
];