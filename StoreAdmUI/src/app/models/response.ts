import { Product } from "./product";

export interface Response {
    statusCode: number;
    success: boolean;
    messages: [];
    data: Product[];
}