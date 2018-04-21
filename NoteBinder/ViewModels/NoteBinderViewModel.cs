using NoteBinder.Classes;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBinder.ViewModels
{
    public class NoteBinderViewModel : BaseViewModel
    {
        #region Fields
        private ObservableCollection<NotePane> _panes;
        private int _selectedTab;

        #endregion



        public int SelectedTab
        {
            get { return _selectedTab; }
            set
            {
                _selectedTab = value;
                RaisePropertyChanged();
            }
        }


        #region Properties
        public ObservableCollection<NotePane> Panes
        {
            get { return _panes; }
            set
            {
                _panes = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Constructor
        public NoteBinderViewModel()
        {
            SaveCommand = new DelegateCommand(Save);
            OpenCommand = new DelegateCommand(Open);
            NewCommand = new DelegateCommand(New);

        }
        #endregion

        #region Commands

        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand OpenCommand { get; set; }
        public DelegateCommand NewCommand { get; set; }

        #endregion

        #region Methods

        public override void Loaded()
        {
            Panes = new ObservableCollection<NotePane>();
            Panes.Add(new NotePane() { Header = "Test Header", Notes = "Lorem ipsum blah blah blah" });
            Panes.Add(new NotePane() { Header = "Test Header2", Notes = "Lorem ipsum blah blah blah" });

        }

        public void New()
        {

        }

        public void Save()
        {

        }

        public void Open()
        {

        }
        #endregion
    }
}
