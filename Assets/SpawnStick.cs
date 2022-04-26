using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStick : MonoBehaviour
{
    public GameObject GroundStick;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 500; i++)
        {
            float randomx = Random.Range(-150, 150);
            float randomz = Random.Range(-150, 150);
            Instantiate(GroundStick, new Vector3(randomx, 50.0f, randomz), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
