using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace JumbledWordSolver.View
{
    /// <summary>
    /// Interaction logic for JumbledWordsView.xaml
    /// </summary>
    public partial class JumbledWordsView : UserControl
    {
        public JumbledWordsView()
        {
            InitializeComponent();
        }

        private void btnClick_OpenBrowser(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"; ;
            if (openFileDialog.ShowDialog() == true)
            {
                filePath.Text = openFileDialog.FileName;
            }
        }
    }
}
