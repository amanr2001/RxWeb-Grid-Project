using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using RxWeb.Core.Annotations;
using RxWeb.Core.Data.Annotations;
using RxWeb.Core.Sanitizers;
using prj1.BoundedContext.SqlContext;
namespace prj1.Models.Main
{
    [Table("vTestRecords",Schema="dbo")]
    public partial class vTestRecord
    {
		#region TestId Annotations

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key]
		#endregion TestId Annotations

        public int TestId { get; set; }


        public string TestName { get; set; }


        public vTestRecord()
        {
        }
	}
}