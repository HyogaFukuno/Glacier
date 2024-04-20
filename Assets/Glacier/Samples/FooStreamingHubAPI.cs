using System;
using Glacier.MagicOnion;
using UnityEngine;

namespace Glacier.Samples
{
    public class FooStreamingHubAPI : IStreamingHubAPI
    {
        public FooStreamingHubAPI()
        {
            Debug.Log($"{GetType().Name}.ctor");
        }

        void IDisposable.Dispose()
        {
            Debug.Log($"{GetType().Name}.Dispose");
        }
    }
}