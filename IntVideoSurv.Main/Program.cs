using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CameraViewer.Forms;


namespace CameraViewer
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            Boolean createdNew; //返回是否赋予了使用线程的互斥体初始所属权
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.UserSkins.OfficeSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(Properties.Settings.Default.DefaultSkinName);

            System.Threading.Mutex instance = new System.Threading.Mutex(true, "ArresterSerialPort", out createdNew); //同步基元变量
            if (createdNew)
            {
                var conn = DevExpress.Xpo.DB.OracleConnectionProvider.GetConnectionString("ora_remote", "longchang", "111");
                DevExpress.Xpo.Session.DefaultSession.ConnectionString = conn;

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
                instance.ReleaseMutex();
            }

        }
    }
}
