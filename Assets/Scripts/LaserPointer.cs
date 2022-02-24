using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LaserPointer : MonoBehaviour
{
    public LayerMask whatIsClickable;

    private LineRenderer lr;
    private float maxDistance = 100f;
    private Vector3 clickPoint;
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Physics.Raycast(transform.position, transform.forward * 20f);
        
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, whatIsClickable))
        {
            clickPoint = hit.point;
            lr.positionCount = 2;
        }
        lr.SetPosition(0, transform.forward);
        lr.SetPosition(1, transform.forward * 20f);
    }
}
