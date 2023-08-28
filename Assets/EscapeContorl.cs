using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EscapeContorl : MonoBehaviour
{
    [SerializeField] private GameObject[] _objectTohide; //которые надо спрятатьь
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _objectTohide != null)
        {
            _objectTohide.ToList().ForEach(obj => { obj.SetActive(false); });
        }
    }
}
