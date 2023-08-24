using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadArea : MonoBehaviour
{
    [SerializeField] private Transform startPos;

    private void OnTriggerEnter(Collider other)
    {
        Player.Instance.SetMove = false;

        Blackout.Inst.Pass(true, _event: () =>
        {
            Player.Instance.SetMove = true;
            other.transform.position = startPos.position;
            Blackout.Inst.Pass(false);

        });

    }
}
