using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heron
{
    /// <summary>
    /// Heron method to calculate the 
    /// square and nth root of a given number
    /// </summary>

    public class Heron
    {
        public static void CalcSquareRoot(double number, int nSteps)
        {
            double x0 = 0;
            double xn = 0;
            double xi = 0;

            x0 = (number + 1) / 2; 

            for (int n = 0; n <= nSteps; n++)
            {
                if (n == 0)
                {
                    xi = x0;
                    xn = x0;
                }
                else
                {
                    xi = (xn + (number / xn)) / 2;
                    xn = xi;
                }

                Console.WriteLine("X{0} = {1}", n, xi);
            }
        }

        public static void CalcRoot(double number, int kRoot, int nSteps)
        {
            // (k-1)xn^k + a / kx^k-1

            double x0 = 0;
            double xn = 0;
            double xi = 0;
            double relErr = 0;

            x0 = (number + kRoot - 1) / (kRoot);

            for (int n = 0; n <= nSteps; n++)
            {
                if (n == 0)
                {
                    xi = x0;
                    xn = x0;
                }
                else
                {
                    xi = (((kRoot - 1) * Math.Pow(xn, kRoot)) + number) / (kRoot * Math.Pow(xn, (kRoot - 1)));

                    relErr = Math.Abs(((xn / xi) - 1) * 100);

                    if (xn == xi)
                        return;

                    xn = xi;                 
                }
                                
                Console.WriteLine("X{0} = {1} > {2}", n, xi, relErr);
            }
        }
    }
    }
}
