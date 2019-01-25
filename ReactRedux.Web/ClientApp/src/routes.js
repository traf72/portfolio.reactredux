import { generatePath, matchPath } from 'react-router';

class Route {
    constructor(url, title) {
        this.url = url;
        this.title = title;
    }

    buildUrl(params) {
        if (!params) {
            return this.url;
        }

        return generatePath(this.url, params);
    }
}

export const isPathMatch = (path, route, options = { exact: true, strict: false }) => {
    const routeObj = {
        path: route,
        ...options
    };

    return matchPath(path, routeObj) != null;
}

export const dashboard = new Route('/', 'Главная');
export const personNew = new Route('/person/new', 'Новый резервист');
export const personEdit = new Route('/person/edit/:id(\\d+)', 'Редактировать резервиста');
export const person = new Route('/person/:id(\\d+)', 'Карточка резервиста');
export const search = new Route('/search', 'Расширенный поиск');
export const charts = new Route('/charts', 'Диаграммы');
export const reports = new Route('/reports', 'Отчёты');
export const importRoute = new Route('/import', 'Импорт');
export const users = new Route('/admin/users', 'Пользователи');
export const usersActions = new Route('/admin/users-actions', 'Действия пользователей');
export const attributes = new Route('/admin/attributes', 'Настройка атрибутов');

export const sidebarRoutes = {
    dashboard,
    personNew,
    search,
    charts,
    reports,
    importRoute,
    users,
    usersActions,
    attributes,
};

export const otherRoutes = {
    personEdit,
    person,
};

const allRoutes = { ...sidebarRoutes, ...otherRoutes };

export default allRoutes;