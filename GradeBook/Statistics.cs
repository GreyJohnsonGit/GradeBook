using System;

namespace GradeBook
{
    public struct Statistics
    {
        public double Minimum;
        public double Maximum;
        public double Average;

        public void Initialize(double _min, double _max, double _avg)
        {
            Minimum = _min;
            Maximum = _max;
            Average = _avg;
        }

        public void UpdateMinMax(double _comp) {
            Minimum = Math.Min(_comp, Minimum);
            Maximum = Math.Max(_comp, Maximum);
        }

        public void SetAvg(double _avg)
        {
            Average = _avg;
        }
    }
}
