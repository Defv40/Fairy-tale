using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LightTicker : MonoBehaviour
{
    public Light m_light;
    public float rangeIntensivity;
    public float tick;

    private float tickClone;
    private float startIntensivity;

    private void Start()
    {
        tickClone = tick;
        startIntensivity = m_light.intensity;
    }

    private void Update()
    {
        if (tick <= 0)
        {
            m_light.intensity = startIntensivity;
            GetComponent<Light>().intensity += Random.Range(-rangeIntensivity, rangeIntensivity);

            tick = tickClone;
        }
        else tick -= Time.deltaTime;
    }
}
