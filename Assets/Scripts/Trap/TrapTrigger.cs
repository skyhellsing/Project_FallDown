using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    public event Action Trigger;

    private void OnTriggerEnter(Collider other)
    {
        Trigger?.Invoke();
    }

    public void ClearTrigger()
    {
        Trigger = null;
    }
}
