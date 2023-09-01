using Google.Protobuf.WellKnownTypes;

namespace WebApplication2.Dto
{
    public class demoDto
    {
        public int pagenum { get; set; }
        public int pagesize { get; set; }
        public string? val { get; set; }

        public bool orderby {get; set;}=false;
        public string? sortby { get; set; }
    }
}
