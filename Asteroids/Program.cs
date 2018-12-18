using System.Windows.Forms;

namespace Asteroids
{
    static class Program
    {
        static void Main()
        {
            Form form = new Form();
            form.Width = 800;
            form.Height = 600;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.MaximizeBox = false;
            Game.Init(form);
            form.Show();
            Game.Draw();
            Application.Run(form);
        }
    }
}
