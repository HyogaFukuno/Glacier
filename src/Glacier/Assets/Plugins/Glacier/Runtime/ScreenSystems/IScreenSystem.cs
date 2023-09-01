using System.Threading;
using Cysharp.Threading.Tasks;

namespace Glacier.ScreenSystems
{
    public interface IScreenSystem
    {
        UniTask Pop(CancellationToken cancellation = default);
        UniTask Pop(int count, CancellationToken cancellation = default);
        UniTask PopInstantly(int count, CancellationToken cancellation = default);
        UniTask Push(IScreenTransition transition, CancellationToken cancellation = default);
        UniTask Replace(IScreenTransition transition, CancellationToken cancellation = default);
        UniTask Replace(int count, IScreenTransition transition, CancellationToken cancellation = default);
        UniTask ReplaceAll(IScreenTransition transition, CancellationToken cancellation = default);
    }
}