using System;
using System.Net;

namespace GradeBook
{
    public struct Statistics
    {
        public double Minimum;
        public double Maximum;
        public double Average;
        public char Letter;

        public void Initialize(double _min, double _max, double _avg)
        {
            Minimum = _min;
            Maximum = _max;
            Average = _avg;
            UpdateLetter();
        }

        public void UpdateMinMax(double _comp) {
            Minimum = Math.Min(_comp, Minimum);
            Maximum = Math.Max(_comp, Maximum);
        }

        public void SetAvg(double _avg)
        {
            Average = _avg;
            UpdateLetter();
        }

        private void UpdateLetter()
        {
            switch(Average)
            {
                case double avg when avg >= 90:
                    Letter = 'A';
                    break;
                case double avg when avg >= 80:
                    Letter = 'B';
                    break;
                case double avg when avg >= 70:
                    Letter = 'C';
                    break;
                case double avg when avg >= 60:
                    Letter = 'D';
                    break;
                default:
                    Letter = 'F';
                    break;
            }
        }
    }
}
