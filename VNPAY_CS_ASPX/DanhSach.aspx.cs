using PJWebNC.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PJWebNC
{
    public partial class DanhSach : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int pID = Convert.ToInt32(Request.QueryString["id"]);
            if(pID == 0)
            {
                List<SanPham> lst = Dao.DaoSanPham.getAll();
                dtlDanhSachSanPham.DataSource = lst;
                DataBind();
            }
            else
            {
                List<SanPham> lstgetHsx = Dao.DaoSanPham.getAllbyHangSX(Convert.ToString(pID));
                dtlDanhSachSanPham.DataSource=lstgetHsx;
                DataBind();
            }

            //FilterGioiTinh();
            //FilterSeason();
            //FilterGia();
        }
   
        private void FilterGioiTinh()
        {
            if(cbNam.Checked == true)
            {
                
                cbNu.Checked = false;
                cbUnisex.Checked = false;
                
                
            }
            if (cbNu.Checked == true)
            {
                cbNam.Checked = false;
                cbUnisex.Checked = false;
            }
            if (cbUnisex.Checked == true)
            {
                
                cbNu.Checked = false;
                cbNam.Checked = false;
            }
        }
        private void FilterSeason()
        {
            if(cbXuan.Checked == true)
            {
                List<SanPham> lsp = Dao.DaoSanPham.getSPSeason(1);
                cbHa.Checked = false;
                cbThu.Checked = false;  
                cbDong.Checked = false;
                dtlDanhSachSanPham.DataSource = lsp;
                dtlDanhSachSanPham.DataBind();
            }
            else if (cbThu.Checked == true)
            {
                List<SanPham> lsp = Dao.DaoSanPham.getSPSeason(3);
                cbHa.Checked = false;
                cbXuan.Checked = false;
                cbDong.Checked = false;
                dtlDanhSachSanPham.DataSource = lsp;
                dtlDanhSachSanPham.DataBind();
            }
            else if (cbHa.Checked == true)
            {
                List<SanPham> lsp = Dao.DaoSanPham.getSPSeason(2);
                cbXuan.Checked = false;
                cbThu.Checked = false;
                cbDong.Checked = false;
                dtlDanhSachSanPham.DataSource = lsp;
                dtlDanhSachSanPham.DataBind();
            }
            else if (cbDong.Checked == true)
            {
                List<SanPham> lsp = Dao.DaoSanPham.getSPSeason(4);
                cbHa.Checked = false;
                cbThu.Checked = false;
                cbXuan.Checked = false;
                dtlDanhSachSanPham.DataSource = lsp;
                dtlDanhSachSanPham.DataBind();
            }
        }
        protected void FilterGia()
        {
            if(cbThap.Checked == true)
            {
                List<SanPham> lsp = Dao.DaoSanPham.getSPprice(1500000, 3000000);
                cbTrungBinh.Checked = false;
                cbCao.Checked = false;
                dtlDanhSachSanPham.DataSource = lsp;
                dtlDanhSachSanPham.DataBind();
            }
            else if (cbTrungBinh.Checked == true)
            {
                List<SanPham> lsp = Dao.DaoSanPham.getSPprice(3000000, 5000000);
                cbThap.Checked = false;
                cbCao.Checked = false;
                dtlDanhSachSanPham.DataSource = lsp;
                dtlDanhSachSanPham.DataBind();
            }
            else if (cbCao.Checked == true)
            {
                List<SanPham> lsp = Dao.DaoSanPham.getSPprice(5000000, 50000000);
                cbTrungBinh.Checked = false;
                cbThap.Checked = false;
                dtlDanhSachSanPham.DataSource = lsp;
                dtlDanhSachSanPham.DataBind();
            }
        }

        protected void bLoc_Click(object sender, EventArgs e)
        {
            string gt=" ", ss=" ", g1 = " ", g2=" ";
            
            if(cbNam.Checked == true)
            {
                gt = "and MaGioiTinh = 1";
                
            }
            else if(cbNu.Checked == true){
                gt = "and MaGioiTinh = 2";

            }
            else if(cbUnisex.Checked == true)
            {
                gt = "and MaGioiTinh = 3";

            }
            else
            {
                gt = "";
            }

            if(cbXuan.Checked == true)
            {
                ss = " and MaSeason = 1";
            }
            else if (cbHa.Checked == true)
            {
                ss = " and MaSeason = 2";
            }
            else if (cbThu.Checked == true)
            {
                ss = " and MaSeason = 3";
            }
            else if (cbDong.Checked == true)
            {
                ss = " and MaSeason = 4";
            }
            else
            {
                ss = "";
            }

            if(cbThap.Checked == true)
            {
                g1 = " and GiaBan > 1500000 ";
                g2= " and GiaBan < 3000000 ";
            }
            else if (cbTrungBinh.Checked == true)
            {
                g1 = " and GiaBan > 3000000 ";
                g2 = " and GiaBan < 5000000 ";
            }
            else if (cbCao.Checked == true)
            {
                g1 = " and GiaBan > 5000000 ";
                g2 = " and GiaBan < 500000000 ";
            }
            else
            {
                g1 = "";
                g2 = "";
            }

            List<SanPham> lsp = Dao.DaoSanPham.getAllFilter(gt, ss, g1, g2);
            dtlDanhSachSanPham.DataSource = lsp;
            dtlDanhSachSanPham.DataBind();

        }

        protected void bHuyLoc_Click(object sender, EventArgs e)
        {
            cbNam.Checked = false;
            cbNu.Checked = false;
            cbUnisex.Checked = false;
            cbXuan.Checked = false;
            cbHa.Checked = false;
            cbThu.Checked = false;
            cbDong.Checked = false;
            cbThap.Checked = false;
            cbTrungBinh.Checked = false;
            cbCao.Checked = false;
        }

        protected void cbNam_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNam.Checked)
            {
                cbNu.Checked = false;
                cbUnisex.Checked = false;
            }
        }

        protected void cbNu_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNu.Checked)
            {
                cbNam.Checked = false;
                cbUnisex.Checked = false;
            }
        }

        protected void cbUnisex_CheckedChanged(object sender, EventArgs e)
        {
            if (cbUnisex.Checked)
            {
                cbNam.Checked = false;
                cbNu.Checked = false;
            }
        }

        protected void cbXuan_CheckedChanged(object sender, EventArgs e)
        {
            if (cbXuan.Checked)
            {
                cbHa.Checked = false;
                cbThu.Checked = false;
                cbDong.Checked = false;
            }
        }

        protected void cbHa_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHa.Checked)
            {
                cbXuan.Checked = false;
                cbThu.Checked = false;
                cbDong.Checked = false;
            }
        }

        protected void cbThu_CheckedChanged(object sender, EventArgs e)
        {
            if (cbThu.Checked)
            {
                cbXuan.Checked = false;
                cbHa.Checked = false;
                cbDong.Checked = false;
            }
        }

        protected void cbDong_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDong.Checked)
            {
                cbXuan.Checked = false;
                cbHa.Checked = false;
                cbThu.Checked = false;
            }
        }
        protected void cbThap_CheckedChanged(object sender, EventArgs e)
        {
            if (cbThap.Checked)
            {
                cbTrungBinh.Checked = false;
                cbCao.Checked = false;
            }
        }

        protected void cbTrungBinh_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTrungBinh.Checked)
            {
                cbThap.Checked = false;
                cbCao.Checked = false;
            }
        }

        protected void cbCao_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCao.Checked)
            {
                cbThap.Checked = false;
                cbTrungBinh.Checked = false;
            }
        }

    }
}