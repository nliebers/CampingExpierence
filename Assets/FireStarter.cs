using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class FireStarter : MonoBehaviour
    {

        public bool sparked = false;
        public int sparkingVelocity = 0;
        public int velocityInt = 0;


        private Vector3 prevPosition;
        private Quaternion prevRotation;
        private Vector3 prevVelocity;
        private Vector3 prevHeadPosition;

        public GameObject player;
        public GameObject fireRing;
        public GameObject leftHand;
        public GameObject rightHand;

        public GameObject tip;


        void Update()
        {
            if (Vector3.Distance(player.transform.position, transform.position) <= 5.0f)
            {
                player.transform.position = fireRing.transform.position;
                // 
            }
        }

        void FixedUpdate()
        {
            if (sparked)
            {
                prevPosition = transform.position;
                prevRotation = transform.rotation;
                transform.GetComponent<Rigidbody>().velocity *= 0.99f;
                prevVelocity = GetComponent<Rigidbody>().velocity;
                prevHeadPosition = transform.position;
            }
        }

        public void SparkFire()
        {
            Debug.Log("sparked");
            sparked = true;
            // Activate the sparking particles and have the fire start
        }

        private IEnumerator ThrowSpearAfterRelease(float wait)
        {
            Vector3 tipForward = tip.transform.forward;

            yield return new WaitForSeconds(wait);
            if (FloorToInt(transform.GetComponent<Rigidbody>().velocity, velocityInt) > sparkingVelocity)
            {
                // DO a sparking action here
            }

            if (leftHand != null || rightHand != null)
            {
                Vector3 greatestVelo = Vector3.Max(leftHand.GetComponent<HandPhysics>().handCollider.GetComponent<Rigidbody>().velocity, rightHand.GetComponent<HandPhysics>().handCollider.GetComponent<Rigidbody>().velocity);
                transform.GetComponent<Rigidbody>().velocity = tipForward * greatestVelo.magnitude * 10f;
            }
        }

        private int FloorToInt(Vector3 velocity, object v)
        {
            throw new NotImplementedException();
        }
    }
}
