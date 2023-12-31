using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using RxWeb.Core.Annotations;
using RxWeb.Core.Data.Annotations;
using RxWeb.Core.Sanitizers;
using EFcoreRxweb.BoundedContext.SqlContext;
namespace EFcoreRxweb.Models.Main
{
    [Table("vCandidates",Schema="dbo")]
    public partial class vCandidate
    {
		#region CandidateId Annotations

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key]
		#endregion CandidateId Annotations

        public int CandidateId { get; set; }


        public string FirstName { get; set; }


        public string EmailId { get; set; }


        public string Designation { get; set; }


        public int Experience { get; set; }


        public vCandidate()
        {
        }
	}
}