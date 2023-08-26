using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public  class MiniGameWindow : MonoBehaviour
{
    private int _indexWindow; // для порядка в котором должен светить луч
    private MeshRenderer _windowMesh;
    private List<Material> _windowMaterials;
    private Material _windowBaseMaterial;

    private void Awake()
    {
        _windowMesh = GetComponent<MeshRenderer>();
        _windowBaseMaterial = _windowMesh.material;
    }
    public void SetParametrs(int index, List<Material> materials)
    {
        _indexWindow = index;
        _windowMaterials = materials;
        _windowMesh.SetMaterials(_windowMaterials);
    }

    public bool Compare(int index, Material material)
    {
        return index == _indexWindow && material == _windowMaterials[0];
    }
}