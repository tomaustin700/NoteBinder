using NoteBinder.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NoteBinder.Views
{
    /// <summary>
    /// Interaction logic for NoteBinderView.xaml
    /// </summary>
    public partial class NoteBinderView : UserControl
    {
        public NoteBinderView()
        {
            InitializeComponent();
            DataContext = new NoteBinderViewModel();
        }

        private void textBox_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ((TextBox)sender).Focus();
        }
    }
      
}
