using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public Image[] inventory;

    public GameObject pickaxe;
    public GameObject ghost;
    private int selectedInventory = 0;
    private bool placeMode;

    public Image Straw;
    public Image Stone;
    public Image Wood;

    bool usingStraw = false;
    bool usingWood = false;
    bool usingStone = false;

    public bool pickaxeInMotion;
    public GameObject pickAxe;
    Animator anim;

    public Inventory.ResourceItem resourceType;

    // Start is called before the first frame update
    void Start()
    {
        anim = pickAxe.GetComponent<Animator>();
        inventory[0].GetComponent<Outline>().enabled = true;
        for (int i = 1; i < inventory.Length; i++){
            inventory[i].GetComponent<Outline>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        SelectItem();
        PlaceItem();
        bool pickaxeName = anim.GetBool("PickaxeThrow");
        if (!pickaxeName)
        {
            if (Input.mouseScrollDelta.y > 0)
            {
                inventory[selectedInventory].GetComponent<Outline>().enabled = false;
                selectedInventory++;
                if (selectedInventory > (inventory.Length - 1))
                {
                    selectedInventory = 0;
                }
                inventory[selectedInventory].GetComponent<Outline>().enabled = true;

                if (selectedInventory == 0)
                {
                    pickaxe.SetActive(true);
                }
                else
                {
                    pickaxe.SetActive(false);
                }

                if (selectedInventory == 1)
                {
                    ghost.SetActive(true);
                    placeMode = true;
                }
                else
                {
                    placeMode = false;
                    ghost.SetActive(false);
                }

            }
            else if (Input.mouseScrollDelta.y < 0)
            {
                inventory[selectedInventory].GetComponent<Outline>().enabled = false;
                selectedInventory--;
                if (selectedInventory < 0)
                {
                    selectedInventory = inventory.Length - 1;
                }
                inventory[selectedInventory].GetComponent<Outline>().enabled = true;
                if (selectedInventory == 0)
                {
                    pickaxe.SetActive(true);
                }
                else
                {
                    pickaxe.SetActive(false);
                }
                if (selectedInventory == 1)
                {
                    placeMode = true;
                    ghost.SetActive(true);
                }
                else
                {
                    placeMode = false;
                    ghost.SetActive(false);
                }
            }
        }

    }

    private void PlaceItem()
    {
        if (placeMode)
        {
            //create ray cast where mouse is
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //if ray hits something 
            if (Physics.Raycast(ray, out hit))
            {
                ghost.SetActive(true);
                ghost.transform.position = hit.point;
                if (Input.GetMouseButtonDown(0) && usingStraw && Inventory.straw >= 1){
                    Instantiate(Resources.Load("BuildStraw"), ghost.transform.position, ghost.transform.rotation);
                    Inventory.straw--;
                }
                if (Input.GetMouseButtonDown(0) && usingWood && Inventory.wood >= 1){
                    Instantiate(Resources.Load("BuildWood"), ghost.transform.position, ghost.transform.rotation);
                    Inventory.wood--;
                }
                if (Input.GetMouseButtonDown(0) && usingStone && Inventory.stone >= 1){
                    Instantiate(Resources.Load("BuildStone"), ghost.transform.position, ghost.transform.rotation);
                    Inventory.stone--;

                }
            }
            else
            {
                ghost.SetActive(false);
            }
        }
    }

    private void SelectItem()
    {
        // code for which item was selected
        if (usingStraw == false && Input.GetKeyDown(KeyCode.Z))
        {
            usingStraw = true;
            usingWood = false;
            usingStone = false;
            Straw.GetComponent<Outline>().enabled = true;
            Wood.GetComponent<Outline>().enabled = false;
            Stone.GetComponent<Outline>().enabled = false;
        }
        if (usingWood == false && Input.GetKeyDown(KeyCode.X))
        {
            usingStraw = false;
            usingWood = true;
            usingStone = false;
            Straw.GetComponent<Outline>().enabled = false;
            Wood.GetComponent<Outline>().enabled = true;
            Stone.GetComponent<Outline>().enabled = false;
        }
        if (usingStone == false && Input.GetKeyDown(KeyCode.C))
        {
            usingStraw = false;
            usingWood = false;
            usingStone = true;
            Straw.GetComponent<Outline>().enabled = false;
            Wood.GetComponent<Outline>().enabled = false;
            Stone.GetComponent<Outline>().enabled = true;

        }
    }
}
