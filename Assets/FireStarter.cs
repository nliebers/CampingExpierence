using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class FireStarter : MonoBehaviour
    {

        public bool sparked = false;
        public int fireProximity = 10;


        private Vector3 prevPosition;
        private Quaternion prevRotation;
        private Vector3 prevVelocity;
        private Vector3 prevHeadPosition;
        private int sparkingChance;

        public GameObject player;
        public GameObject CampFire;
        public GameObject fireRing;
        public GameObject leftHand;
        public GameObject rightHand;

        public GameObject tip;


        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.gameObject.tag == "FireStick") {
                sparkingChance = UnityEngine.Random.Range(1, 10);
                if (sparkingChance == 2) {
                    SparkFire();
                }
            }
        }

        void FixedUpdate()
        {
            if (sparked)
            {

            }
        }

        public void SparkFire()
        {
            Debug.Log("sparked");
            if (Vector3.Distance(fireRing.transform.position, player.transform.position) <= fireProximity) {
                //set some game object active
                CampFire.SetActive(true);
            }
            sparked = true;
            
        }

        private int FloorToInt(Vector3 velocity, object v)
        {
            throw new NotImplementedException();
        }
    }
}
