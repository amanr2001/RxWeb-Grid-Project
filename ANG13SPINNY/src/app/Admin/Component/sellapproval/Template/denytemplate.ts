import { TemplateConfig } from "@rxweb/dom/models/template-config";

export const ACTION_GRID_TEMPLATE_FLOPPY: TemplateConfig = {

  
    div: {
      class: 'd-flex'.split(' '),
      childrens: [
        {
          div: {
            childrens: [
              {
                button: {
                    class: 'btn text-light btn-danger fs-6'.split(' '),
                    event: {
                        click: "onDeny",
                      },
                      childrens: [
                          {
                              i: {
                                  class: 'fa-solid fa-floppy-disk'.split(' '),
                              },
                              text:{text:"Deny"}
                    },
                  ],
                },
              },
            ],
          },
          
        },
      ],
    },

  }