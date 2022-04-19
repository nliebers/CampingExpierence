using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
        public GameObject Fire;
        public GameObject buildFireCollider;
        public GameObject leftHand;
        public GameObject rightHand;
		private GameObject TaskManager;
		public TextMeshProUGUI fireJournalEntry; 

        public GameObject tip;

		void Start() {
			TaskManager = GameObject.Find("TaskManager");
		}

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.gameObject.tag == "FireStick" && buildFireCollider.GetComponent<FireBuilder>().fireBuilt) {
                sparkingChance = UnityEngine.Random.Range(1, 100);
                if (sparkingChance == 2) {
                    SparkFire();
                }
            }
        }

        public void SparkFire()
        {
            Debug.Log("sparked");
            if (Vector3.Distance(buildFireCollider.transform.position, player.transform.position) <= fireProximity) {
                Fire.SetActive(true);
                transform.Find("spark").gameObject.SetActive(true);
                fireJournalEntry.text = "<s>-  Start a Fire</s>";
				TaskManager.GetComponent<TaskManager>().fire = true;
            }
            sparked = true;
            
        }

        private int FloorToInt(Vector3 velocity, object v)
        {
            throw new NotImplementedException();
        }
    }
}
