using System;
using System.Windows.Forms;

namespace Asteroids
{
    static class Program
    {
        static void Main()
        {
            Form form = new Form();

            // Изменив эти значения можно спровоцировать исключение
            form.Width = 800;
            form.Height = 600;

            // Обработка исключения - неправильный размер окна
            try
            {
                Game.Init(form);
                form.Show();
                Game.Draw();
                Application.Run(form);
            }
            catch (ArgumentOutOfRangeException e)
            {
                MessageBox.Show(e.Message);
            }
            
        }
    }
}
