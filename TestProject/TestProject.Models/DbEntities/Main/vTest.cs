using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using RxWeb.Core.Annotations;
using RxWeb.Core.Data.Annotations;
using RxWeb.Core.Sanitizers;
using TestProject.BoundedContext.SqlContext;
namespace TestProject.Models.Main
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