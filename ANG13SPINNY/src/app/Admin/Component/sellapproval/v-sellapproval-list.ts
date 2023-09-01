import { actionColumn, gridColumn } from '@rxweb/grid';
//Generated Imports

// @actionColumn({
//     name: '',
//     allowSorting: false,
//     configuredTemplate: { templateName: 'action' }, columnIndex: 4, headerTitle: "Action", class: ["div-td".split(' ')]
// })
export class vDegreeLookupBase {
    // cartype!: string
  
    //#region id Prop
    @gridColumn({ visible:true, columnIndex: 0, allowSorting: true, headerKey: 'carid', headerTitle: 'Carid', keyColumn: true, class: ['text-center'] })
    carid!: number;
    // #endregion id Prop


    //#region degreeName Prop
    @gridColumn({ visible: true, columnIndex: 1, name: "carbrand", headerCellClass: 'text-center'.split(' '),keyColumn: true, headerKey: 'carbrand', headerTitle: 'Carbrand'})
    carbrand!: HTMLButtonElement;
    //#endregion degreeName Prop


    // @gridColumn({
    //     visible: true,allowSorting:false,configuredTemplate: { templateName: "actionpart" }, columnIndex: 4, headerTitle: "button",  headerCellClass: 'text-center'.split(' ')
    // })
    // button!: string;

    @gridColumn({
      visible: true, allowSorting: true, columnIndex: 2, name: "carmodel", headerCellClass: 'text-center'.split(' '),headerKey: 'carmodel', headerTitle: 'carmodel'
    })
    carmodel!:string;
    @gridColumn({
      visible: true,allowSorting: false, columnIndex: 3, name: "cartype", headerCellClass: 'text-center'.split(' '),headerKey: 'cartype', headerTitle: 'cartype'
    })
    cartype!:string;
    @gridColumn({
      visible: true,allowSorting: false, columnIndex: 4, name: "price", headerCellClass: 'text-center'.split(' '),headerKey: 'price', headerTitle: 'price'
    })
    price!:string;
    @gridColumn({
      visible: true,allowSorting: false, columnIndex: 5, name: "year", headerCellClass: 'text-center'.split(' '),headerKey: 'year', headerTitle: 'year'
    })
    year!:string;

    @gridColumn({
      visible:true,allowSorting:false,columnIndex:6,name:"approval", headerCellClass: 'text-center'.split(' '), headerTitle: 'Status',
    
    })
    approval!:string;
  


    @gridColumn({
        isAscending: false,
        visible: true,
        columnIndex: 7,
        // allowSorting: true,
        headerTitle: 'Approve',
        headerCellClass: 'text-center'.split(' '),
        template: {
          div: {
            class: 'd-flex'.split(' '),
            childrens: [
              {
                div: {
                  childrens: [
                    {
                      button: {
                          class: 'btn text-light btn-success fs-6'.split(' '),
                          event: {
                              click: "onClick",
                            },
                            childrens: [
                                {
                                    i: {
                                        class: 'fa-solid fa-floppy-disk'.split(' '),
                                    },
                                    text:{text:"Approve"}
                          },
                        ],
                      },
                    },
                  ],
                },
                
              },
            ],
          },
        },
      })
      button!: HTMLButtonElement;

      @gridColumn({
        visible:true,allowSorting:false,columnIndex:8,name:"Deny", headerCellClass: 'text-center'.split(' '), headerTitle: 'Deny',configuredTemplate:{templateName:"denytemp"}
      })
      deny!:HTMLButtonElement;
    
    // @gridColumn({
    //     isAscending: false,
    //     visible: true,
    //     columnIndex: 8,
    //     allowSorting: true,
    //     headerTitle: 'cartype',
    //     headerCellClass: 'text-center'.split(' '),
    //     template: {
    //       div: {
    //         class: 'd-flex'.split(' '),
    //         childrens: [
    //           {
    //             div: {
    //               childrens: [
    //                 {
    //                   button: {
    //                       class: 'btn text-success fs-6'.split(' '),
    //                       event: {
    //                           click: "onClick",
    //                         },
    //                         childrens: [
    //                             {
    //                                 i: {
    //                                     class: 'fa-solid fa-floppy-disk'.split(' '),
    //                                 },
    //                                 text:{text:"Example"}
    //                       },
    //                     ],
    //                   },
    //                 },
    //               ],
    //             },
                
    //           },
    //         ],
    //       },
    //     },
    //   })
    //   cartyp!: HTMLButtonElement;

}