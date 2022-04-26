using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setparticlefalse : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject particleChild;

    public void pickup()
    {
        particleChild.SetActive(false);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
