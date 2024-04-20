#if GLACIER_MAGICONION && GLACIER_YETANOTHERHTTPHANDLER

using Cysharp.Net.Http;
using Grpc.Net.Client;
using MagicOnion.Unity;
using UnityEngine;

namespace Glacier.MagicOnion
{
    public static class GrpcChannelProviderHostInitializer
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void OnRuntimeInitialize()
        {
            // Initialize gRPC channel provider when the application is loaded.
            GrpcChannelProviderHost.Initialize(new DefaultGrpcChannelProvider(() => new GrpcChannelOptions()
            {
                HttpHandler = new YetAnotherHttpHandler()
                {
                    Http2Only = true,
                },
                DisposeHttpClient = true,
            }));
        }
    }
}

#endif