import { BaseEntity } from "./base-entity";

export interface NamedEntity extends BaseEntity {
    externalId?: string,
    name?: string,
    description?: string,
    lookupCode?: string
}
