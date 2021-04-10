using System.Collections.Generic;

namespace Models
{
    public class Description
    {
        public string DefaultDescription { get; set; }
        public List<Conditional> Conditionals { get; set; }
    }
}