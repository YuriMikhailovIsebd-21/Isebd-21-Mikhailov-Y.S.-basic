using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsTeplovoz
{
    class Teplovoz : Lokomotiv
    {
        public Color DopColor { private set; get; }

        public bool Tube { private set; get; }
        /// <summary>
        /// Признак наличия "дисков"
        /// </summary>
        public bool Disk { private set; get; }

        public Teplovoz(int maxSpeed, float weight, Color mainColor, Color dopColor, bool tube, bool disk)
            : base(maxSpeed, weight, mainColor)
        {
            DopColor = dopColor;
            Tube = tube;
            Disk = disk;
        }

        public override void DrawTransport(Graphics g)
        {
            base.DrawTransport(g);
            Pen pen = new Pen(DopColor);
            if (Tube)
            {
                g.DrawLine(pen, _startPosX + 90, _startPosY - 12, _startPosX + 90, _startPosY + 0);
                g.DrawLine(pen, _startPosX + 80, _startPosY - 12, _startPosX + 80, _startPosY + 0);
                g.DrawLine(pen, _startPosX + 80, _startPosY - 12, _startPosX + 90, _startPosY - 12);
            }

            if (Disk)
            {
                g.DrawEllipse(pen, _startPosX + 6, _startPosY + 40, 15, 15);
                g.DrawEllipse(pen, _startPosX + 35, _startPosY + 40, 15, 15);
                g.DrawEllipse(pen, _startPosX + 84, _startPosY + 40, 15, 15);
                g.DrawEllipse(pen, _startPosX + 115, _startPosY + 40, 15, 15);
                g.DrawLine(pen, _startPosX + 42, _startPosY + 40, _startPosX + 42, _startPosY + 55);
                g.DrawLine(pen, _startPosX + 13, _startPosY + 40, _startPosX + 13, _startPosY + 55);
                g.DrawLine(pen, _startPosX + 92, _startPosY + 40, _startPosX + 92, _startPosY + 55);
                g.DrawLine(pen, _startPosX + 123, _startPosY + 40, _startPosX + 123, _startPosY + 55);
            }
        }


    }
}
