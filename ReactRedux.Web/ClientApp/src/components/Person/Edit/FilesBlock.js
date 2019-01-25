import React from 'react';
import { Collapse } from 'reactstrap';
import CollapsableHeader from '../../common/CollapsableHeader';
import Dropzone from '../../common/Dropzone';
import ToggleOpen from '../../../decorators/ToggleOpen';
import { fileTarget } from '../../../enums';

const FilesBlock = props => {
    function onFilesUpload(files) {
        const updatedFiles = props.files.push(...files);
        handleChange(updatedFiles);
    }

    function onFileChanged(file) {
        const index = getFileIndex(file.id);
        if (index >= 0) {
            const updatedFiles = props.files.set(index, file);
            handleChange(updatedFiles);
        }
    }

    function onFileRemoved(file) {
        const index = getFileIndex(file.id);
        if (index >= 0) {
            const updatedFiles = props.files.delete(index);
            handleChange(updatedFiles);
        }
    }

    function getFileIndex(fileId) {
        return props.files.findIndex(f => f.id === fileId);
    }

    function handleChange(files) {
        props.handleStateChange({ files });
    }

    const extraParams = { target: fileTarget.PersonFile, directoryId: props.directoryId };
    return (
        <div className="person-card-files-block">
            <CollapsableHeader className="person-card-section-header" isOpen={props.isOpen} toggleOpen={props.toggleOpen}>
                Файлы
            </CollapsableHeader>
            <Collapse isOpen={props.isOpen}>
                <div className="person-card-section">
                    <Dropzone
                        files={props.files.filter(f => f.deleted !== true).toArray()}
                        onUpload={onFilesUpload}
                        onFileChanged={onFileChanged}
                        onFileRemoved={onFileRemoved}
                        extraParams={extraParams}
                    />
                </div>
            </Collapse>
        </div>
    );
}

export default ToggleOpen(FilesBlock);