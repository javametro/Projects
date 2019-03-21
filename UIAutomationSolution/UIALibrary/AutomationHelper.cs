using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace UIALibrary
{
    public class AutomationHelper
    {
        private static AutomationHelper _instance;
        #region Instance
        public static AutomationHelper Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new AutomationHelper();
                }

                return _instance;
            }
        }
        #endregion

        #region get root element
        public AutomationElement RootElement()
        {
            return AutomationElement.RootElement;
        }
        #endregion
    }
}
