using PhotoEditor;
using System;
using System.Windows.Forms;

namespace ImageConverterApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // Включаем визуальные стили для улучшенного внешнего вида интерфейса.
            Application.EnableVisualStyles();
            // Устанавливаем стандартные параметры текста для совместимости с различными версиями .NET.
            Application.SetCompatibleTextRenderingDefault(false);
            // Запускаем основную форму приложения.
            Application.Run(new Form1());
        }
    }
}
