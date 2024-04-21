#if GLACIER_MAGICONION

using System;
using MagicOnion;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace Glacier.MagicOnion
{
    #nullable enable
    
    public interface IStreamingHubAPI : IDisposable
    {
    }

    public sealed class StreamingHubAdapter<T> : IDisposable
        where T : IStreamingHubAPI, new()
    {
        private readonly GrpcChannelx channel;
        private readonly IStreamingHubAPI api;
        
        public StreamingHubAdapter(string url)
        {
            Debug.Log($"{GetType().Name}.ctor");

            channel = GrpcChannelx.ForAddress(url);
            api = new T();
        }

        void IDisposable.Dispose()
        {
            Debug.Log($"{GetType().Name}.Dispose");
            
            api.Dispose();
            channel?.Dispose();
        }
    }
}

#endif
