using System;
using UnityEngine;
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

      /*  void Update()
        {
            if (grabPinch.GetState(leftHand) || grabPinch.GetState(rightHand))
            {
                openHands = false;
            }
            else
            {
                openHands = true;
            }
        } */

        private void OnTriggerEnter(Collider other)
        {
            if ((other.transform.gameObject.tag == "stick" && !(completed)) /* && openHands */ )
            {
                // Attempt at solving the grab bug by forcing the item to drop from the player hand, deactivating it, then destroying it. Still a no go
                // other.GetComponent<Interactable>().attachedToHand.DetachObject(this.gameObject, false);
                other.transform.gameObject.SetActive(false);
                // Destroy(other);


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
