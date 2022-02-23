using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Utils
{
    public static class Utils
    {
        public static Vector3 Change(this Vector3 org, object x = null, object y = null, object z = null)
        {
            return new Vector3(x == null ? org.x : (float)x, y == null ? org.y : (float)y, z == null ? org.z : (float)z);
        }

        public static Vector2 Change(this Vector2 org, object x = null, object y = null)
        {
            return new Vector2(x == null ? org.x : (float)x, y == null ? org.y : (float)y);
        }

        public static void AddListener(this EventTrigger trigger, EventTriggerType eventType, System.Action<PointerEventData> listener)
        {
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = eventType;
            entry.callback.AddListener(data => listener.Invoke((PointerEventData)data));
            trigger.triggers.Add(entry);
        }
        
        public static void AddListener(this Button button, UnityAction action)
        {
            button.onClick.AddListener(action);
        }

        public static void RemoveAllListeners(this Button button)
        {
            button.onClick.RemoveAllListeners();
        }
    }
}