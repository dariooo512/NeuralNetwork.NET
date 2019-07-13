﻿using JetBrains.Annotations;
using NeuralNetworkDotNet.APIs.Interfaces;
using NeuralNetworkDotNet.APIs.Models;
using NeuralNetworkDotNet.APIs.Structs;
using NeuralNetworkDotNet.Helpers;

namespace NeuralNetworkDotNet.Network.Layers.Abstract
{
    /// <summary>
    /// A base <see langword="class"/> for all network layers
    /// </summary>
    public abstract class LayerBase : ILayer
    {
        /// <inheritdoc/>
        public Shape InputShape { get; }

        /// <inheritdoc/>
        public Shape OutputShape { get; }

        /// <summary>
        /// Creates a new <see cref="LayerBase"/> instance with the specified parameters
        /// </summary>
        /// <param name="input">The input shape</param>
        /// <param name="output">The output shape</param>
        protected LayerBase(Shape input, Shape output)
        {
            Guard.IsTrue(input.N == -1, nameof(input), "The input shape can't have a defined N channel");
            Guard.IsTrue(output.N == -1, nameof(output), "The output shape can't have a defined N channel");

            InputShape = input;
            OutputShape = output;
        }

        /// <summary>
        /// Forwards the inputs through the layer and returns the resulting <see cref="Tensor"/>
        /// </summary>
        /// <param name="x">The input <see cref="Tensor"/> to process</param>
        [MustUseReturnValue, NotNull]
        public abstract Tensor Forward(in Tensor x);

        /// <inheritdoc/>
        public virtual bool Equals(ILayer other)
        {
            if (other == null) return false;
            return InputShape == other.InputShape && OutputShape == other.OutputShape;
        }

        /// <inheritdoc/>
        public abstract ILayer Clone();
    }
}
