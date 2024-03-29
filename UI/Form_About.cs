﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using DevExpress.XtraEditors;

namespace UI
{
    public partial class Form_About : DevExpress.XtraEditors.XtraForm
    {
        public Form_About()
        {
            InitializeComponent();
            //this.Text = String.Format("About {0}", AssemblyTitle);
            this.lbProductName.Text = AssemblyProduct;
            this.lbVersion.Text = String.Format("Version {0}", AssemblyVersion);
            this.lbCopyright.Text = AssemblyCopyright;
            this.lbCompanyName.Text = AssemblyCompany;
            this.tbDescription.Text = AssemblyDescription;
            timer1.Enabled = true;
            timer1.Interval = 1000;
        }

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }

        private void FormAbout_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.PerformStep();
            if (progressBar1.Value >= progressBar1.Maximum)
            {
                timer1.Stop();
                timer1.Enabled = false;
                DialogResult = DialogResult.OK;
                /*FormLogin form = new FormLogin();
                this.Hide();
                form.Show();*/


            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Enabled = false;
            progressBar1.Value = progressBar1.Maximum;
            DialogResult = DialogResult.OK;
            /*FormLogin form = new FormLogin();
            this.Close();
            form.Show();
            this.Show();*/
            
            
            //this.Show();
        }

        private void FormAbout_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*if (MessageBox.Show("Bạn có muốn thoát không ?", "Thông báo ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }*/
        }

        
    }
}
