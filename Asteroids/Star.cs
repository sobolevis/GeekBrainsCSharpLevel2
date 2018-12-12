using System.Drawing;

namespace Asteroids
{
    class Star : BaseObject
    {
        protected static readonly Image ReferenceImage;

        static Star()
        {
            ReferenceImage = System.Drawing.Image.FromFile("Star.png");
        }

        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Image = new Bitmap(ReferenceImage, size);
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Image, Pos);
        }

        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
        }

    }
}
