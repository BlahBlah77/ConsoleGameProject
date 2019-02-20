using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Event_Manager_Luke : MonoBehaviour {

    Dictionary<string, UnityEvent> eventDic;

    private static Event_Manager_Luke eventManager;

    public static Event_Manager_Luke Instance
    {
        get
        {
            return eventManager;
        }
    }

    private void Awake()
    {
        if (eventManager)
        {
            DestroyImmediate(gameObject);
            return;
        }
        eventManager = this;

        if (eventDic == null)
        {
            eventDic = new Dictionary<string, UnityEvent>();
        }
    }

    public static void StartListen(string eventName, UnityAction listener)
    {
        UnityEvent newEvent = null;
        if (Instance.eventDic.TryGetValue(eventName, out newEvent))
        {
            newEvent.AddListener(listener);
        }
        else
        {
            newEvent = new UnityEvent();
            newEvent.AddListener(listener);
            Instance.eventDic.Add(eventName, newEvent);
        }
    }

    public static void StopListen(string eventName, UnityAction listener)
    {
        if (eventManager == null) return;
        UnityEvent newEvent = null;
        if (Instance.eventDic.TryGetValue(eventName, out newEvent))
        {
            newEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEvent(string eventName)
    {
        UnityEvent newEvent = null;
        if (Instance.eventDic.TryGetValue(eventName, out newEvent))
        {
            newEvent.Invoke();
        }
    }
}
