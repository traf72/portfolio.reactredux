import emailValidatorExternal from 'email-validator';

export const requireValidator = (message = 'Введите значение', options = {}) => {
    const { trimSpaceString = true } = options;

    return value => {
        let normalizedValue = value || '';
        normalizedValue = normalizedValue.toString();
        if (trimSpaceString) {
            normalizedValue = normalizedValue.trim();
        }
        return !normalizedValue ? message : null;
    }
}

export const emailValidator = (message = 'Некорректный email', options = {}) => {
    const { validIfEmpty = true } = options;

    return value => {
        if (validIfEmpty && isEmpty(value)) {
            return null;
        }
        return !emailValidatorExternal.validate(value) ? message : null;
    }
}

export const regexValidator = (regex, message = 'Некорректное значение', options = {}) => {
    const { validIfEmpty = true } = options;

    return value => {
        if (!regex || (validIfEmpty && isEmpty(value))) {
            return null;
        }

        return !regex.test(value) ? message : null;
    }
}

export const yearValidator = (message = 'Год должен иметь 4 цифры', options = {}) => {
    return regexValidator(/\d{4}/, message, options);
}

export const phoneValidator = (message = 'Телефон не соответствует маске', options = {}) => {
    return regexValidator(/\+7 ?\(?\d{3}\)? ?\d{3}-?\d{2}-?\d{2}/, message, options);
}

const isEmpty = value => {
    return !value || !value.toString().trim();
}