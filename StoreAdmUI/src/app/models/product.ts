import { Category } from "./category";
import { ProductState } from "./productState";

export interface Product {
    id: number;
    name: string;
    description: string;
    stock: number;
    price: number;
    categoryId: number;
    productStateId: number;
    cateogry: Category;
    productState: ProductState;
}