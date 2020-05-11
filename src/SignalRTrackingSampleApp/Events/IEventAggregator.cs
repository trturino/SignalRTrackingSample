using System;
namespace SignalRTrackingSampleApp.Events
{
    //inpired by https://mikebridge.github.io/post/csharp-domain-event-aggregator/
    public interface IEventAggregator : IDisposable
    {
        IDisposable Subscribe<T>(Action<T> action);
        void Publish<T>(T @event);
    }
}
