import './PhotoUploader.scss';
import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { LinkButton } from '../Button';
import { Input } from 'reactstrap';
import ProgressBar from '../ProgressBar';
import PhotoImg from '../PhotoImg';
import { uploadFile, getDownloadFileUrl } from '../../../api';

class PhotoUploader extends Component {
    state = {
        photo: {
            loadComplete: true,
            loading: false,
        }
    }

    editPhotoClick = e => {
        e.preventDefault();
        this.photoInput.click();
    }

    onPhotoUploadProgress = e => {
        const { progress: previousProgress = 0 } = this.state.photo;
        const currentProgress = e.loaded / e.total * 100;

        // Чтобы событие не срабатывало слишком часто
        if (currentProgress === 100 || currentProgress - previousProgress > 10) {
            this.setState(state => {
                return {
                    ...state,
                    photo: {
                        ...state.photo,
                        progress: currentProgress,
                    }
                }
            });
        }
    }

    onPhotoChanged = async e => {
        const photo = e.target.files[0];
        if (photo == null) {
            return;
        }

        if (!photo.type.startsWith('image/')) {
            this.props.onIncorrectType('Некорректный тип фото', photo.type);
            return;
        }

        this.setPhotoState(false, true, 0);
        try {
            const response = await uploadFile(photo, null, this.props.uploadExtraParams, this.onPhotoUploadProgress);
            this.setPhotoState(true, false, 100);
            this.props.onPhotoChanged(response.data);
        } catch (error) {
            this.props.onUploadError('При загрузке фото произошла ошибка', error);
            this.setPhotoState(true, false, 100);
        }
    }

    setPhotoState(loadComplete, loading, progress) {
        this.setState({
            photo: { loadComplete, loading, progress }
        });
    }

    savePhotoInput = input => {
        this.photoInput = input;
    }

    renderPhotoFooter = () => {
        const { photo } = this.state;
        let content;
        if (photo.loading) {
            content = <ProgressBar value={photo.progress} thin />;
        } else {
            content =
                <LinkButton onClick={this.editPhotoClick}>
                    {this.props.photoId ? 'изменить фото' : 'добавить фото'}
                </LinkButton>;
        }

        return (
            <div className="photo-uploader-photo-footer mt-1 text-center">
                {content}
                <Input type="file" className="d-none" innerRef={this.savePhotoInput} onChange={this.onPhotoChanged} accept="image/*" />
            </div>
        );
    }

    render() {
        const { photoId, className, readOnly } = this.props;
        let href;
        if (photoId) {
            href = `${getDownloadFileUrl(photoId)}`;
        }

        const resultClass = `photo-uploader-photo d-flex flex-column ${className}`;

        return (
            <div className={resultClass}>
                <a href={href} target="__blank" className="d-flex align-items-center border">
                    <PhotoImg photoId={photoId} className="mx-auto" />
                </a>
                {!readOnly && this.renderPhotoFooter()}
            </div>
        );
    }
}

PhotoUploader.propTypes = {
    photoId: PropTypes.string,
    className: PropTypes.string,
    onPhotoChanged: PropTypes.func,
    onUploadError: PropTypes.func,
    onIncorrectType: PropTypes.func,
    uploadExtraParams: PropTypes.object,
    readOnly: PropTypes.bool,
}

PhotoUploader.defaultProps = {
    className: '',
    onPhotoChanged: x => x,
    onUploadError: x => x,
    onIncorrectType: x => x,
}

export default PhotoUploader;