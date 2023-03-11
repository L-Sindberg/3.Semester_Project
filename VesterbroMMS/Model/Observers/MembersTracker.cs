using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VesterbroMMS.Model.Observers
{
    public class MembersTracker : IObservable<List<Member>>
    {
        private List<IObserver<List<Member>>> observers;

        public MembersTracker()
        {
            observers = new List<IObserver<List<Member>>>();
        }

        public IDisposable Subscribe(IObserver<List<Member>> observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }
            return new Unsubscriber(observers, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<List<Member>>> _observers;
            private IObserver<List<Member>> _observer;

            public Unsubscriber(List<IObserver<List<Member>>> observers, IObserver<List<Member>> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if(_observer != null && _observers.Contains(_observer)){
                    _observers.Remove(_observer);
                }
            }
        }

        public void TrackMembers(List<Member> members)
        {
            foreach(var observer in observers)
            {
                observer.OnNext(members);
            }
        }

        public void EndTransmission()
        {
            foreach(var observer in observers)
            {
                if (observers.Contains(observer))
                {
                    observer.OnCompleted();
                }
            }
            observers.Clear();
        }
    }
}
