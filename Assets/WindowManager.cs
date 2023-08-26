using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
public class WindowManager : MonoBehaviour, IObserver
{
    [SerializeField] private List<MiniGameWindow> _windows = new List<MiniGameWindow>(); // окна которые будут участвовать в миниигре
    [SerializeField] private List<Material> _materialsForWindow = new List<Material>(); // материалы накладываемые на окна
    //[SerializeField] private Dictionary<> _activeWindows = new List<GameObject>(); // порядок окон 
    [SerializeField][Range(0, 10)] private float _delayForFillWindowInSeconds;
    //[SerializeField] private Material _baseMaterialWindow; // белый
    private Coroutine fillCoroutine;
    private void Awake()
    {
        _windows = GameObject.FindObjectsByType<MiniGameWindow>(FindObjectsSortMode.None).ToList();
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
        
    }
    private List<MiniGameWindow> Shuffle(List<MiniGameWindow> windows)
    {
        int n = windows.Count;
        System.Random rng = new System.Random();

        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            MiniGameWindow value = windows[k];
            windows[k] = windows[n];
            windows[n] = value;
        }
        Debug.Log(windows.Count);
        return windows;
    }
   
private Material RandomMaterial(int startIndex, int endIndex, List<Material> allMaterials)
{
    int randomIndex = UnityEngine.Random.Range(startIndex, endIndex);
    return allMaterials[randomIndex];
}

    private IEnumerator DelayForFillWindow()
    {
        int currentWindowIndex = 0;

        while (currentWindowIndex < _windows.Count)
        {
            yield return new WaitForSeconds(_delayForFillWindowInSeconds);
            var window = _windows[currentWindowIndex];
            Material randomMaterial = RandomMaterial(0, _materialsForWindow.Count, _materialsForWindow);
            List<Material> materials = new List<Material>() { randomMaterial };
            window.SetParametrs(currentWindowIndex, materials);
            currentWindowIndex++;
            
        }

        fillCoroutine = null;
    }

    public void OnNotify(EventType type)
    {
        if (EventType.OnInteractLamper == type)
            RandomParametrsForWindow();
    }

    private void RandomParametrsForWindow()
    {
        if (fillCoroutine != null) return;
        _windows = Shuffle(_windows);
        UnfillWindow();
        fillCoroutine =  StartCoroutine(DelayForFillWindow());
    }

    private void UnfillWindow()
    {
        foreach (MiniGameWindow window in _windows)
        {
            window.Unfill();
        }
    }
}
