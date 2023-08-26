using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
    [SerializeField] private List<MiniGameWindow> _windows = new List<MiniGameWindow>(); // окна которые будут участвовать в миниигре
    [SerializeField] private List<Material> _materialsForWindow = new List<Material>(); // материалы накладываемые на окна
    //[SerializeField] private Dictionary<> _activeWindows = new List<GameObject>(); // порядок окон 
    private void Awake()
    {
        _windows = GameObject.FindObjectsByType<MiniGameWindow>(FindObjectsSortMode.None).ToList();
    }
    private void Start()
    {
        RandomParametrsForWindow();
    }
    private void RandomParametrsForWindow()
    {
        int i = 0;
        _windows.ForEach((w) =>
        {
            Material randomMaterial = RandomMaterial(0, _materialsForWindow.Count, _materialsForWindow);
            List<Material> materials = new List<Material>() { randomMaterial };
            w.SetParametrs(i, materials);
        });

        static Material RandomMaterial(int startIndex, int endIndex, List<Material> allMaterials)
        {
            int randomIndex = Random.Range(startIndex, endIndex);
            return allMaterials[randomIndex];
        }
    }

     
}
