import { prop,propObject,propArray,required,maxLength,range  } from "@rxweb/reactive-form-validators"
import { gridColumn } from "@rxweb/grid"


export class vTestBase {

//#region testName Prop
        @gridColumn({visible: true, columnIndex:0, allowSorting: true, headerKey: 'testName', keyColumn: false})
        testName : string;
//#endregion testName Prop

}