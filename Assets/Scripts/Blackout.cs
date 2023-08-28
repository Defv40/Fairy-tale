using System.Collections;

using UnityEngine;
using UnityEngine.UI;

public class Blackout : MonoBehaviour
{
    public static Blackout Inst { get; set; }

    public delegate void EventAfterPass();

    private Image image;

    private void Awake()
    {
        Inst = this;
        image = GetComponent<Image>();
    }
    private void Start()
    {
       
   
    }

    public void Pass(bool toBlack, float speed = 0.35f, EventAfterPass _event = null)
    {
        if (toBlack) StartCoroutine(ToBlack(_event, speed));
        else StartCoroutine(ToTransperent(_event, speed));
    }

    private void _Event(EventAfterPass _event)
    {
        _event.Invoke();
    }

    private IEnumerator ToBlack(EventAfterPass _event, float speed)
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
        while (image.color.a < 1)
        {
            Debug.Log(image.color.a);
            yield return new WaitForEndOfFrame();
            var a = image.color.a + speed * Time.deltaTime;
            image.color = new Color(image.color.r, image.color.g, image.color.b, a);
        }
        if(_event != null) _Event(_event);
    }

    private IEnumerator ToTransperent(EventAfterPass _event, float speed)
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
        while (image.color.a > 0)
        {
            var a = image.color.a - speed * Time.deltaTime;
            image.color = new Color(image.color.r, image.color.g, image.color.b, a);
            yield return new WaitForEndOfFrame();
        }
        if (_event != null) _Event(_event);
    }
}
