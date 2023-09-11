using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using RxWeb.Core.Annotations;
using RxWeb.Core.Data.Annotations;
using RxWeb.Core.Sanitizers;
using prj1.BoundedContext.SqlContext;
namespace prj1.Models.Main
{
    [Table("vTests",Schema="dbo")]
    public partial class vTest
    {

        public string TestName { get; set; }


        public vTest()
        {
        }
	}
}