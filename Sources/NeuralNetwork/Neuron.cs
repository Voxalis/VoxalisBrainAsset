using System;

namespace Voxalis.Brain.NeuralNetwork
{
    /// <summary>
    /// Neuron.
    /// </summary>
    public class Neuron
    {
        /// <summary>
        /// The random.
        /// </summary>
        private static readonly Random Random = new Random();

        /// <summary>
        /// The bias.
        /// </summary>
        public double Bias;

        /// <summary>
        /// The weights.
        /// </summary>
        public double[] Weights;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Voxalis.Brain.NeuralNetwork.Neuron"/> class.
        /// </summary>
        /// <param name="size">Size.</param>
        public Neuron(uint size)
        {
            Bias = Random.NextDouble() * 0.4 - 0.2;

            Weights = new double[size];

            for (var i = 0; i < size; i++)
            {
                Weights[i] = Random.NextDouble() * 0.4 - 0.2;
            }
        }

        /// <summary>
        /// Output the specified inputs.
        /// </summary>
        /// <returns>The output.</returns>
        /// <param name="inputs">Inputs.</param>
        public double Output(double[] inputs)
        {
            var sum = Bias;

            if (inputs.Length != Weights.Length)
            {
                throw new Exception($"Inputs length { Weights.Length } expected");
            }

            for (int i = 0, imax = Weights.Length; i < imax; i++)
            {
                sum += Weights[i] * inputs[i];
            }

            return sum;
        }
    }
}
