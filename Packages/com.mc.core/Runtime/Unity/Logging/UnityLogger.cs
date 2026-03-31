using MC.Core.Logging;
using UnityEngine;

namespace MC.Core.Unity.Logging
{
    public class UnityLogger : MonoBehaviour, ILogSink
    {
        public void Log(string message)
        {
            Debug.Log(message);
        }
    }
}
