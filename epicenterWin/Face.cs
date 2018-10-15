using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epicenterWin
{
    class Face : DbEntity
    {
        public byte[] Blob { get; set; }
        public int PersonID { get; set; }
    }
}