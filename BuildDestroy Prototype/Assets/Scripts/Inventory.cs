using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    // 
    public enum CraftableItem { SWORD, BOW, PICKAXE, REDPOTION,BLUEPOTION,YELLOWPOTION };
    public enum ResourceItem { WOOD, STONE, STRAW };

    public static int wood;
    public static int stone;
    public static int straw;

    public Text woodText;
    public Text stoneText;
    public Text strawText;

    private void Update(){
        woodText.text = wood.ToString();
        stoneText.text = stone.ToString();
        strawText.text = straw.ToString();
        
    }

    //taking button number from UI
    public void CraftbyInt(int craftInt){
        if(craftInt == 1) {
            Craft(CraftableItem.REDPOTION);
        }
        else if (craftInt == 2){
            Craft(CraftableItem.BLUEPOTION);
        }
        else if (craftInt == 3){
            Craft(CraftableItem.YELLOWPOTION);
        }

    }

    public bool Craft(CraftableItem craft){

        bool success = false;
        switch (craft) {
            case CraftableItem.REDPOTION:
                if (wood>=3 && stone >= 2) {
                    success = true;
                }
                break;
            case CraftableItem.BLUEPOTION:
                if (straw >= 4 && stone >= 1){
                    success = true;
                }
                break;
            case CraftableItem.YELLOWPOTION:
                if (stone >= 2 && wood >= 2 && straw >=2){
                    success = true;
                }
                break;
        }
        return success;

    }

}
