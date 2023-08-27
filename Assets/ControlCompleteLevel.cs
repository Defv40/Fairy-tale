
using UnityEngine;

public class ControlCompleteLevel : MonoBehaviour, IObserver
{
    [SerializeField] private LevelManager levelManager;

    private void OnEnable()
    {
        NotificationCenter.Intastance.AddObserver(this);
    }

    private void OnDisable()
    {
        NotificationCenter.Intastance.RemoveObserver(this);
    }

    public void OnNotify(EventType type)
    {
        if (EventType.OnCompleteLevel == type)
        {
            Player.Instance.SetMove = false;
            // надо сначала затемнить экран
            Blackout.Inst.Pass(true, 1,  _event: () =>
            {
                levelManager.GoToTheNextLevel();
            });
          
        }   
    }
}
