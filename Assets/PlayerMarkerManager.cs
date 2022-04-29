using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMarkerManager : MonoBehaviour
{
    public GameObject Player;
	private float x_Offset = 0;
	private float z_Offset = 0;
	
    void Update()
    {
        if(Player.transform.position.x <= 0) {
			x_Offset = (Player.transform.position.x/-200) * 2.7f;
		}
		if(Player.transform.position.x >= 0) {
			x_Offset = (Player.transform.position.x/160) * -2.1f;
		}
		if(Player.transform.position.z <= 0) {
			z_Offset = (Player.transform.position.z/-200) * 3.5f;
		}
		if(Player.transform.position.z >= 0) {
			z_Offset = (Player.transform.position.z/276) * -2.81f;
		}
		transform.localPosition = new Vector3(x_Offset, transform.localPosition.y, z_Offset);
    }
}
