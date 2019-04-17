using System.Collections;
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
                    break;
                case Inventory.ResourceItem.STONE:
                    Inventory.stone++;
                    break;
                case Inventory.ResourceItem.STRAW:
                    Inventory.straw++;
                    break;
            }
            SoundManager.playCollectSound();
            Destroy(gameObject);
        }
    }

}
