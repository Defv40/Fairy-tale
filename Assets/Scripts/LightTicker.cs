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

    private void Start()
    {
        tickClone = tick;
    }

    private void Update()
    {
        if (tick <= 0)
        {
            GetComponent<Light>().intensity += Random.Range(-rangeIntensivity, rangeIntensivity);

            tick = tickClone;
        }
        else tick -= Time.deltaTime;
    }
}
