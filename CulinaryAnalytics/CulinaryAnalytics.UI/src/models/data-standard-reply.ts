export interface DataStandardReply<T> {
    success: boolean,
    messages: string[],
    exceptions: any[],
    response: T,
    totalRecords: number
}
