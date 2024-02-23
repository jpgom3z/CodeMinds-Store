export class Category {
    public id: number;
    public name: string;
    public categoryStateId: number

    constructor(data: any = null) {
        //Técnica de deep copy para eliminar referencias de memoria
        data = data ? JSON.parse(JSON.stringify(data)) : {};

        this.id = data.id ?? null;
        this.name = data.name ?? null;
        this.categoryStateId = data.categoryStateId ?? null;
    }
}