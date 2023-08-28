using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonToMainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            SceneManager.LoadSceneAsync(0);
        });
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
