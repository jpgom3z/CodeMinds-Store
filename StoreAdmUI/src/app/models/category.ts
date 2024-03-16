import { CategoryState } from "./categoryState";

export interface Category {
    id: number;
    name: string;
    categoryState: CategoryState;
}