using System.Collections.Generic;

namespace prj1.Models
{
	public class SecurityConfig
    {
        public string[] AllowedHosts { get; set; }

		public string[] AllowedIps { get; set; }
    }
}

