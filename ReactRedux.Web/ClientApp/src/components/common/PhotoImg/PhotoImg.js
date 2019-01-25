import photoStub from './photo-stub.png';
import React from 'react';
import PropTypes from 'prop-types';
import { getDownloadFileUrl } from '../../../api';

const PhotoImg = ({ className, photoId, alt }) => {
    const href = photoId ? getDownloadFileUrl(photoId) : photoStub;
    return (
        <img src={href} alt={alt} className={className} />
    );
};

PhotoImg.propTypes = {
    className: PropTypes.string,
    photoId: PropTypes.string,
    alt: PropTypes.string,
}

PhotoImg.defaultProps = {
    className: '',
    alt: 'Фото',
}

export default PhotoImg;