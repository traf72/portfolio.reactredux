export default class RequestError extends Error {
    constructor(cause, message) {
        super(message || 'При обработке вашего запроса произошла ошибка');

        this.cause = cause;
        this.name = this.constructor.name;
    }
}