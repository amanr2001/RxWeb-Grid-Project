import { prop,propObject,propArray,required,maxLength,range  } from "@rxweb/reactive-form-validators"
import { gridColumn } from "@rxweb/grid"


export class vCandidateBase {

//#region candidateId Prop
        @gridColumn({visible: true, columnIndex:0, allowSorting: true, headerKey: 'candidateId', keyColumn: true})
        candidateId : number;
//#endregion candidateId Prop


//#region firstName Prop
        @gridColumn({visible: true, columnIndex:1, allowSorting: true, headerKey: 'firstName', keyColumn: false})
        firstName : string;
//#endregion firstName Prop


//#region emailId Prop
        @gridColumn({visible: true, columnIndex:2, allowSorting: true, headerKey: 'emailId', keyColumn: false})
        emailId : string;
//#endregion emailId Prop


//#region designation Prop
        @gridColumn({visible: true, columnIndex:3, allowSorting: true, headerKey: 'designation', keyColumn: false})
        designation : string;
//#endregion designation Prop


//#region experience Prop
        @gridColumn({visible: true, columnIndex:4, allowSorting: true, headerKey: 'experience', keyColumn: false})
        experience : number;
//#endregion experience Prop

}