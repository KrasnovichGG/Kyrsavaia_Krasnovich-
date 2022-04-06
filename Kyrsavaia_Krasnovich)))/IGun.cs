using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kyrsavaia_Krasnovich___
{
    public  interface IGun
    {
        public string ID { get; set; }
        public string NameGun { get; set; }
        public event Action<string> Tankist;
    }
}
