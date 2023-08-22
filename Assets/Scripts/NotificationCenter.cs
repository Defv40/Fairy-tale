using System.Collections.Generic;

public class NotificationCenter
{
    private static NotificationCenter _instance;
    public static NotificationCenter Intastance
    {
        get
        {
            if (_instance == null)
                _instance = new NotificationCenter();
            return _instance;
        }
      
    }

    private List<IObserver> observers = new List<IObserver>();

    public void AddObserver(IObserver observer)
    {
        if(observers.Contains(observer)) return;
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObserver(EventType type)
    {
        foreach (var observer in observers)
        {
            observer.OnNotify(type);
        }
    }
}

