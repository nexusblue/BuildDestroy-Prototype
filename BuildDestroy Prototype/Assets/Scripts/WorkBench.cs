using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkBench : MonoBehaviour{

    public GameObject menuMessage;
    public GameObject inventScreen;
    public static bool GameIsPaused = false;
    
    // Start is called before the first frame update
    void Start(){
        menuMessage.SetActive(false);
    }

    // Update is called once per frame
    void Update(){

    }
    private void OnTriggerStay(Collider other){
        if (other.gameObject.tag == "Player"){
            TurnOnWorkBench();
        }
    }

    private void OnTriggerExit(Collider other){
        if (other.gameObject.tag == "Player"){
            menuMessage.SetActive(false);
        }

    }

    // turn on/off workbench menu when f key is pressed
    private void TurnOnWorkBench(){
        menuMessage.SetActive(true);
        if (Input.GetKeyDown(KeyCode.F) && inventScreen.activeSelf == false ){
            inventScreen.SetActive(true);
            //Time.timeScale = 0f;
        }

        else if (Input.GetKeyDown(KeyCode.F) && inventScreen.activeSelf == true){
            inventScreen.SetActive(false);
            //Time.timeScale = 1f;
        }

    }


}
