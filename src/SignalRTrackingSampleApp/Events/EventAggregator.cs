using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace SignalRTrackingSampleApp.Events
{
    public class EventAggregator : IEventAggregator
    {
        private readonly Subject<object> subject;

        public EventAggregator()
        {
            subject = new Subject<object>();
        }

        public IDisposable Subscribe<T>(Action<T> action)
        {
            return subject.OfType<T>()
                .AsObservable()
                .Subscribe(action);
        }

        public void Publish<T>(T sampleEvent)
        {
            subject.OnNext(sampleEvent);
        }

        public void Dispose()
        {
            subject.Dispose();
        }
    }
}
