using System;
using System.Collections.Generic;

namespace Voxalis.Brain.NeuralNetwork
{
    /// <summary>
    /// Perceptron.
    /// </summary>
    public class Perceptron
    {
        /// <summary>
        /// The layers.
        /// </summary>
        public readonly Layer[] Layers;

        /// <summary>
        /// The number of values.
        /// </summary>
        private readonly uint NumberOfValues;

        /// <summary>
        /// Gets the number of layers.
        /// </summary>
        /// <value>The number of layers.</value>
        public int NumberOfLayers => Layers.Length;

        /// <summary>
        /// Gets the size of the input.
        /// </summary>
        /// <value>The size of the input.</value>
        public int InputSize
        => Layers.Length > 0 ? Layers[0].Neurons.Length : 0;

        /// <summary>
        /// Gets the size of the output.
        /// </summary>
        /// <value>The size of the output.</value>
        public int OutputSize
        => Layers.Length > 0 ? Layers[Layers.Length - 1].Neurons.Length : 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Voxalis.Brain.NeuralNetwork.Perceptron"/> class.
        /// </summary>
        /// <param name="layers">Layers.</param>
        public Perceptron(uint[] layers)
        {
            if (layers.Length < 2)
            {
                throw new Exception($"Perceptron expected 2 values or more");
            }

            Layers = new Layer[layers.Length];
            Layers[0] = new Layer(Math.Max(layers[0], 1), 1);
            NumberOfValues += Math.Max(layers[0], 1) * (1 + 1);

            for (var i = 1; i < layers.Length; i++)
            {
                var size = (uint)Layers[i - 1].Neurons.Length;
                Layers[i] = new Layer(Math.Max(layers[i], 1), size);
                NumberOfValues += Math.Max(layers[i], 1) * (size + 1);
            }
        }

        /// <summary>
        /// Output the specified inputs.
        /// </summary>
        /// <returns>The output.</returns>
        /// <param name="inputs">Inputs.</param>
        public double[] Output(double[] inputs)
        {
            var outputs = new double[Layers.Length];

            for (int i = 1, imax = Layers.Length; i < imax; i++)

            {
                outputs = inputs = Layers[i].Output(inputs);
            }

            return outputs;
        }

        /// <summary>
        /// Output the specified inputs, bestIndex and bestValue.
        /// </summary>
        /// <param name="inputs">Inputs.</param>
        /// <param name="bestIndex">Best index.</param>
        /// <param name="bestValue">Best value.</param>
        public double[] Output(double[] inputs, out int bestIndex, out double bestValue)
        {
            var results = Output(inputs);

            bestIndex = 0;
            bestValue = results[0];

            for (var i = 0; i < results.Length; i++)
            {
                if (results[i] > bestValue)
                {
                    bestIndex = i;
                    bestValue = results[i];
                }
            }

            return results;
        }

        /// <summary>
        /// Output the specified inputs and bestIndex.
        /// </summary>
        /// <returns>The output.</returns>
        /// <param name="inputs">Inputs.</param>
        /// <param name="bestIndex">Best index.</param>
        public double[] Output(double[] inputs, out int bestIndex)
        {
            return Output(inputs, out bestIndex, out double bestValue);
        }

        /// <summary>
        /// Export this instance.
        /// </summary>
        /// <returns>The export.</returns>
        public double[] Export()
        {
            var data = new List<double>();

            for (var l = 0; l < Layers.Length; l++)
            {
                var layer = Layers[l];

                for (var n = 0; n < Layers[l].Neurons.Length; n++)
                {
                    var neuron = layer.Neurons[n];

                    data.Add(neuron.Bias);

                    for (var w = 0; w < neuron.Weights.Length; w++)
                    {
                        data.Add(neuron.Weights[w]);
                    }
                }
            }

            return data.ToArray();
        }

        /// <summary>
        /// Import the specified values.
        /// </summary>
        /// <param name="values">Values.</param>
        public void Import(double[] values)
        {
            if (values.Length != NumberOfValues)
            {
                throw new Exception($"Expect an array of { NumberOfValues } values");
            }

            var count = 0;

            for (var l = 0; l < Layers.Length; l++)
            {
                var layer = Layers[l];

                for (var n = 0; n < Layers[l].Neurons.Length; n++)
                {
                    var neuron = layer.Neurons[n];

                    neuron.Bias = values[count];

                    count++;

                    for (var w = 0; w < neuron.Weights.Length; w++)
                    {
                        neuron.Weights[w] = values[count];

                        count++;
                    }
                }
            }
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:Voxalis.Brain.NeuralNetwork.Perceptron"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:Voxalis.Brain.NeuralNetwork.Perceptron"/>.</returns>
        public override string ToString()
        {
            string str = "";

            for (var l = 0; l < Layers.Length; l++)
            {
                str += " " + Layers[l].Neurons.Length.ToString();
            }

            return str;
        }

    }
}
