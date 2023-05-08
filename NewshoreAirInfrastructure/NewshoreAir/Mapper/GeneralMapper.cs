﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewshoreAirInfrastructure.NewshoreAir.Mapper
{
    /// <summary>
    /// GeneralMapper represents the mapper that will facilitate the flow
    /// of information between layers.
    /// </summary>
    /// <typeparam name="T1">Model of the current layer</typeparam>
    /// <typeparam name="T2">Model of the layer it is communicating with </typeparam>
    public abstract class GeneralMapper<T1,T2>
    {
        /// <summary>
        /// MapperT1T2 receives a model from the current layer to convert it into a model that the
        /// communicating layer understands. 
        /// </summary>
        /// <param name="input">Model of the current layer.</param>
        /// <returns>Model of the communicating layer.</returns>
        public abstract T2 MapperT1T2(T1 input);
        
        public abstract IEnumerable<T2> MapperT1T2(IEnumerable<T1> input);
    }
}
