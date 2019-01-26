import React, { Component } from 'react';
import { connect } from 'react-redux';
import PhotoUploader from '../../common/PhotoUploader';
import { Row, Col, FormGroup, Label, Input } from 'reactstrap';
import Select, { VirtualizedSelect } from '../../common/Select';
import DatePicker from '../../common/DatePicker';
import InputMask from '../../common/InputMask';
import ValidationMessage from '../../common/ValidationMessage';
import { SEX, FEDERAL_DISTRICTS, REGIONS, IDENTITY_DOCUMENTS } from '../../../ducks/Catalog';
import { showWarningAlert, showErrorAlert } from '../../../ducks/Alert';
import { phoneMask } from '../../../constants';
import { requireValidator, emailValidator, regexValidator, phoneValidator } from '../../../libs/validators';
import { fileTarget } from '../../../enums';

class PersonalInfoBlock extends Component {
    handleRegionChange = region => {
        if (region === this.props.selectedRegion) {
            return;
        }

        this.props.handleStateChange({
            selectedDistrict: region
                ? this.props[FEDERAL_DISTRICTS].data.find(x => x.id === region.federalDistrictId)
                : null,
            selectedRegion: region,
        });
    }

    handleDocumentNumberChange = e => {
        const value = e.target.value;
        this.props.handleStateChange({ documentNumber: value && value.toUpperCase() });
    }

    getDocumentNumberFormat(document) {
        return document && document.numberFormat;
    }

    getDocumentNumberRegex(document) {
        if (document && document.numberRegex) {
            return new RegExp(document.numberRegex);
        }
    }

    onPhotoUploadError = errorMsg => {
        this.props.showErrorAlert(errorMsg);
    }

    onPhotoIncorrectType = message => {
        this.props.showWarningAlert(message, 2.5);
    }

    onPhotoChanged = photoId => {
        this.props.handleStateChange({ photoId });
    }

    render() {
        const { isInputInvalid, getInputErrorMessage, handleStateChange } = this.props;

        return (
            <div className="person-card-personal-info-block person-card-section">
                <Row form>
                    <Col xs={12} sm={3} className="person-card-photo-col">
                        <PhotoUploader
                            photoId={this.props.photoId}
                            onPhotoChanged={this.onPhotoChanged}
                            onUploadError={this.onPhotoUploadError}
                            onIncorrectType={this.onPhotoIncorrectType}
                            uploadExtraParams={{
                                target: fileTarget.PersonPhoto,
                                directoryId: this.props.filesDirectoryId,
                            }}
                        />
                    </Col>
                    <Col xs={12} sm={9}>
                        <Row form>
                            <Col xs={12} lg={5}>
                                <FormGroup row>
                                    <Label for="lastName" xs={3}>Фамилия*</Label>
                                    <Col xs="8">
                                        <Input bsSize="sm" id="lastName" value={this.props.lastName} onChange={e => handleStateChange({ lastName: e.target.value })}
                                            invalid={isInputInvalid('lastName', [requireValidator('Введите фамилию')])}
                                        />
                                        <ValidationMessage className="validation-message-under">{getInputErrorMessage('lastName')}</ValidationMessage>
                                    </Col>
                                </FormGroup>
                                <FormGroup row>
                                    <Label for="firstName" xs={3}>Имя*</Label>
                                    <Col xs={8}>
                                        <Input bsSize="sm" id="firstName" value={this.props.firstName} onChange={e => handleStateChange({ firstName: e.target.value })}
                                            invalid={isInputInvalid('firstName', [requireValidator('Введите имя')])}
                                        />
                                        <ValidationMessage className="validation-message-under">{getInputErrorMessage('firstName')}</ValidationMessage>
                                    </Col>
                                </FormGroup>
                                <FormGroup row>
                                    <Label for="middleName" xs={3}>Отчество*</Label>
                                    <Col xs={8}>
                                        <Input bsSize="sm" id="middleName" value={this.props.middleName} onChange={e => handleStateChange({ middleName: e.target.value })}
                                            invalid={isInputInvalid('middleName', [requireValidator('Введите отчество')])}
                                        />
                                        <ValidationMessage className="validation-message-under">{getInputErrorMessage('middleName')}</ValidationMessage>
                                    </Col>
                                </FormGroup>
                                <FormGroup row>
                                    <Label for="sex" xs={3}>Пол*</Label>
                                    <Col xs={8}>
                                        <Select
                                            inputId="sex"
                                            value={this.props.selectedSex}
                                            onChange={item => handleStateChange({ selectedSex: item })}
                                            options={this.props[SEX].data}
                                            bsSize="sm"
                                            catalog
                                            invalid={isInputInvalid('selectedSex', [requireValidator('Выберите пол')])}
                                        />
                                        <ValidationMessage className="validation-message-under">{getInputErrorMessage('selectedSex')}</ValidationMessage>
                                    </Col>
                                </FormGroup>
                            </Col>
                            <Col xs={12} lg={7}>
                                <FormGroup row>
                                    <Label for="birthDate" xs={4}>Дата рождения*</Label>
                                    <Col xs={6}>
                                        <DatePicker
                                            id="birthDate"
                                            bsSize="sm"
                                            selected={this.props.birthDate}
                                            onChange={value => handleStateChange({ birthDate: value })}
                                            invalid={isInputInvalid('birthDate', [requireValidator('Введите дату рождения')])}
                                        />
                                        <ValidationMessage className="validation-message-under">{getInputErrorMessage('birthDate')}</ValidationMessage>
                                    </Col>
                                </FormGroup>
                                <FormGroup row>
                                    <Label for="birthPlace" xs={4}>Место рождения*</Label>
                                    <Col xs={6}>
                                        <Input bsSize="sm" id="birthPlace" value={this.props.birthPlace} onChange={e => handleStateChange({ birthPlace: e.target.value })}
                                            invalid={isInputInvalid('birthPlace', [requireValidator('Введите место рождения')])}
                                        />
                                        <ValidationMessage className="validation-message-under">{getInputErrorMessage('birthPlace')}</ValidationMessage>
                                    </Col>
                                </FormGroup>
                                <FormGroup row>
                                    <Label for="email" xs={4}>Email*</Label>
                                    <Col xs={6}>
                                        <Input type="email" bsSize="sm" id="email" value={this.props.email} onChange={e => handleStateChange({ email: e.target.value })}
                                            invalid={isInputInvalid('email', [requireValidator('Введите email'), emailValidator()])}
                                        />
                                        <ValidationMessage className="validation-message-under">{getInputErrorMessage('email')}</ValidationMessage>
                                    </Col>
                                </FormGroup>
                                <FormGroup row>
                                    <Label for="phone" xs={4}>Телефон*</Label>
                                    <Col xs={6}>
                                        <InputMask mask={phoneMask} bsSize="sm" id="phone" value={this.props.phone} onChange={e => handleStateChange({ phone: e.target.value })}
                                            invalid={isInputInvalid('phone', [requireValidator('Введите телефон'), phoneValidator()])}
                                        />
                                        <ValidationMessage className="validation-message-under">{getInputErrorMessage('phone')}</ValidationMessage>
                                    </Col>
                                </FormGroup>
                            </Col>
                        </Row>
                    </Col>
                </Row>
                <FormGroup row>
                    <Label for="federalDistrict" xs={2}>Федеральный округ*</Label>
                    <Col xs={5}>
                        <Select
                            inputId="federalDistrict"
                            value={this.props.selectedDistrict}
                            onChange={item => handleStateChange({ selectedDistrict: item })}
                            options={this.props[FEDERAL_DISTRICTS].data}
                            isDisabled
                            catalog
                            bsSize="sm"
                        />
                    </Col>
                </FormGroup>
                <FormGroup row>
                    <Label for="region" xs={2}>Регион*</Label>
                    <Col xs={5}>
                        <Select
                            inputId="region"
                            value={this.props.selectedRegion}
                            onChange={this.handleRegionChange}
                            options={this.props[REGIONS].data}
                            catalog
                            bsSize="sm"
                            invalid={isInputInvalid('selectedRegion', [requireValidator('Выберите регион')])}
                        />
                        <ValidationMessage className="validation-message-under">{getInputErrorMessage('selectedRegion')}</ValidationMessage>
                    </Col>
                </FormGroup>
                <FormGroup row>
                    <Label for="documentType" xs={2}>Документ*</Label>
                    <Col xs={4}>
                        <Select
                            inputId="documentType"
                            value={this.props.selectedDocument}
                            onChange={item => handleStateChange({ selectedDocument: item })}
                            options={this.props[IDENTITY_DOCUMENTS].data}
                            catalog
                            bsSize="sm"
                            invalid={isInputInvalid('selectedDocument', [requireValidator('Выберите документ')])}
                        />
                        <ValidationMessage className="validation-message-under">{getInputErrorMessage('selectedDocument')}</ValidationMessage>
                    </Col>
                </FormGroup>
                <FormGroup row>
                    <Label for="documentNumber" xs={2}>Номер документа*</Label>
                    <Col xs={2}>
                        <InputMask mask={this.getDocumentNumberFormat(this.props.selectedDocument)} value={this.props.documentNumber}
                            id="documentNumber" bsSize="sm" onChange={this.handleDocumentNumberChange}
                            invalid={isInputInvalid('documentNumber', [
                                requireValidator('Введите номер'),
                                regexValidator(this.getDocumentNumberRegex(this.props.selectedDocument), 'Номер не соответствует маске')
                            ])}
                        />
                        <ValidationMessage className="validation-message-under">{getInputErrorMessage('documentNumber')}</ValidationMessage>
                    </Col>
                </FormGroup>
            </div>
        );
    }
}

export default connect(null, { showWarningAlert, showErrorAlert })(PersonalInfoBlock);