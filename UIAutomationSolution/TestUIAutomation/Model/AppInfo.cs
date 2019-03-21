using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace TestUIAutomation.Model
{
    public class AppInfo : ObservableObject
    {
        private ObservableCollection<string> appNames;
        public ObservableCollection<string> AppNames
        {
            get
            {
                return appNames;
            }

            set
            {
                appNames = value;
                RaisePropertyChanged(() => AppNames);
            }
        }

    }
}
