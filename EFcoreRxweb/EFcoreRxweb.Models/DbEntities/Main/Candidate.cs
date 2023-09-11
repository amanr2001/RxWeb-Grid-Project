using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using RxWeb.Core.Annotations;
using RxWeb.Core.Data.Annotations;
using RxWeb.Core.Sanitizers;
using EFcoreRxweb.BoundedContext.SqlContext;
namespace EFcoreRxweb.Models.Main
{
    [Table("Candidates",Schema="dbo")]
    public partial class Candidate
    {
		#region CandidateId Annotations

        [Range(1,int.MaxValue)]
        [Required]
		#endregion CandidateId Annotations

        public int CandidateId { get; set; }

		#region FirstName Annotations

        [Required]
        [MaxLength(100)]
		#endregion FirstName Annotations

        public string FirstName { get; set; }

		#region EmailId Annotations

        [Required]
        [MaxLength(50)]
		#endregion EmailId Annotations

        public string EmailId { get; set; }

		#region CountryId Annotations

        [Range(1,int.MaxValue)]
        [Required]
		#endregion CountryId Annotations

        public int CountryId { get; set; }

		#region Designation Annotations

        [Required]
        [MaxLength(50)]
		#endregion Designation Annotations

        public string Designation { get; set; }

		#region Experience Annotations

        [Range(1,int.MaxValue)]
        [Required]
		#endregion Experience Annotations

        public int Experience { get; set; }


        public Candidate()
        {
        }
	}
}