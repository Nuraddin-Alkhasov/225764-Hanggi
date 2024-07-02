using System;
using System.Windows;
using System.Windows.Controls;
using VisiWin.Controls;
using VisiWin.ApplicationFramework;

namespace HMI
{
    /// <summary>
    /// Interaction logic for MainView1.xaml
    /// </summary>
    [ExportView("Protocol_Main")]
    public partial class Protocol_Main : VisiWin.Controls.View
    {
        public Protocol_Main()
        {
            InitializeComponent();
        }
    }
}
