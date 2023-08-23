
using UnityEngine;

public abstract class UIModal : MonoBehaviour, IObserver
{
    public abstract void OnNotify(EventType type);

    private void OnEnable()
    {
        NotificationCenter.Intastance.AddObserver(this);
    }

    private void OnDisable()
    {
        NotificationCenter.Intastance.RemoveObserver(this);
    }
}
