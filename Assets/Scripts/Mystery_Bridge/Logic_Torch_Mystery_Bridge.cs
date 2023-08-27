using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logic_Torch_Mystery_Bridge : MonoBehaviour
{
    [SerializeField] private ParticleSystem m_particles;
    [SerializeField] private Light m_light;

    public void Switch(bool enabled)
    {
        if(enabled)
        {
            m_particles.Play();
            m_light.enabled = true;
            GetComponent<MeshRenderer>().materials[1].EnableKeyword("_EMISSION");
        }
        else
        {
            m_particles.Stop();
            m_light.enabled = false;
            GetComponent<MeshRenderer>().materials[1].DisableKeyword("_EMISSION");
        }
    }
}
