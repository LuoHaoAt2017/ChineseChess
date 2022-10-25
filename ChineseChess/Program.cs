using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChineseChess
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new ChessGame());
        }
    }
}