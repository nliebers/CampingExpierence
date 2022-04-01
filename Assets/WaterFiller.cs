using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFiller : MonoBehaviour
{
    public GameObject water;

    void OnTriggerEnter(Collider other) {
        if (other.transform.gameObject.tag == "river") {
            water.SetActive(true);
        }
    }
}
