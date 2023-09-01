import { actionColumn, gridColumn } from '@rxweb/grid';
//Generated Imports
// @actionColumn({
//     name: 'action',
//     allowSorting: false, configuredTemplate: { templateName: 'action' }, columnIndex: 4, headerTitle: "Action", class: ["div-td".split(' ')]
// })

export class vDegreeLookupBase {

    //#region id Prop
    @gridColumn({ visible: true, columnIndex: 0,allowSearch:true, allowSorting: true, headerKey: 'mainId',headerTitle:'mainId', keyColumn: true, class:['text-center'] })
    mainId!: number;
    //#endregion id Prop

    @gridColumn({visible:true,columnIndex:1,allowSearch:true, allowSorting: true,headerKey:'imageTitle',headerTitle:'Title',keyColumn:true})
    imageTitle!:string
    
    @gridColumn({visible:true,columnIndex:2,allowSearch:false,headerKey:'name',headerTitle:'Name',keyColumn:true,isFilter:true})
    name!:string

    // @gridColumn({visible:true,columnIndex:4,headerKey:'pstatus',headerTitle:'status',keyColumn:true})
    // pstatus!:string

    //#region degreeName Prop
    // @gridColumn({ visible: true, columnIndex: 2, allowSorting: true, headerKey: 'degreeName', headerTitle: 'Degree', keyColumn: false })
    // degreeName!: string;
    //#endregion degreeName Prop

// @gridColumn({
//     name: 'action',
//     allowSorting: true, configuredTemplate: { templateName: 'action' }, columnIndex: 1, headerTitle: "Action", class: ["div-td".split(' ')]
// })
// degreeName!: string;

}