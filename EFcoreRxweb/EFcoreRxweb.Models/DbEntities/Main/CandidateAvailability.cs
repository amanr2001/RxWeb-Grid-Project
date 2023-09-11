using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using RxWeb.Core.Annotations;
using RxWeb.Core.Data.Annotations;
using RxWeb.Core.Sanitizers;
using EFcoreRxweb.BoundedContext.SqlContext;
namespace EFcoreRxweb.Models.Main
{
    [Table("CandidateAvailabilities",Schema="dbo")]
    public partial class CandidateAvailability
    {
		#region CandidateAvailabilityId Annotations

        [Range(1,int.MaxValue)]
        [Required]
		#endregion CandidateAvailabilityId Annotations

        public int CandidateAvailabilityId { get; set; }

		#region AvailableDate Annotations

        [Required]
		#endregion AvailableDate Annotations

        public System.DateTimeOffset AvailableDate { get; set; }

		#region FromTime Annotations

        [Required]
		#endregion FromTime Annotations

        public TimeSpan FromTime { get; set; }

		#region ToTime Annotations

        [Required]
		#endregion ToTime Annotations

        public TimeSpan ToTime { get; set; }

		#region CandidateId Annotations

        [Range(1,int.MaxValue)]
        [Required]
		#endregion CandidateId Annotations

        public int CandidateId { get; set; }


        public CandidateAvailability()
        {
        }
	}
}