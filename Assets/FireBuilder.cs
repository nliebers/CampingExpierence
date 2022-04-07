using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
namespace Valve.VR.InteractionSystem
{
    public class FireBuilder : MonoBehaviour
    {
        /* private Vector3 prevPosition;
        private Quaternion prevRotation;
        private Vector3 prevVelocity;
        private Vector3 prevHeadPosition; */

        private bool openHands = false;

        [SerializeField] int stickCount = 0;
        public SteamVR_Action_Boolean grabPinch;
        public SteamVR_Input_Sources leftHand;
        public SteamVR_Input_Sources rightHand;
        public static bool completed = false;
        public int fireBuildProximity = 3;
        public GameObject[] campFireSticks;

     /*   void Update()
        {
            if ((!grabPinch.GetState(leftHand)) && (!(grabPinch.GetState(rightHand))))
            {
                openHands = true;
            } else
            {
                openHands = false;
            }
        } */

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.gameObject.tag == "stick" && !(completed) && !(grabPinch.GetState(leftHand)) && !(grabPinch.GetState(rightHand)))
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
