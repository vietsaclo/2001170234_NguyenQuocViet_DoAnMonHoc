namespace CodeUITestProject
{
    using System;
    using System.Collections.Generic;
    using System.CodeDom.Compiler;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;
    using System.Drawing;
    using System.Windows.Input;
    using System.Text.RegularExpressions;
    
    
    public partial class UIMap
    {
        public UITestControl findControl(UITestControl uiContainer, string name)
        {
            foreach (UITestControl ui in uiContainer.GetChildren())
                if (ui.Name != null && ui.Name.ToLower().Equals(name.ToLower()))
                    return ui;
            return null;
        }
    }
}