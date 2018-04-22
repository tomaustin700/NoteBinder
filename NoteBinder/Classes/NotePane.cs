using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NoteBinder.Classes
{
    public class NotePane : BaseNotify
    {

        private string _header;

        public string Header
        {
            get { return _header; }
            set
            {
                _header = value;
                RaisePropertyChanged();
            }
        }


        private string _notes;

        public string Notes
        {
            get { return _notes; }
            set
            {
                _notes = value;
                RaisePropertyChanged();
            }
        }


        private bool _editingHeader;
        public bool EditingHeader
        {
            get { return _editingHeader; }
            set
            {
                _editingHeader = value;
                RaisePropertyChanged();
            }
        }


    }
}
