using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsTeplovoz
{
    class Teplovoz
    {

        private float _startPosX;

        private float _startPosY;

        private int _pictureWidth;

        private int _pictureHeight;

        private readonly int TeploWidth = 100;

        private readonly int TeploHeight = 30;

        public Color MainColor { private set; get; }
        public Color WindowColor { private set; get; }
        public bool DoorTeplo { private set; get; }
        public bool TubeTeplo { private set; get; }
        public bool Windows { private set; get; }
        public bool TeploBody { private set; get; }

        /// <param name="mainColor"></param>
        /// <param name="window"></param>
        /// <param name="windows"></param>
        /// <param name="TeploBody"></param>
        /// <param name="DoorTeplo"></param>
        /// <param name="TubeTeplo"></param>
        public void Init(Color mainColor, Color windowColor, bool windows, bool doorTeplo, bool Teplobody, bool tubeTeplo)
        {
            MainColor = mainColor;
            WindowColor = windowColor;
            TubeTeplo = tubeTeplo;
            TeploBody = Teplobody;
            DoorTeplo = doorTeplo;
            Windows = windows;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void SetPosition(int x, int y, int width, int height)
        {
            _startPosX = x;
            _startPosY = y;
            _pictureHeight = height;
            _pictureWidth = width;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="direction"></param>
        public void MoveTeplo(Direction direction)
        {

            float step = 20;
            switch (direction)
            {
                case Direction.Right:
                    if (_startPosX + step < _pictureWidth - TeploWidth)
                    {
                        _startPosX += step;
                    }
                    break;
                case Direction.Left:
                    if (_startPosX - step > 0)
                    {
                        _startPosX -= step;
                    }
                    break;
                case Direction.Up:
                    if (_startPosY - step > 0)
                    {
                        _startPosY -= step;
                    }
                    break;
                case Direction.Down:
                    if (_startPosY + step < _pictureHeight - TeploHeight)
                    {
                        _startPosY += step;
                    }
                    break;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        public void DrawTeplo(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            //TeploBody:
            {

                //body
                g.DrawRectangle(pen, _startPosX, _startPosY + 15, 150, 20);
                g.DrawLine(pen, _startPosX, _startPosY + 15, _startPosX + 8, _startPosY);
                g.DrawLine(pen, _startPosX + 8, _startPosY, _startPosX + 150, _startPosY);
                g.DrawLine(pen, _startPosX + 150, _startPosY, _startPosX + 150, _startPosY + 18);
                //dopParts
                g.FillRectangle(Brushes.Black, _startPosX + 150, _startPosY + 10, 5, 25);
                g.FillRectangle(Brushes.Black, _startPosX + 10, _startPosY + 35, 45, 15);
                g.FillRectangle(Brushes.Black, _startPosX + 90, _startPosY + 35, 45, 15);
                //door
                g.DrawRectangle(pen, _startPosX + 50, _startPosY + 5, 15, 25);
                g.FillRectangle(Brushes.White, _startPosX + 50 + 1, _startPosY + 5 + 1, 15, 25);

                //wheels
                g.DrawEllipse(pen, _startPosX + 6, _startPosY + 40, 15, 15);
                g.DrawEllipse(pen, _startPosX + 35, _startPosY + 40, 15, 15);
                g.DrawEllipse(pen, _startPosX + 84, _startPosY + 40, 15, 15);
                g.DrawEllipse(pen, _startPosX + 115, _startPosY + 40, 15, 15);

                //windows
                g.DrawRectangle(Pens.Blue, _startPosX + 13, _startPosY + 3, 10, 10);
                g.DrawRectangle(Pens.Blue, _startPosX + 33, _startPosY + 3, 10, 10);
                g.DrawRectangle(Pens.Blue, _startPosX + 130, _startPosY + 3, 10, 10); 


            }
            if (TubeTeplo)
            {
                g.DrawLine(pen, _startPosX + 90, _startPosY - 12, _startPosX + 90, _startPosY + 0);
                g.DrawLine(pen, _startPosX + 80, _startPosY - 12, _startPosX + 80, _startPosY + 0);
                g.DrawLine(pen, _startPosX + 80, _startPosY - 12, _startPosX + 90, _startPosY - 12);
            }


        }
    }
}
