using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class RaftController : MonoBehaviour
{

	private UnityEngine.AI.NavMeshAgent agent;
	public GameObject player;
	public GameObject mountPoint;
	public GameObject sailDirection;
	public SteamVR_Action_Vector2 touchpad;
	public GameObject sail;

	void OnEnable () {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
    }

    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= 5.0f ){
			if (touchpad.GetActive(SteamVR_Input_Sources.LeftHand)) {
				//sail.transform.rotation = new Quaternion(0, -90 - (Mathf.Atan2(touchpad.GetAxis(SteamVR_Input_Sources.LeftHand).x, touchpad.GetAxis(SteamVR_Input_Sources.LeftHand).y) * Mathf.Rad2Deg * Mathf.Sign(touchpad.GetAxis(SteamVR_Input_Sources.LeftHand).x)), 0, 0);
				sail.transform.eulerAngles = new Vector3(
					sail.transform.eulerAngles.x,
					sail.transform.eulerAngles.y + touchpad.GetAxis(SteamVR_Input_Sources.LeftHand).x,
					sail.transform.eulerAngles.z
				);
			}
			//sail.transform.Rotate(0, 15, 0, Space.World);
			player.transform.position = mountPoint.transform.position;
			Vector3 newPos = sailDirection.transform.forward * 1.0f;
            agent.SetDestination(transform.position + newPos);
		}
    }
	
	private void FaceTarget(Vector3 destination)
	{
		Vector3 lookPos = agent.destination - transform.position;
		lookPos.y = 0;
		Quaternion rotation = Quaternion.LookRotation(lookPos);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.1f);  
	}
}
