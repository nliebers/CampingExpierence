using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftController : MonoBehaviour
{

	private UnityEngine.AI.NavMeshAgent agent;
	public GameObject player;
	public GameObject mountPoint;
	public GameObject sailDirection;

	void OnEnable () {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
    }

    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= 5.0f ){
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
