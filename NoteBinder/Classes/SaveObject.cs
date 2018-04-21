using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBinder.Classes
{
    public class SaveObject
    {
        public List<NotePane> Panes { get; set; }
        public int SelectedTab { get; set; }
    }
}
