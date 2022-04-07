using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class FireBuilder : MonoBehaviour
    {
        /* private Vector3 prevPosition;
        private Quaternion prevRotation;
        private Vector3 prevVelocity;
        private Vector3 prevHeadPosition; */

        [SerializeField] int stickCount = 0;

        public static bool completed = false;
        public int fireBuildProximity = 3;
        public GameObject[] campFireSticks;
     
        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.gameObject.tag == "stick" && stickCount <= 8)
            {
                other.transform.gameObject.SetActive(false);
                campFireSticks[stickCount].SetActive(true);
                stickCount++;
                if (stickCount == 8)
                {
                    completed = true;
                }
            }
        }

        private int FloorToInt(Vector3 velocity, object v)
        {
            throw new NotImplementedException();
        }
    }
}
