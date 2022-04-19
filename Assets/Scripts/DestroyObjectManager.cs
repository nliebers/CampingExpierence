using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectManager : MonoBehaviour
{
    public bool needsToDestroy = false;
    public bool letGo = true;

    public void objectPickedUp() {
        letGo = false;
    }

    public void objectLetGo() {
        letGo = true;
    }

    private void Update()
    {
        if (needsToDestroy && letGo) {
            this.gameObject.SetActive(false);
        }

    }
}
