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
    /// Summary description for TestTangGiamSoLuongMua
    /// </summary>
    [CodedUITest]
    public class TestTangGiamSoLuongMua
    {
        #region Variable Declarations
        WinClient uIUCSanPhamClient;
        WinEdit uITxtTongTienEdit;
        WinEdit uITxtTongSoLuongEdit;
        #endregion

        public TestTangGiamSoLuongMua()
        {
            uIUCSanPhamClient = this.UIMap.UIFrmQuanLyWindow.UIMdiClientTabList.UIFrmBanHangWindow.UIFrmBanHangWindow1.UIUCSanPhamWindow.UIUCSanPhamClient;
            uITxtTongTienEdit = this.UIMap.UIFrmQuanLyWindow.UIMdiClientTabList.UIFrmBanHangWindow.UIFrmBanHangWindow1.UIItem24000000Window.UITxtTongTienEdit;
            uITxtTongSoLuongEdit = this.UIMap.UIFrmQuanLyWindow.UIMdiClientTabList.UIFrmBanHangWindow.UIFrmBanHangWindow1.UIItem1CáiWindow.UITxtTongSoLuongEdit;
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\dataTestTangGiamSoLuongMua.xml", "testData", Microsoft.VisualStudio.TestTools.UnitTesting.DataAccessMethod.Sequential)]
        public void CodedUITestMethod_TestTangGiamSoLuong()
        {
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
            int isTang = int.Parse(TestContext.DataRow["isTang"].ToString());
            if (isTang == 1)
                myCustomRecoder(true);
            else
                myCustomRecoder(false);

            string lbSoLuongMua = TestContext.DataRow["lbSLMua"].ToString();
            string tbTongTien = TestContext.DataRow["tbTongTien"].ToString();
            string tbTongSL = TestContext.DataRow["tbTongSL"].ToString();

            myCustomAssert(lbSoLuongMua, tbTongTien, tbTongSL);
        }

        private void myCustomRecoder(bool isTangSoLuong)
        {
            if (isTangSoLuong)
                UIMap.RecordedMethod_TestTangSoLuongMua();
            else
                UIMap.RecordedMethod_TestGiamSoLuongMua();
        }

        private void myCustomAssert(string lbSoLuongMua, string tbTongTien, string tbTongSL)
        {
            UITestControl lbSlMuaTim = UIMap.findControl(uIUCSanPhamClient, lbSoLuongMua);
            Assert.IsNotNull(lbSlMuaTim);

            Assert.AreEqual(tbTongTien, uITxtTongTienEdit.Text);

            Assert.AreEqual(tbTongSL, uITxtTongSoLuongEdit.Text);
        }
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
