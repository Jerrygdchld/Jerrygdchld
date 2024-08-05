export interface BaseEntity {
    id?: number,
    active?: boolean,
    deleted?: boolean,
    creator?: number,
    updator?: number,
    deletor?: number,
    dateCreated?: Date,
    dateUpdated?: Date,
    dateDeleted?: Date,
    externalId?: string,
}
