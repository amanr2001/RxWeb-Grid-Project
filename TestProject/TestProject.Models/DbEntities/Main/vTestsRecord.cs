using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using RxWeb.Core.Annotations;
using RxWeb.Core.Data.Annotations;
using RxWeb.Core.Sanitizers;
using TestProject.BoundedContext.SqlContext;
namespace TestProject.Models.Main
{
    [Table("vTestsRecords",Schema="dbo")]
    public partial class vTestsRecord
    {
		#region TestId Annotations

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key]
		#endregion TestId Annotations

        public int TestId { get; set; }


        public string TestName { get; set; }


        public vTestsRecord()
        {
        }
	}
}