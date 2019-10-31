using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace UI.Form_ChucNang
{
    public partial class Form_QuanLyPhiTre : DevExpress.XtraEditors.XtraForm
    {
        public Form_QuanLyPhiTre()
        {
            InitializeComponent();
        }

        private void Form_QuanLyPhiTre_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form_Main.f_QuanLyPhiTre = true;
        }

        private void Form_QuanLyPhiTre_Load(object sender, EventArgs e)
        {

        }

        private void btnXacNhanKH_Click(object sender, EventArgs e)
        {

        }
    }
}