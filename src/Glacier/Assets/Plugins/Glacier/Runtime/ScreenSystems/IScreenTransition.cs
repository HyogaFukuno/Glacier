using System.Threading;
using Cysharp.Threading.Tasks;

namespace Glacier.ScreenSystems
{
    public interface IScreenTransition
    {
        UniTask<ScreenBase> LoadScreen(CancellationToken cancellation);
    }
}