import { prop,propObject,propArray,required,maxLength,range  } from "@rxweb/reactive-form-validators"
import { gridColumn } from "@rxweb/grid"


export class vTestsRecordBase {

//#region testId Prop
        @gridColumn({visible: true, columnIndex:0, allowSorting: true, headerKey: 'testId', keyColumn: true})
        testId : number;
//#endregion testId Prop


//#region testName Prop
        @gridColumn({visible: true, columnIndex:1, allowSorting: true, headerKey: 'testName', keyColumn: false})
        testName : string;
//#endregion testName Prop

}