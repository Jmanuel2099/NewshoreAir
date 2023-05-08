using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewshoreAirInfrastructure.SQLServer.Mapper
{
    /// <summary>
    /// GeneralMapper represents the mapper that will facilitate the flow
    /// of information between layers.
    /// </summary>
    /// <typeparam name="T1"> Model of the current layer</typeparam>
    /// <typeparam name="T2">Model of the layer it is communicating with</typeparam>
    public abstract class GeneralMapper<T1, T2>
    {
        /// <summary>
        /// MapperT2T1 receives the model of the layer it is communicating with and converts it into
        /// a model that the current layer understands.
        /// </summary>
        /// <param name="input">Model of the communicating layer</param>
        /// <returns>Model of the current layer.</returns>
        public abstract T1 MapperT2T1(T2 input);
        /// <summary>
        /// MapperT1T2 receives a model from the current layer to convert it into a model that the
        /// communicating layer understands. 
        /// </summary>
        /// <param name="input">Model of the current layer.</param>
        /// <returns>Model of the communicating layer.</returns>
        public abstract T2 MapperT1T2(T1 input);
        /// <summary>
        /// MapperT2T1 receives a list of models from the layer it is communicating with and converts
        /// them into models of the current layer to facilitate the information flow.
        /// </summary>
        /// <param name="input">List of models of the layer it is communicating with</param>
        /// <returns>List of models of the current layer</returns>
        public abstract IEnumerable<T1> MapperT2T1(IEnumerable<T2> input);
        /// <summary>
        /// MapperT1T2 receives a list of models of the current layer to convert them all to models of the
        /// layer it is communicating with 
        /// </summary>
        /// <param name="input">List of models of the current layer</param>
        /// <returns>List of models of the layer it is communicating with </returns>
        public abstract IEnumerable<T2> MapperT1T2(IEnumerable<T1> input);
    }
}
