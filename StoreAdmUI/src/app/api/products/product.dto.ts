import { Product } from "./product.model";
import { Category } from "../categories/category.model";
import { Status } from "../state/status.model";
import { map } from "rxjs";

export class InsertUpdateProductDTO {
    public readonly name: string;
    public readonly description: string;
    public readonly price: number;
    public readonly categoryId: Category;
    public readonly productStateId: Status;

    constructor(data: Product) {
        //Convertimos la fecha a date string porque Angular fuerza
        //los objetos de fecha a convertirse a tiempo universal (UTC)
        //a la hora de hacer llamados de API, esencialmente cambiando la
        //hora guardada en la base de datos ya que nuestro sistema
        //no maneja conversiones de hora y sólo trabaja con hora local
        this.name = data.name;
        this.description = data.description;
        this.price = data.price;
        this.categoryId = new Category(data.categoryId);
        this.productStateId = new Status(data.productStateId)
    }
}

export class FilterProductDTO {
    public name: string;
    public description: string;
    public price: number;
    public categoryId: Category;
    public productStateId: Status;

    constructor(data: any = null) {
        //Técnica de deep copy para eliminar referencias de memoria
        data = data ? JSON.parse(JSON.stringify(data)) : {};

        this.name = data.name ?? null;
        this.description = data.description ?? null;
        this.price = data.price ?? null;
        this.categoryId = data.category.id ?? null;
        this.productStateId = data.productState.id ?? null;
    }
}