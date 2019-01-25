import React from 'react';
import { Collapse } from 'reactstrap';
import CollapsableHeader from '../common/CollapsableHeader';
import Dropzone from '../common/Dropzone';
import ToggleOpen from '../../decorators/ToggleOpen';

const FilesBlock = props => {
    if (!props.files || !props.files.length) {
        return null;
    }

    return (
        <div className="person-card-files-block">
            <CollapsableHeader className="person-card-section-header" isOpen={props.isOpen} toggleOpen={props.toggleOpen}>
                Файлы
            </CollapsableHeader>
            <Collapse isOpen={props.isOpen}>
                <div className="person-card-section">
                    <Dropzone
                        files={props.files.filter(f => f.deleted !== true)}
                        readOnly
                    />
                </div>
            </Collapse>
        </div>
    );
}

export default ToggleOpen(FilesBlock);