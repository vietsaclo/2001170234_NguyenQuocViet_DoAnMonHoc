using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;


namespace CodeUITestProject
{
    /// <summary>
    /// Summary description for TestTimSanPham
    /// </summary>
    [CodedUITest]
    public class TestTimSanPham
    {
        #region Variable Declarations
        WinComboBox uICboxTimKiemComboBox;
        WinEdit uITbTimKiemEdit;
        WinEdit uITbTimKiemEdit1;
        WinButton uITìmKiếmButton;
        #endregion

        #region Variable Declarations
        WinClient uIUCSanPhamClient;
        #endregion

        #region Variable Declarations
        WinClient uIPnAnhSanPhamClient;
        #endregion

        #region Variable Declarations
        WinClient uIPnSanPhamsClient;
        #endregion

        WinRadioButton uITrên5TriệuRadioButton;
        WinRadioButton uIDưới5TriệuTrên2TriệuRadioButton;
        WinRadioButton uIDưới2TriệuRadioButton;
        WinCheckBox uIGiáTiềnCheckBox;
            

        public TestTimSanPham()
        {
            uICboxTimKiemComboBox = this.UIMap.UIFrmQuanLyWindow.UIMdiClientTabList.UIFrmBanHangWindow.UIFrmBanHangWindow1.UICboxTimKiemWindow.UICboxTimKiemComboBox;
            uITbTimKiemEdit = this.UIMap.UIFrmQuanLyWindow.UIMdiClientTabList.UIFrmBanHangWindow.UIFrmBanHangWindow1.UITbTimKiemWindow.UITbTimKiemEdit;
            uITbTimKiemEdit1 = this.UIMap.UIFrmQuanLyWindow.UIMdiClientTabList.UIFrmBanHangWindow.UIFrmBanHangWindow1.UITbTimKiemWindow.UITbTimKiemEdit1;
            uITìmKiếmButton = this.UIMap.UIFrmQuanLyWindow.UIMdiClientTabList.UIFrmBanHangWindow.UIFrmBanHangWindow1.UITìmKiếmWindow.UITìmKiếmButton;

            uIUCSanPhamClient = this.UIMap.UIFrmQuanLyWindow.UIMdiClientTabList.UIFrmBanHangWindow.UIFrmBanHangWindow1.UIUCSanPhamWindow.UIUCSanPhamClient;

            uIPnAnhSanPhamClient = this.UIMap.UIFrmQuanLyWindow.UIMdiClientTabList.UIFrmBanHangWindow.UIFrmBanHangWindow1.UIPnAnhSanPhamWindow.UIPnAnhSanPhamClient;

            uIPnSanPhamsClient = this.UIMap.UIFrmQuanLyWindow.UIMdiClientTabList.UIFrmBanHangWindow.UIFrmBanHangWindow1.UIPnSanPhamsWindow.UIPnSanPhamsClient;

            uITrên5TriệuRadioButton = this.UIMap.UIFrmQuanLyWindow.UIMdiClientTabList.UIFrmBanHangWindow.UIFrmBanHangWindow1.UITrên5TriệuWindow.UITrên5TriệuRadioButton;
            uIDưới5TriệuTrên2TriệuRadioButton = this.UIMap.UIFrmQuanLyWindow.UIMdiClientTabList.UIFrmBanHangWindow.UIFrmBanHangWindow1.UIDưới5TriệuTrên2TriệuWindow.UIDưới5TriệuTrên2TriệuRadioButton;
            uIDưới2TriệuRadioButton = this.UIMap.UIFrmQuanLyWindow.UIMdiClientTabList.UIFrmBanHangWindow.UIFrmBanHangWindow1.UIDưới2TriệuWindow.UIDưới2TriệuRadioButton;
            uIGiáTiềnCheckBox = this.UIMap.UIFrmQuanLyWindow.UIMdiClientTabList.UIFrmBanHangWindow.UIFrmBanHangWindow1.UIGiáTiềnWindow.UIGiáTiềnCheckBox;
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\dataTestTimTheoMaSanPham.xml", "testData", Microsoft.VisualStudio.TestTools.UnitTesting.DataAccessMethod.Sequential)]
        public void TestTimSanPhamTheoMa()
        {
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.

            string maSP = TestContext.DataRow["ma"].ToString(),
                maHienThi = TestContext.DataRow["maHienThi"].ToString();
            int slTim = int.Parse(TestContext.DataRow["slTim"].ToString());

            myCustomRecoder(maSP);
            myCustomAssert(slTim, maHienThi);
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\dataTestTimTheoTenSanPham.xml", "testData", Microsoft.VisualStudio.TestTools.UnitTesting.DataAccessMethod.Sequential)]
        public void testTimTheoTen()
        {
            string key = TestContext.DataRow["key"].ToString();
            int slTim = int.Parse(TestContext.DataRow["slTim"].ToString());
            int rdoIndex = int.Parse(TestContext.DataRow["rdoIndex"].ToString());
            int checkBox = int.Parse(TestContext.DataRow["checkBox"].ToString());

            myCustomRecoder_TimTheoTen(key, rdoIndex, checkBox);
            myCustomAssert_TimTheoTen(slTim);
        }

        #region---------------- Test tim theo ma------------------
        private void myCustomRecoder(string maSP)
        {
            UIMap.RecordedMethod_TestTimSanPhamParams.UITbTimKiemEdit1Text = maSP;
            this.UIMap.RecordedMethod_TestTimSanPham();
        }

        private void myCustomAssert(int kqTim, string maSP)
        {
            UITestControl tim = UIMap.findControl(uIPnAnhSanPhamClient, maSP);

            Assert.AreEqual(kqTim, uIPnSanPhamsClient.GetChildren().Count);
            Assert.IsNotNull(tim);
        }
        #endregion

        #region -------------Test tim theo ten------------------
        private void myCustomRecoder_TimTheoTen(string key, int rdoIndex, int checkBox)
        {
            
            if (rdoIndex == 0)
                Mouse.Click(uIDưới2TriệuRadioButton);
            else if (rdoIndex == 1)
                Mouse.Click(uIDưới5TriệuTrên2TriệuRadioButton);
            else
                Mouse.Click(uITrên5TriệuRadioButton);

            if (uIGiáTiềnCheckBox.Checked && checkBox == 0)
                Mouse.Click(uIGiáTiềnCheckBox);
            else if (!uIGiáTiềnCheckBox.Checked && checkBox == 1)
                    Mouse.Click(uIGiáTiềnCheckBox);

            uICboxTimKiemComboBox.SelectedIndex = 1;
            uITbTimKiemEdit1.Text = key;

            Mouse.Click(uITìmKiếmButton);
        }
        private void myCustomAssert_TimTheoTen(int slTim)
        {
            Assert.AreEqual(slTim, uIPnSanPhamsClient.GetChildren().Count);
        }
        #endregion

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

        public UIMap UIMap
        {
            get
            {
                if ((this.map == null))
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }
}
