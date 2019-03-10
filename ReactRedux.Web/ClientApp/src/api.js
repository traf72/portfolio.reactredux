import axios from 'axios';

export const getCatalog = (catalogName, params) => {
    return axios.get(`api/catalog/${catalogName}`, { params });
}

export const getPerson = id => {
    return axios.get(`api/person/${id}`);
}

export const createOrEditPerson = person => {
    return axios.post(`api/person`, person);
}

export const searchForPersons = (criteria = {}) => {
    return axios.post(`api/search`, criteria);
}

export const uploadFile = (file, fileId, extraParams = {}, onProgress = x => x) => {
    const formData = new FormData();
    formData.append('file', file);
    if (fileId) {
        formData.append('fileId', fileId);
    }
    formData.append('extraParams', JSON.stringify(extraParams));

    return axios({
        url: 'api/file',
        method: 'POST',
        data: formData,
        onUploadProgress: onProgress,
    });
}

export const getDownloadFileUrl = fileId => {
    return `api/file/${fileId}`;
}
