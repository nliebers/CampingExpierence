using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform.gameObject.tag);
        if (other.transform.gameObject.tag == "Fish")
        {
            Debug.Log("attachign");
            //other.transform.parent = this.gameObject.transform;
            other.transform.parent.SetParent(this.gameObject.transform);
            Debug.Log(this.gameObject.transform);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.gameObject.tag == "Fish")
        {
            Debug.Log("deattatching");
            //other.transform.parent = this.gameObject.transform;
            other.transform.parent.SetParent(null);
            Debug.Log(this.gameObject.transform);
            other.transform.parent.gameObject.GetComponent<CookingManager>().checkCooked();
        }
    }
}
