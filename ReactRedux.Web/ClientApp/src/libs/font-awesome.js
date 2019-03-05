import { library } from '@fortawesome/fontawesome-svg-core';
import {
    faAddressCard, faHome, faSearch, faChartPie, faFileAlt, faFileInvoice, faFileImport, faUser, faUsers, faTools,
    faSignOutAlt, faCog, faPlusCircle, faAngleUp, faAngleDown, faFileWord, faFileExcel, faFilePowerpoint, faFilePdf, faFileCsv,
    faFileArchive, faFileImage, faFileAudio, faFileVideo, faEdit, faSave
} from '@fortawesome/free-solid-svg-icons';

import {
    faFile as faFileR, faTimesCircle as faTimesCircleR
} from '@fortawesome/free-regular-svg-icons';

import {
    faFacebook, faVk, faOdnoklassniki, faTwitter, faInstagram, faWhatsapp, faViber, faSkype, faTelegram, faYoutube, faGooglePlus,
    faTumblr, faPinterest
} from '@fortawesome/free-brands-svg-icons';

library.add(
    faAddressCard, faHome, faSearch, faChartPie, faFileR, faFileAlt, faFileInvoice, faFileImport, faUser, faUsers, faTools, faSignOutAlt, faCog,
    faPlusCircle, faAngleUp, faAngleDown, faFacebook, faVk, faOdnoklassniki, faTwitter, faInstagram, faWhatsapp, faViber, faSkype, faTelegram, faYoutube,
    faGooglePlus, faTumblr, faPinterest, faFileWord, faFileExcel, faFilePowerpoint, faFilePdf, faFileCsv,
    faFileArchive, faFileImage, faFileAudio, faFileVideo, faTimesCircleR, faEdit, faSave
);

export const getIconByExtension = extension => {
    let ext = extension;
    if (!ext) {
        ext = '';
    }

    switch (ext.trim().toLowerCase()) {
        case 'doc':
        case 'docx':
            return {
                icon: 'file-word',
                color: '#2a5699',
            }

        case 'xls':
        case 'xlsx':
            return {
                icon: 'file-excel',
                color: '#207245',
            };

        case 'ppt':
        case 'pptx':
            return {
                icon: 'file-powerpoint',
                color: '#cb4a32',
            };

        case 'pdf':
            return {
                icon: 'file-pdf',
                color: '#e73118',
            };

        case 'csv':
            return {
                icon: 'file-csv',
                color: '#589b00',
            };

        case 'zip':
        case 'rar':
        case 'iso':
        case 'tar':
        case '7z':
        case 's7z':
        case 'cab':
            return {
                icon: 'file-archive',
                color: '#fcb433',
            };

        case 'png':
        case 'jpg':
        case 'jpeg':
        case 'gif':
        case 'bmp':
        case 'tiff':
            return {
                icon: 'file-image',
                color: '#e24075',
            };

        case 'aac':
        case 'aiff':
        case 'amr':
        case 'm4a':
        case 'm4b':
        case 'm4p':
        case 'mp3':
        case 'oga':
        case 'wav':
        case 'wma':
            return {
                icon: 'file-audio',
                color: '#38a3ff',
            };

        case 'avi':
        case 'flv':
        case 'wmv':
        case 'mov':
        case 'mpg':
        case 'mpeg':
        case 'mp2':
        case 'm2v':
        case 'mp4':
        case 'm4v':
        case 'vob':
        case 'ogv':
        case 'ogg':
        case 'mkv':
        case '3gp':
            return {
                icon: 'file-video',
                color: '#aa1baf',
            };

        default:
            return {
                icon: ['far', 'file'],
                color: 'darkgray',
            }
    }
}