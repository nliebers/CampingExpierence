using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
	public class Spear : MonoBehaviour
	{
		
		public bool released = false;
		
		private int travelledFrames = 0;
		
		private Vector3 prevPosition;
		private Quaternion prevRotation;
		private Vector3 prevVelocity;
		private Vector3 prevHeadPosition;
		
		public GameObject leftHand;
		public GameObject rightHand;
		
		public GameObject tip;

		void FixedUpdate()
		{
			if (released)
			{
				prevPosition = transform.position;
				prevRotation = transform.rotation;
				transform.GetComponent<Rigidbody>().velocity *= 0.99f;
				prevVelocity = GetComponent<Rigidbody>().velocity;
				prevHeadPosition = transform.position;
				travelledFrames++;
			}
		}
		
		public void SpearReleased(){
			Debug.Log("released");
			released = true;
			
			RaycastHit[] hits = Physics.SphereCastAll( transform.position, 0.01f, transform.forward, 0.80f, Physics.DefaultRaycastLayers, QueryTriggerInteraction.Ignore );

			StartCoroutine(ThrowSpearAfterRelease(0.01f));
		}

		private IEnumerator ThrowSpearAfterRelease(float wait)
		{
			Vector3 tipForward = tip.transform.forward;

			yield return new WaitForSeconds(wait);
			transform.GetComponent<Rigidbody>().velocity = tipForward * 20;

			if (leftHand != null || rightHand != null)
			{
				Vector3 greatestVelo = Vector3.Max(leftHand.GetComponent<HandPhysics>().handCollider.GetComponent<Rigidbody>().velocity, rightHand.GetComponent<HandPhysics>().handCollider.GetComponent<Rigidbody>().velocity);
				if(greatestVelo.magnitude < 5f)
				{
					transform.GetComponent<Rigidbody>().velocity = tipForward * greatestVelo.magnitude * 10f;
				}
				else
				{
					transform.GetComponent<Rigidbody>().velocity = tipForward * greatestVelo.magnitude;
				}
				
				Debug.Log("Magnitude: " + greatestVelo.magnitude.ToString());
			}

			travelledFrames = 0;
			prevPosition = transform.position;
			prevRotation = transform.rotation;
			prevHeadPosition = transform.position;
			prevVelocity = GetComponent<Rigidbody>().velocity;
		}
	}
}
