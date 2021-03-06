using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Automation;
using System.Windows.Forms;
using TestUIAutomation.Model;
using UIALibrary;

namespace TestUIAutomation.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        /// 
        public static ObservableCollection<string> lst = new ObservableCollection<string>();

        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            ///
            
            

            AutomationHelper automationHelper = AutomationHelper.Instance;
            AutomationElement root = automationHelper.RootElement();
            AutomationElementCollection automationElementCollection = root.FindAll(TreeScope.Children, Condition.TrueCondition);
            foreach(AutomationElement elem in automationElementCollection)
            {
                lst.Add(elem.Current.Name);
            }

            App = new AppInfo() { AppNames = lst };
        }

        private AppInfo app;
        public AppInfo App
        {
            get
            {
                return app;
            }

            set
            {
                app = value;
                RaisePropertyChanged(() => App);
            }
        }

        private RelayCommand refreshAppCommand;
        public RelayCommand RefreshAppCommand
        {
            get
            {
                if(refreshAppCommand == null)
                {
                    refreshAppCommand = new RelayCommand(() => RefreshApp(), CanExecute);
                }

                return refreshAppCommand;
            }
        }

        private RelayCommand getControlInfo;
        public RelayCommand GetControlInfo
        {
            get
            {
                if(getControlInfo == null)
                {
                    getControlInfo = new RelayCommand(() => GetControls(), CanExecute);
                }

                return getControlInfo;
            }
           
        }

        private void GetControls()
        {
            
        }

        private bool CanExecute()
        {
            return true;
        }

        private void RefreshApp()
        {
            lst.Clear();
            AutomationHelper automationHelper = AutomationHelper.Instance;
            AutomationElement root = automationHelper.RootElement();
            AutomationElementCollection automationElementCollection = root.FindAll(TreeScope.Children, Condition.TrueCondition);
            foreach (AutomationElement elem in automationElementCollection)
            {
                lst.Add(elem.Current.Name);
            }

            App.AppNames = lst;
        }
    }
}