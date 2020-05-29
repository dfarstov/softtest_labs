using System;

namespace SoftTestLab2Yamanko
{
    class Rectangle
    {
        private double[] arrayOfX = new double[4];
        private double[] arrayOfY = new double[4];
        private double firstSide;
        private double secondSide;

        public double Diagonal()
        {
            for (int i = 0; i < arrayOfX.Length; i++)
            {
                if(arrayOfX[i] < 0 || arrayOfY[i] < 0)
                {
                    throw new ArgumentOutOfRangeException("Ошибка! Введены неверные значения");
                }
            }

            firstSide = arrayOfY[0] - arrayOfY[1];
            secondSide = arrayOfX[0] - arrayOfX[3];

            var result = Math.Pow(firstSide, 2.0) + Math.Pow(secondSide, 2.0);

            return Math.Sqrt(result);
        }

        public Rectangle(double[] cordinateX , double[] cordinateY)
        {
            arrayOfX = cordinateX;
            arrayOfY = cordinateY;
        }

    }
}
