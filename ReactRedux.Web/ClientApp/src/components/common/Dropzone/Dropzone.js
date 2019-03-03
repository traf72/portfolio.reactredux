import './Dropzone.scss';
import React from 'react'
import PropTypes from 'prop-types';
import ReactDropzone from 'react-dropzone'
import ProgressBar from '../../common/ProgressBar';
import Button from '../../common/Button';
import ValidationMessage from '../../common/ValidationMessage';
import { uploadFile, getDownloadFileUrl } from '../../../api';
import uuid from 'uuid/v1';
import { getFileExtension, getFileSize } from '../../../utils';
import { getIconByExtension } from '../../../libs/font-awesome';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'

class Dropzone extends React.Component {
    static propTypes = {
        files: PropTypes.arrayOf(PropTypes.shape({
            id: PropTypes.string.isRequired,
            name: PropTypes.string.isRequired,
            size: PropTypes.number.isRequired,
            progress: PropTypes.number,
            uploadComplete: PropTypes.bool,
            error: PropTypes.string,
        })).isRequired,
        onUpload: PropTypes.func,
        onFileChanged: PropTypes.func,
        onFileRemoved: PropTypes.func,
        extraParams: PropTypes.object,
        accept: PropTypes.string,
        readOnly: PropTypes.bool,
        downloadFilesInNewTab: PropTypes.bool,
    }

    static defaultProps = {
        accept: '',
        onUpload: x => x,
        onFileChanged: x => x,
        onFileRemoved: x => x,
    }

    fileChanged = (fileId, changes) => {
        const file = this.getFile(fileId);
        if (file) {
            this.props.onFileChanged({ ...file, ...changes });
        }
    }

    onProgress(fileId, e) {
        const file = this.getFile(fileId);
        if (!file) {
            return;
        }

        const { progress: previousProgress = 0 } = file;
        const currentProgress = e.loaded / e.total * 100;

        // Чтобы событие не срабатывало слишком часто и не тормозило браузер
        if (currentProgress === 100 || currentProgress - previousProgress > 10) {
            this.props.onFileChanged({ ...file, ...{ progress: currentProgress } });
        }
    }

    getFile = fileId => {
        return this.props.files.find(f => f.id === fileId);
    }

    onDrop = files => {
        const uploadFiles = [];
        for (let file of files) {
            const fileId = uuid();
            this.uploadFile(file, fileId);
            uploadFiles.push({
                id: fileId,
                name: file.name,
                mimeType: file.type,
                size: file.size,
                uploadComplete: false,
            });
        }

        this.props.onUpload(uploadFiles);
    }

    async uploadFile(file, fileId) {
        try {
            await uploadFile(file, fileId, this.props.extraParams, e => this.onProgress(fileId, e));
            this.fileChanged(fileId, { uploadComplete: true });
        } catch (error) {
            this.fileChanged(fileId, { uploadComplete: true, error: 'Ошибка' });
        }
    }

    removeFile(e, file) {
        e.preventDefault();
        this.props.onFileRemoved(file);
    }

    renderDropzoneMessage = (isDragAccept, isDragReject) => {
        let message = 'Перетащите файлы сюда';
        if (isDragAccept) {
            message = 'Бросьте файлы';
        } else if (isDragReject) {
            message = 'Неподдерживаемые типы файлов';
        }

        return <div className="dropzone-message text-muted mx-auto">{message}</div>;
    }

    renderFiles() {
        return (
            <ul className="dropzone-file-files list-inline m-0">
                {this.props.files.map(f => this.renderFile(f))}
            </ul>
        );
    }

    renderFile(file) {
        const { id, name, size } = file;
        return (
            <li className="dropzone-file list-inline-item mx-2 mt-2 align-top" key={id}>
                {this.renderFilePreview(file)}
                <div className="dropzone-file-name text-truncate text-center" title={name}>
                    {name}
                </div>
                <div className="dropzone-file-size text-center">
                    {getFileSize(size)}
                </div>
                {!this.props.readOnly && this.renderFileExtraInfo(file)}
            </li>
        );
    }

    renderFilePreview(file) {
        const { name, mimeType, uploadComplete = true, error } = file;
        const uploadSuccess = uploadComplete && !error;

        let href;
        if (uploadSuccess) {
            href = `${getDownloadFileUrl(file.id)}`;
        }

        let preview;
        if (uploadSuccess && mimeType.startsWith('image/')) {
            preview = <img className="dropzone-file-preview-image" src={href} alt={name} />;
        } else {
            const fileExtension = getFileExtension(name);
            const icon = getIconByExtension(fileExtension);
            preview = <FontAwesomeIcon className="dropzone-file-preview-icon" {...icon} fixedWidth />;
        }

        const target = this.props.downloadFilesInNewTab || !this.props.readOnly ? '_blank' : null;
        return (
            <a className="dropzone-file-preview" href={href} target={target} title={name}>
                {preview}
                {!this.props.readOnly && <FontAwesomeIcon className="dropzone-file-delete-icon" icon={['far', 'times-circle']} onClick={e => this.removeFile(e, file)} title="Удалить" />}
            </a>
        );
    }

    renderFileExtraInfo(file) {
        const { error, progress = 0, uploadComplete = true } = file;

        let extraInfo = <ProgressBar className="dropzone-file-progress" value={progress} thin />;
        if (error) {
            extraInfo = <ValidationMessage className="dropzone-file-error">{error}</ValidationMessage>;
        }

        const extraInfoVisibleClass = !uploadComplete || error ? '' : 'invisible';
        return (
            <div className={`${extraInfoVisibleClass} dropzone-file-extra-info text-center`}>
                {extraInfo}
            </div>
        );
    }

    render() {
        const { readOnly } = this.props;

        return (
            <ReactDropzone onDrop={this.onDrop} disabled={readOnly} accept={this.props.accept}>
                {({ getRootProps, getInputProps, isDragActive, isDragAccept, isDragReject, acceptedFiles, rejectedFiles, open }) => {
                    let dragClass = '';
                    if (!readOnly) {
                        if (isDragActive) {
                            dragClass = 'dropzone-active';
                        }
                        if (isDragReject) {
                            dragClass += ' dropzone-rejected';
                        }
                    }

                    let className = 'dropzone';
                    if (readOnly) {
                        className += ' dropzone-readonly';
                    }

                    return (
                        <div>
                            {!readOnly && <Button color="info" className="dropzone-add-btn mb-3 py-1" onClick={open}>Добавить файлы</Button>}
                            <div {...getRootProps({ onClick: evt => evt.preventDefault() })} className={`${className} d-flex align-items-center w-100 ${dragClass}`}>
                                <input {...getInputProps()} />
                                {readOnly || this.props.files.length ? this.renderFiles() : this.renderDropzoneMessage(isDragAccept, isDragReject)}
                            </div>
                        </div>
                    );
                }}
            </ReactDropzone>
        );
    }
}

export default Dropzone;