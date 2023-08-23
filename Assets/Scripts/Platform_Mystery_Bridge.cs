using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Platform_Mystery_Bridge : MonoBehaviour
{
    public int id;
    public bool isLocked;

    [SerializeField] private bool isAvailable;
    [SerializeField] private Material m_available;
    [SerializeField] private Material m_notAvailable;

    [SerializeField] private Transform startPos;
    [SerializeField] private TMP_Text m_text;

    private static Platform_Mystery_Bridge lastPlatform;

    private MeshRenderer m_meshRenderer;

    private void Start()
    {
        m_meshRenderer = GetComponent<MeshRenderer>();

        ChangeAvailable(isAvailable);
    }

    public void ChangeAvailable(bool isAvailable)
    {
        this.isAvailable = isAvailable;
        if (isAvailable) m_meshRenderer.material = m_available;
        else m_meshRenderer.material = m_notAvailable;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag.Equals("Player"))
        {
            m_text.text = Random.Range(0, 6).ToString();

            if (id <= int.Parse(m_text.text))
            {
                lastPlatform = this;
                if (!isLocked) ChangeAvailable(true);
            }
            else if (!isAvailable)
            {
                Player.Instance.SetMove = false;

                Blackout.Inst.Pass(true, _event: () =>
                {

                    Player.Instance.SetMove = true;

                    other.transform.position = new Vector3(startPos.position.x, other.transform.position.y, startPos.position.z);
                    Blackout.Inst.Pass(false);

                });


                //collision.transform.position = new Vector3(lastPlatform.transform.position.x, collision.transform.position.y, lastPlatform.transform.position.z);
            }
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //}
}
