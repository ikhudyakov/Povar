using JoostenProductions;
using UnityEngine;

namespace Views
{
    public class BaseView : MonoBehaviour
    {
        public virtual void Init()
        {
            UpdateManager.SubscribeToUpdate(OnUpdate);
        }

        public virtual void OnUpdate()
        {

        }

        private void OnDestroy()
        {
            UpdateManager.UnsubscribeFromUpdate(OnUpdate);
        }
    }
}