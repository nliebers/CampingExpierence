using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBuilder : MonoBehaviour
{
    public bool fireBuilt = false;
	private int stickPortionsPutDown;
	public List<GameObject> sticksUsed = new List<GameObject>();
	
	public void addStick(GameObject stick) {
		sticksUsed.Add(stick);
		stickPortionsPutDown += 1;
		if (stickPortionsPutDown >= 6) {
			fireBuilt = true;
		}
	}
}
