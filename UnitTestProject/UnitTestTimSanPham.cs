using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestProject.Models;
using DAL_BLL;
using DTO;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTestTimSanPham
    {
        private string FileName;

        private List<SPTimItem> datas;

        private SanPham_DAL_BLL spDAL_BLL;

        [TestInitialize]
        public void setUp()
        {
            //FileName = FunctionStatic.getPath() + "fileDataTestTimSP.txt";
            FileName = @"D:\08DHTH1\Kiem Dinh Chat Luong Phan Mem\2001170234_NguyenQuocViet_DoAnMonHoc\UnitTestProject\FileData\fileDataTestTimSP.txt";
            datas = new List<SPTimItem>();
            FunctionStatic.loadData(FileName, ref datas);
            spDAL_BLL = new SanPham_DAL_BLL();
        }

        [TestMethod]
        public void TestMethod_TimSanPham()
        {
            Assert.IsNotNull(datas, "Cô đổi lại đường dẫn file nha cô. Cái này build ra dll nên không set được đường dẫn tương đối.");

            //Bắt đầu chạy vòng lặp để tìm sản phẩm.
            SPTimItem itemTim;
            for (int i = 0; i < datas.Count; i++)
            {
                //Lấy 1 test data ra.
                itemTim = datas[i];

                //kiểm tra xem test data đó là test tìm theo mã hay là test tìm theo tên.
                if (itemTim.LaTimTheoMa)
                {
                    //Test tìm theo mã
                    testTimTheoMa(itemTim.GiaTri, itemTim.SlTim, itemTim.MaSPTims);
                }
                else
                {
                    //Test tìm theo tên
                    testTimTheoTen(itemTim.GiaTri, itemTim.RadioGiaTien, itemTim.CheckBoxGiaTien, itemTim.SlTim, itemTim.MaSPTims);
                }
            }
        }

        private void testTimTheoMa(string giaTriTim, int slTimThay_Expected, string[] maSPTimThays_Expected)
        {
            List<SanPham_DTO> spTim = spDAL_BLL.timKiemSanPham(SanPham_DAL_BLL.ETimKim.TIM_THEO_MA, giaTriTim);
            if (slTimThay_Expected == 0)//Giá trị mong muốn = 0 thì danh sách tìm phải = 0
                Assert.AreEqual(0 ,spTim.Count, string.Format("ứng với mã sản phẩm là: {0} thì phải là không tìm thấy", giaTriTim));
            else if (slTimThay_Expected == 1)//giá trị mong muốn = 1 thì danh sách phải = 1
                Assert.AreEqual(1 ,spTim.Count, string.Format("Ứng với mã sản phẩm: {0} thì phải là tìm thấy 1 sản phẩm", giaTriTim));

            //Kiểm tra xem tìm sản phẩm có đúng không.
            Assert.AreEqual(maSPTimThays_Expected[0].ToLower(), spTim[0].MaSP.ToLower(), "Tìm thấy sản phẩm nhưng tìm bị sai");
        }

        private void testTimTheoTen(string giaTriTim, int rdoDonGiaChon, bool checkBoxChon, int slTimThay_Expected, string[] maSPTimThays_Expected)
        {
            //Thực hiện việc tìm theo tên
            List<SanPham_DTO> listTim = spDAL_BLL.timKiemSanPham(SanPham_DAL_BLL.ETimKim.TIM_THEM_TEN, giaTriTim);
            //Nếu muốn lọc tiếp theo giá tiền
            if (checkBoxChon)
                spDAL_BLL.locTiep_TheoGia(ref listTim, rdoDonGiaChon);

            //So sánh số lượng tìm được với số lượng mong muốn tìm.
            Assert.AreEqual(slTimThay_Expected, listTim.Count, string.Format("Ứng với giá trị tìm: {0} này thì phải tìm thấy: {1} sản phẩm",giaTriTim, slTimThay_Expected));
            
            //So sánh danh sách sản phẩm tìm.
            foreach (string maSP in maSPTimThays_Expected)
            {
                bool laTonTai = laTonTaiMa(maSP, listTim);
                Assert.IsTrue(laTonTai, string.Format("Danh sách tìm không có chứa mã: {0} nên bị sai", maSP));
            }
        }

        private bool laTonTaiMa(string maSP, List<SanPham_DTO> sanPhams)
        {
            foreach (SanPham_DTO sp in sanPhams)
                if (sp.MaSP.ToLower().Equals(maSP.ToLower()))
                    return true;
            return false;
        }
    }
}
