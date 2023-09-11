using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using RxWeb.Core.Annotations;
using RxWeb.Core.Data.Annotations;
using RxWeb.Core.Sanitizers;
using prj1.Models.Enums.Main;
using prj1.BoundedContext.SqlContext;
namespace prj1.Models.Main
{
    [Table("Tests",Schema="dbo")]
    public partial class Test
    {
		#region TestId Annotations

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key]
		#endregion TestId Annotations

        public int TestId { get; set; }

		#region TestName Annotations

        [Required]
        [MaxLength(50)]
		#endregion TestName Annotations

        public string TestName { get; set; }


        public Test()
        {
        }
	}
}