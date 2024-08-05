export interface StandardReply<T> {
    success: boolean,
    messages: string[],
    exceptions: any[],
    response: T
}
