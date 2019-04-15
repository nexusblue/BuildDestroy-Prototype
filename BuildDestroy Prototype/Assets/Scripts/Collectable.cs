﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    //go to resource script for the enum resource
    public Inventory.ResourceItem resourceType ;

    public void Start(){

    }

    //check for player tag and if yes
    //destroy game collectable and add one to inventory 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            switch (resourceType){
                case Inventory.ResourceItem.WOOD:
                    //GameObject.FindGameObjectWithTag("Collectable").GetComponent<Inventory>().wood++;
                    Inventory.wood++;
                    Debug.Log("wood collected:" + Inventory.wood);
                    break;
                case Inventory.ResourceItem.STONE:
                    //GameObject.FindGameObjectWithTag("Collectable").GetComponent<Inventory>().stone++;
                    Inventory.stone++;
                    Debug.Log("stone collected:" + Inventory.stone);
                    break;
                case Inventory.ResourceItem.TWINE:
                    //GameObject.FindGameObjectWithTag("Collectable").GetComponent<Inventory>().twine++;
                    Inventory.twine++;
                    Debug.Log("twine collected:s" + Inventory.twine );
                    break;
            }
            SoundManager.playCollectSound();
            Destroy(gameObject);
        }
    }

}
