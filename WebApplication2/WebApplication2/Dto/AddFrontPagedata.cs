using Google.Protobuf.WellKnownTypes;

namespace WebApplication2.Dto
{
    public class AddFrontPagedata
    {
        public string? ImageUrl { get; set; }

        public string? ImageTitle { get; set; }

        public string? ImageText { get; set; }

        public int? MainPageType { get; set; }
        public int? PageStatus { get; set; }

    }
}
