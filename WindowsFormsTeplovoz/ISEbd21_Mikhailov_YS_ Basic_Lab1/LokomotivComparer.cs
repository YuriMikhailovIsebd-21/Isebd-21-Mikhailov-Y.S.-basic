using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormTeplo
{
    public class LokomotivComparer : IComparer<ITransport>
    {
        public int Compare(ITransport x, ITransport y)
        {
            if (x.GetType().Name != y.GetType().Name)
            {
                return x.GetType().FullName.CompareTo(y.GetType().FullName);
            }
            if (x.GetType() == y.GetType() && x is Teplovoz)
            {
                return ComparerTeplovoz((Teplovoz)x, (Teplovoz)y);
            }
            if (x.GetType() == y.GetType() && x is Lokomotiv)
            {
                return ComparerLokomotiv((Lokomotiv)x, (Lokomotiv)y);
            }
            return 0;
        }

        private int ComparerLokomotiv(Lokomotiv x, Lokomotiv y)
        {
            if (x.MaxSpeed != y.MaxSpeed)
            {
                return x.MaxSpeed.CompareTo(y.MaxSpeed);
            }
            if (x.Weight != y.Weight)
            {
                return x.Weight.CompareTo(y.Weight);
            }
            if (x.MainColor != y.MainColor)
            {
                return x.MainColor.Name.CompareTo(y.MainColor.Name);
            }
            return 0;
        }

        private int ComparerTeplovoz(Teplovoz x, Teplovoz y)
        {
            var res = ComparerLokomotiv(x, y);
            if (res != 0)
            {
                return res;
            }
            if (x.DopColor != y.DopColor)
            {
                return x.DopColor.Name.CompareTo(y.DopColor.Name);
            }
            if (x.Tube != y.Tube)
            {
                return x.Tube.CompareTo(y.Tube);
            }
            if (x.Wheels != y.Wheels)
            {
                return x.Wheels.CompareTo(y.Wheels);
            }
            return 0;
        }
    }
}
