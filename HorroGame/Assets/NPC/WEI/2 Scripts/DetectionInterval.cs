using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionInterval : MonoBehaviour
{
    public float dishWasherRange = 10f;
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, .3f);
        Gizmos.DrawSphere(transform.position, dishWasherRange);
    }
}
