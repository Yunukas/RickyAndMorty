using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickyAndMorty
{
    public class Characters
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }

        public string Species { get; set; }

        public string Type { get; set; }
        public string Gender { get; set; }
        public Dictionary<string, string> Origin { get; set; }

        public Dictionary<string, string> Location { get; set; }

        public string Image { get; set; }

        public List<string> Episodes { get; set; }
        public string URL { get; set; }

        public DateTime Created { get; set; }

        public override string ToString()
        {
            return Image;
        }

    }
}
