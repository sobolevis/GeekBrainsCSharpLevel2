using System.Drawing;

namespace Asteroids
{
    class Asteroid : BaseObject
    {
        protected static readonly Image ReferenceImage;

        static Asteroid()
        {
            ReferenceImage = System.Drawing.Image.FromFile("Asteroid.png");
        }

        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Image = new Bitmap(ReferenceImage, size);
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Image, Pos);
        }

        public override void Update() { }

    }
}
