using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epicenterWin
{
    public abstract class DbEntity
    {
        [UnecessaryColumnAttribute]
        public int ID { get; set; }
    }
}