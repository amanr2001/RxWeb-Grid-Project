using CleanArchitecture1.BoundedContext.SqlContext;
using CleanArchitecture1.Models.Enums.Main;
using RxWeb.Core.Annotations;
using RxWeb.Core.Data.Annotations;
using RxWeb.Core.Sanitizers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture1.Models.Main
{
    [Table("ComponentLanguageContents", Schema = "dbo")]
    public partial class ComponentLanguageContent
    {
        #region ComponentLanguageContentId Annotations

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key]
        #endregion ComponentLanguageContentId Annotations

        public int ComponentLanguageContentId { get; set; }

        #region ComponentKeyId Annotations

        [Range(1, int.MaxValue)]
        [Required]
        [RelationshipTableAttribue("LanguageContentKeys", "dbo", "", "ComponentKeyId")]
        #endregion ComponentKeyId Annotations

        public int ComponentKeyId { get; set; }

        #region LanguageContentId Annotations

        [Range(1, int.MaxValue)]
        [Required]
        [RelationshipTableAttribue("LanguageContents", "dbo", "", "LanguageContentId")]
        #endregion LanguageContentId Annotations

        public int LanguageContentId { get; set; }


        public string En { get; set; }


        public string Fr { get; set; }

        #region LanguageContentKey Annotations

        [ForeignKey(nameof(ComponentKeyId))]
        [InverseProperty(nameof(CleanArchitecture1.Models.Main.LanguageContentKey.ComponentLanguageContents))]
        #endregion LanguageContentKey Annotations

        public virtual LanguageContentKey LanguageContentKey { get; set; }

        #region LanguageContent Annotations

        [ForeignKey(nameof(LanguageContentId))]
        [InverseProperty(nameof(CleanArchitecture1.Models.Main.LanguageContent.ComponentLanguageContents))]
        #endregion LanguageContent Annotations

        public virtual LanguageContent LanguageContent { get; set; }


        public ComponentLanguageContent()
        {
        }
    }
}