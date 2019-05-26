using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Contracts
{
    public class XmlRequestParams
    {
        public string RootNode { get; set; }
        public string ItemNode { get; set; }
        public IEnumerable<string> ItemNodeNames { get; set; }
        public IEnumerable<string> Attributes { get; set; }
    }
}
