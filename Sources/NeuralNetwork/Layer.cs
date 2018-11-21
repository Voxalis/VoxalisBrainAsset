namespace Voxalis.Brain.NeuralNetwork
{
    /// <summary>
    /// Layer.
    /// </summary>
    public class Layer
    {
        /// <summary>
        /// The neurons.
        /// </summary>
        public Neuron[] Neurons;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Voxalis.Brain.NeuralNetwork.Layer"/> class.
        /// </summary>
        /// <param name="numberOfNeurons">Number of neurons.</param>
        /// <param name="sizeOfNeurons">Size of neurons.</param>
        public Layer(uint numberOfNeurons, uint sizeOfNeurons)
        {
            Neurons = new Neuron[numberOfNeurons];

            for (var i = 0; i < numberOfNeurons; i++)
            {
                Neurons[i] = new Neuron(sizeOfNeurons);
            }
        }

        /// <summary>
        /// Output the specified inputs.
        /// </summary>
        /// <returns>The output.</returns>
        /// <param name="inputs">Inputs.</param>
        public double[] Output(double[] inputs)
        {
            var results = new double[Neurons.Length];

            for (int i = 0, imax = Neurons.Length; i < imax; i++)
            {
                results[i] = Neurons[i].Output(inputs);
            }

            return results;
        }
    }
}
