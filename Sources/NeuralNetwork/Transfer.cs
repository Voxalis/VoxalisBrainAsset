using UnityEngine;

namespace Voxalis.Brain.NeuralNetwork
{
    /// <summary>
    /// Transfer.
    /// </summary>
    public partial class Transfer
    {
        /// <summary>
        /// Logistic the specified value.
        /// </summary>
        /// <returns>The logistic.</returns>
        /// <param name="value">Value.</param>
        public static double Logistic(double value)
        => 1 / (1 + Mathf.Exp(-(float)value));

        /// <summary>
        /// Hards the limit.
        /// </summary>
        /// <returns>The limit.</returns>
        /// <param name="value">Value.</param>
        public static int HardLimit(double value)
        => value > 0 ? 1 : 0;

        /// <summary>
        /// Boolean the specified value.
        /// </summary>
        /// <returns>The boolean.</returns>
        /// <param name="value">Value.</param>
        public static bool Boolean(double value)
        => value > 0;

        /// <summary>
        /// Identity the specified value.
        /// </summary>
        /// <returns>The identity.</returns>
        /// <param name="value">Value.</param>
        public static double Identity(double value)
        => value;

        /// <summary>
        /// Tanh the specified value.
        /// </summary>
        /// <returns>The tanh.</returns>
        /// <param name="value">Value.</param>
        public static double Tanh(double value)
        {
            var eP = Mathf.Exp((float)value);
            var eN = 1 / eP;
            return (eP - eN) / (eP + eN);
        }
    }
}
