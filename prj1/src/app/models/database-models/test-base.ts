import { prop,propObject,propArray,required,maxLength,range  } from "@rxweb/reactive-form-validators"
import { gridColumn } from "@rxweb/grid"


export class TestBase {

//#region testId Prop
        @prop()
        testId : number;
//#endregion testId Prop


//#region testName Prop
        @required()
        @maxLength({value:50})
        testName : string;
//#endregion testName Prop

}