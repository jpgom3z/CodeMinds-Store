import { Category } from "../categories/category.model";
import { Status } from "../state/status.model";

export class Product {
    public id: number;
    public name: string;
    public description: string;
    public price: number;
    public categoryId: Category;
    public productStateId: Status;

    constructor(data: any = null) {
        //Técnica de deep copy para eliminar referencias de memoria
        data = data ? JSON.parse(JSON.stringify(data)) : {};

        this.id = data.id ?? null;
        this.name = data.name ?? null;
        this.description = data.description ?? null;
        this.price = data.price ?? null;
        this.categoryId = new Category(data.category.id);
        this.productStateId = new Status(data.productState.id);
    }
}