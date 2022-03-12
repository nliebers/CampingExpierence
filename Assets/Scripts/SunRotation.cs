using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRotation : MonoBehaviour
{

	public float rotationSpeed;
	
    void Update()
    {
        transform.eulerAngles = Vector3.right * 0.2f * 360;
    }
}
