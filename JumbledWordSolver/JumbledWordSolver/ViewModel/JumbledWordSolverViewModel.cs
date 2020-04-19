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
using System.Collections.ObjectModel;
using System.Windows;

namespace JumbledWordSolver.ViewModel
{
    class JumbledWordSolverViewModel : INotifyPropertyChanged
    {
        public JumbledWordSolverViewModel()
        {
            JumbledWordSolverModel = new JumbledWordSolverModel();
            CollectionDisplayMatchedWord = new ObservableCollection<DisplayMatchedWord>();

        }

        private ObservableCollection<DisplayMatchedWord> _displayMatchedWords;

        public ObservableCollection<DisplayMatchedWord> CollectionDisplayMatchedWord
        {
            get { return _displayMatchedWords; }
            set
            {
                _displayMatchedWords = value;
                // onPropertyChange("CollectionMeasurementValues");
            }

        }

        public List<MatchedWord> ouputListOfObjects;

        #region btnPressed

        private ICommand btnPressed;
        public ICommand BtnPressed
        {
            get
            {
                if (btnPressed == null)
                {
                    btnPressed = new RelayCommand(ExecuteBtnPressed, CanExecuteBtnPressed, false);

                }
                return btnPressed;
            }
        }

        public bool CanExecuteBtnPressedChanged
        { get; private set; }

        private bool CanExecuteBtnPressed(object arg)
        {

            if (JumbledWordSolverModel.ManualSelect == true && (JumbledWordSolverModel.ManualEntryValue != null &&
                JumbledWordSolverModel.ManualEntryValue != string.Empty))
            {
                return true;
            }
            else if (JumbledWordSolverModel.FileSelect == true)
            {
                return true;

            }
            return false;

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
                    if (JumbledWordSolverModel.ManualSelect)
                    {
                        ouputListOfObjects = JumbledWordSolverModel.ExecuteScrambledWordManualEntryScenario();
                        foreach (var ouputListOfObject in ouputListOfObjects)
                        {
                            DisplayMatchedWord OBJDisplayMatchedWord = new DisplayMatchedWord
                            {
                                displayScrambledWord = ouputListOfObject.scrambledWords,
                                displayWord = ouputListOfObject.word
                            };

                            CollectionDisplayMatchedWord.Add(OBJDisplayMatchedWord);
                        }
                    }
                    else if (JumbledWordSolverModel.FileSelect && JumbledWordSolverModel.InputFilePath != null)
                    {
                        ouputListOfObjects = JumbledWordSolverModel.ExecuteScrambledWordFileEntryScenario();
                        foreach (var ouputListOfObject in ouputListOfObjects)
                        {
                            DisplayMatchedWord OBJDisplayMatchedWord = new DisplayMatchedWord
                            {
                                displayScrambledWord = ouputListOfObject.scrambledWords,
                                displayWord = ouputListOfObject.word
                            };

                            CollectionDisplayMatchedWord.Add(OBJDisplayMatchedWord);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Correct your input and try again");
                    }
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region radiobtn
        private ICommand radiobtn;
        public ICommand Radiobtn
        {
            get
            {
                if (radiobtn == null)
                {
                    radiobtn = new RelayCommand(ExecuteRadioBtnPressed, CanExecuteRadioBtnPressed, false);

                }
                return radiobtn;
            }
        }

        public bool CanExecuteRadioBtnPressedChanged { get; private set; }

        private bool CanExecuteRadioBtnPressed(object arg)
        {
            return true;
        }

        private void ExecuteRadioBtnPressed(object obj)
        {
            if (obj.ToString().Equals("selectManual"))
            {
                JumbledWordSolverModel.ManualSelect = true;
                JumbledWordSolverModel.FileSelect = false;
                OnPropertyChange("JumbledWordSolverModel");
            }
            else if (obj.ToString().Equals("fileSelect"))
            {
                JumbledWordSolverModel.ManualSelect = false;
                JumbledWordSolverModel.FileSelect = true;
                OnPropertyChange("JumbledWordSolverModel");
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

    public class DisplayMatchedWord
    {
        public string displayScrambledWord { get; set; }
        public string displayWord { get; set; }
    }
}