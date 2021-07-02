using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework___5
{
    [Serializable]
    public class ToDo
    {
        public string Title { get; set; }

        public bool IsDone  { get; set; }

        public ToDo()
        {

        }

        public ToDo(string title)
        {
            Title = title;
            IsDone = false;
        }
    }
}
