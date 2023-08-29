using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NotifyUserText : MonoBehaviour, IObserver
{
    [SerializeField] private float lifeTimeSeconds;
    [SerializeField] private float hiddenTime;
    [SerializeField] private string textForTip;
    [SerializeField] private TMP_Text tipText;
    private Coroutine tipCoroutine;
    private void Awake()
    {
        tipText = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        NotificationCenter.Intastance.AddObserver(this);
    }

    private void OnDisable()
    {
        NotificationCenter.Intastance.RemoveObserver(this);
    }

    private void Start()
    {
        tipCoroutine = StartCoroutine(LifeTime());

    }

    private IEnumerator LifeTime()
    {
        tipText.text = "";
        yield return new WaitForSeconds(hiddenTime);
        tipText.text = textForTip;

        yield return new WaitForSeconds(lifeTimeSeconds);
        tipText.text = "";
    }
    private IEnumerator LifeTime(string text)
    {
        
        tipText.text = "";
        tipText.text = text;
        yield return new WaitForSeconds(lifeTimeSeconds / 2);
        tipText.text = "";
    }

    public void Tip(string tipText)
    {
        if (tipCoroutine != null)
        {
            StopCoroutine(tipCoroutine);
        }

        StartCoroutine(LifeTime(tipText));
    }

    public void OnNotify(EventType type)
    {
        if (EventType.OnShowTip == type)
        {
            
        }
    }
}
