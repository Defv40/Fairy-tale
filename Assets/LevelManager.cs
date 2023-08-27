using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour, IInteractable
{


    private void OnLevelWasLoaded(int level)
    {
        
    }
    private void Start()
    {
        Blackout.Inst.Pass(false, 0.35f, _event: () =>
        {
            Player.Instance.SetMove = true;
        });
    }
    public void GoToTheNextLevel()
    {
        int indexNextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadSceneAsync(indexNextLevel, LoadSceneMode.Single);
    }

    public void Interact()
    {
        NotificationCenter.Intastance.NotifyObserver(EventType.OnCompleteLevel);
    }
}
