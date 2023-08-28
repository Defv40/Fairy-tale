using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public  class MiniGameWindow : MonoBehaviour
{
    [SerializeField] private int _indexWindow; // для порядка в котором должен светить луч
    private MeshRenderer _windowMesh;
    [SerializeField] private List<Material> _windowMaterials;
    [SerializeField]private Material _windowBaseMaterial;
    private Material _currentMaterial;
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

    public void Unfill()
    {
        _windowMesh.SetMaterials(new List<Material>() { _windowBaseMaterial});
    }

    public bool Compare(int index, Material material)
    {
        return index == _indexWindow && _windowMaterials[0].Equals(material);
    }

    public void SetMaterial(List<Material> materials)
    {
        _windowMaterials = materials;
        _windowMesh.SetMaterials(_windowMaterials);
    }
}