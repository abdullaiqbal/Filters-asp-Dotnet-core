namespace FilterTask.Service.IServices
{
    public interface IStopwatch
    {
        long ElapsedMilliseconds { get; }
        void Start();
        void Stop();
        void Reset();
    }
}
