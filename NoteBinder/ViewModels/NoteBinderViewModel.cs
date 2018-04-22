using Microsoft.Win32;
using NoteBinder.Classes;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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
            AddTabCommand = new DelegateCommand(AddTab);
            DeleteTabCommand = new DelegateCommand<NotePane>(DeleteTab);
            PreviousTabCommand = new DelegateCommand(PreviousTab, CanPreviousTab);
            NextTabCommand = new DelegateCommand(NextTab, CanNextTab);


        }
        #endregion

        #region Commands

        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand OpenCommand { get; set; }
        public DelegateCommand NewCommand { get; set; }
        public DelegateCommand AddTabCommand { get; set; }
        public DelegateCommand<NotePane> DeleteTabCommand { get; set; }
        public DelegateCommand PreviousTabCommand { get; set; }
        public DelegateCommand NextTabCommand { get; set; }

        #endregion

        #region Methods

        public override void Loaded()
        {
            Panes = new ObservableCollection<NotePane>();
            Panes.Add(new NotePane() { Header = "Untitled", Notes = "" });

        }

        public void New()
        {

        }

        public void Save()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog() { DefaultExt = "nbf", AddExtension = true, Filter = "NoteBinder Files (*.nbf)|*.nbf" };
            if (saveFileDialog.ShowDialog() == true)
            {

                var saveObject = new SaveObject() { Panes = Panes.ToList(), SelectedTab = SelectedTab };
                XmlSerializer serialiser = new XmlSerializer(typeof(SaveObject));
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName, false, Encoding.UTF8))
                {
                    serialiser.Serialize(writer, saveObject);
                }
            }
        }

        public void Open()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() { DefaultExt = "nbf", AddExtension = true, Filter = "NoteBinder Files (*.nbf)|*.nbf" };
            if (openFileDialog.ShowDialog() == true)
            {

                XmlSerializer serialiser = new XmlSerializer(typeof(SaveObject));
                using (StreamReader reader = new StreamReader(openFileDialog.FileName, Encoding.UTF8))
                {
                    var readObject = (SaveObject)serialiser.Deserialize(reader);
                    Panes = new ObservableCollection<NotePane>(readObject.Panes);
                    SelectedTab = readObject.SelectedTab;
                }
            }
        }

        public void AddTab()
        {
            Panes.Add(new NotePane() { Header = GetUniqueName("Untitled"), Notes = "" });
            SelectedTab = SelectedTab + 1;
        }

        public void DeleteTab(NotePane pane)
        {

        }

        private string GetUniqueName(string name)
        {
            if (!Panes.Any(x => x.Header == name))
                return name;
            else
            {
                int unique = 1;
                var tempName = name;
                do
                {
                    tempName = name + unique;
                    unique++;
                }
                while (Panes.Any(x => x.Header == tempName));

                return tempName;
            }
        }

        void PreviousTab()
        {
            SelectedTab = SelectedTab - 1;

        }

        bool CanPreviousTab()
        {
            return SelectedTab != 0;
        }

        void NextTab()
        {
            SelectedTab = SelectedTab + 1;
        }

        bool CanNextTab()
        {
            return Panes != null && SelectedTab != Panes.Count() - 1;
        }

        #endregion
    }
}
