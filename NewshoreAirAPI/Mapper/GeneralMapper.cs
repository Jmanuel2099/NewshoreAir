namespace NewshoreAirAPI.Mapper
{
    /// <summary>
    /// GeneralMapper represents the mapper that will facilitate the flow
    /// of information between layers.
    /// </summary>
    /// <typeparam name="T1">Model of the layer it is communicating with </typeparam>
    /// <typeparam name="T2">Model of the same layer</typeparam>
    public abstract class GeneralMapper<T1, T2>
    {
        /// <summary>
        /// MapperT1T2 receives the model of the layer it is communicating with and converts it into
        /// a model that the current layer understands.
        /// </summary>
        /// <param name="input">Model of the communicating layer</param>
        /// <returns>Model of the current layer.</returns>
        public abstract T2 MapperT1T2(T1 input);
        /// <summary>
        /// MapperT1T2 receives a list of models from the layer it is communicating with and converts
        /// them into models of the current layer to facilitate the information flow.
        /// </summary>
        /// <param name="input">List of models of the layer it is communicating with</param>
        /// <returns>List of models of the current layer</returns>
        public abstract IEnumerable<T2> MapperT1T2(IEnumerable<T1> input);
    }
}
