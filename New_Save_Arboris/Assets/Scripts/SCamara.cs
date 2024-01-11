using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCamara : MonoBehaviour
{
    public Transform target;
    public float SSpeed;
    public Vector3 PCamera;
    GameObject camara;
    private void FixedUpdate()
    {
        Vector3 DPosition = target.position + PCamera;
        Vector3 SPosition = Vector3.Lerp(transform.position, DPosition, SSpeed * Time.deltaTime);
        SPosition.z = -50;
        transform.position = SPosition;
    }
}
