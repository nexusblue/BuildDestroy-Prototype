using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickaxeScript : MonoBehaviour
{
    //public GameObject player;
    Animator anim ;
    public float coolDown = 1f;

    // Start is called before the first frame update
    void Start(){
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetMouseButtonDown(0)){
            Debug.Log("button pressed");
            StartCoroutine(PickaxeThrowRoutine());
        }
    }

    IEnumerator PickaxeThrowRoutine() {
        anim.SetBool("PickaxeThrow", true);
        yield return new WaitForSeconds(coolDown);
        anim.SetBool("PickaxeThrow", false);
    }

    private void OnTriggerExit(Collider other){
        if (other.tag == "BreakTree"){
            Destroy(other.gameObject);
            Instantiate(Resources.Load("Woods"), other.transform.position, other.transform.rotation);
            SoundManager.playBreakNoise();
        }
        if (other.tag == "BreakRock"){
            Destroy(other.gameObject);
            Instantiate(Resources.Load("Rocks"), other.transform.position, other.transform.rotation);
            SoundManager.playBreakNoise();
        }
        if (other.tag == "BreakStraw"){
            Destroy(other.gameObject);
            Instantiate(Resources.Load("Straws"), other.transform.position, other.transform.rotation);
            SoundManager.playBreakNoise();
        }

    }


}
