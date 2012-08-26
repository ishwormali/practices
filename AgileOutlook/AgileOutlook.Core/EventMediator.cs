using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgileOutlook.Core
{
    public class EventMediator
    {
        public static void Broadcast<T, TO>(AOEventType eventType, T eventObject) where T : AOEventData<TO>
        {

        }

        public static void Subscribe<T,TO>( AOEventType eventType,T eventObject)  where T : AOEventData<TO>
        {

        }
    }
}
