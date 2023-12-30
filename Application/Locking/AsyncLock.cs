namespace Application.Locking;

public class AsyncLock
{
    private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

    public async Task<AsyncLockReleaser> LockAsync()
    {
        await _semaphore.WaitAsync();
        return new AsyncLockReleaser(_semaphore);
    }
}

public struct AsyncLockReleaser : IDisposable
{
    private readonly SemaphoreSlim _semaphore;

    internal AsyncLockReleaser(SemaphoreSlim semaphore)
    {
        _semaphore = semaphore;
    }

    public void Dispose()
    {
        _semaphore.Release();
    }
}