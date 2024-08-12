import { NamedEntity } from "./named-entity";

export interface Recipe extends NamedEntity {
    companyCode: string;
    photoData: string;
}
