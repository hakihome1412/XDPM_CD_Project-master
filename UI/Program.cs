using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using UI.Form_ChucNang;

namespace UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            //Form_About f = new Form_About();
            //if (f.ShowDialog() == DialogResult.OK)
            //    Application.Run(new Form_Main());

            //Form_Main f = new Form_Main();
            //if (f.ShowDialog() == DialogResult.OK)
                Application.Run(new Form_Main());

        }
    }
}
