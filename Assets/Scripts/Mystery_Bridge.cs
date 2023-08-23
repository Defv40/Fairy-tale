
using TMPro;
using UnityEngine;

public class Mystery_Bridge : MonoBehaviour
{
    public static Mystery_Bridge Inst { get; set; }
    public Transform startPos;
    public TMP_Text m_text;

    private void Awake()
    {
        Inst = this;
    }

    public void ToStart()
    {
        
    }
}
