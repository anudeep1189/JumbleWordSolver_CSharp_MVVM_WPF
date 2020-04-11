using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//include model,command and view
using JumbledWordSolver.Model;
using JumbledWordSolver.Comand;
using JumbledWordSolver.View;
using System.ComponentModel;
using System.Windows.Input;
using Microsoft.Win32;

namespace JumbledWordSolver.ViewModel
{
    class JumbledWordSolverViewModel: INotifyPropertyChanged
    {
        public JumbledWordSolverViewModel()
        {
            JumbledWordSolverModel = new JumbledWordSolverModel();
        }

        #region btnPressed

        private ICommand btnPressed;
        public ICommand BtnPressed
        {
            get
            {
                if (btnPressed == null)
                {
                    btnPressed = new RelayCommand(ExecuteBtnPressed,CanExecuteBtnPressed,CanExecuteBtnPressedChanged);

                }
                return btnPressed;
            }
        }

        public bool CanExecuteBtnPressedChanged { get; private set; }

        private bool CanExecuteBtnPressed(object arg)
        {
            return true;
        }

        private void ExecuteBtnPressed(object obj)
        {
            switch (obj.ToString())
            {
                case "openFileBrowser":
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"; ;
                    if (openFileDialog.ShowDialog() == true)
                    {
                        JumbledWordSolverModel.InputFilePath = openFileDialog.FileName; //TODO:pass this to the textbox
                        OnPropertyChange("JumbledWordSolverModel");//notify the change
                    }
                    break;
                case "Solve":
                    //JumbledWordSolverModel.ExecuteScrambledWordManualEntryScenario();
                    JumbledWordSolverModel.ExecuteScrambledWordFileEntryScenario();
                    break;

                default:
                    break;
            }
        }

        #endregion



        private JumbledWordSolverModel _jumbledWordSolverModel;
        public JumbledWordSolverModel JumbledWordSolverModel
        {
            get
            {
                return _jumbledWordSolverModel;
            }
            set
            {
                _jumbledWordSolverModel = value;
                OnPropertyChange("JumbledWordSolverModel");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }

}