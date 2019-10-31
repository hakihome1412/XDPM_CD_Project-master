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
using BLL;
using Entities;
namespace UI.Form_ChucNang
{
    public partial class Form_QuanLyDatDia : DevExpress.XtraEditors.XtraForm
    {
        public Form_QuanLyDatDia()
        {
            InitializeComponent();
        }

        private void Form_QuanLyDatDia_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form_Main.f_QuanLyDatDia = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void Form_QuanLyDatDia_Load(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }
    }
}