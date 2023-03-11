using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VesterbroMMS.Model.Observers
{
    public class MembersReporter : IObserver<List<Member>>
    {
        private IDisposable unsubscriber;
        public string instName { get; private set; }
        public List<Member> Members { get; private set; }

        public delegate void CallBack();
        public CallBack myCallBack;

        public MembersReporter(string name, CallBack callBack)
        {
            instName = name;
            myCallBack = callBack;
        }

        public virtual void Subscribe(IObservable<List<Member>> provider)
        {
            if(provider != null)
            {
                unsubscriber = provider.Subscribe(this);
            }
        }

        public void OnCompleted()
        {
            this.UnSubscribe();
        }

        public void OnError(Exception error)
        {
            
        }

        public void OnNext(List<Member> value)
        {
            Members = value;
            myCallBack.Invoke();
        }

        public virtual void UnSubscribe()
        {
            unsubscriber.Dispose();
        }
    }
}
