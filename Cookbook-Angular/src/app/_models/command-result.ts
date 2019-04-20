export class CommandResult<T> {
    successful: boolean;
    data: T;
    exception: any;
}
