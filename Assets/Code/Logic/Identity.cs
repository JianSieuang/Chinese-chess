using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Identity : MonoBehaviour
{
    public int turn, end, layer, obj;
    public bool red;
    public Color colorType;
    public void Check()
    {
        if(gameObject.name == "General" || 
            gameObject.name == "GuardL" || 
            gameObject.name == "GuardR" || 
            gameObject.name == "ElephantL" || 
            gameObject.name == "ElephantR" || 
            gameObject.name == "HorseL" || 
            gameObject.name == "HorseR" || 
            gameObject.name == "ChariotL" || 
            gameObject.name == "ChariotR" || 
            gameObject.name == "CannonL" || 
            gameObject.name == "CannonR" || 
            gameObject.name == "Soldiers1" || 
            gameObject.name == "Soldiers2" || 
            gameObject.name == "Soldiers3" || 
            gameObject.name == "Soldiers4" || 
            gameObject.name == "Soldiers5")
        {
            turn = 1;
            red = true;
            colorType = Color.red;
            layer = 6;
            end = 2;
        }
        else if (gameObject.name == "general" ||
            gameObject.name == "guardL" ||
            gameObject.name == "guardR" ||
            gameObject.name == "elephantL" ||
            gameObject.name == "elephantR" ||
            gameObject.name == "horseL" ||
            gameObject.name == "horseR" ||
            gameObject.name == "chariotL" ||
            gameObject.name == "chariotR" ||
            gameObject.name == "cannonL" ||
            gameObject.name == "cannonR" ||
            gameObject.name == "soldiers1" ||
            gameObject.name == "soldiers2" ||
            gameObject.name == "soldiers3" ||
            gameObject.name == "soldiers4" ||
            gameObject.name == "soldiers5")
        {
            turn = 2;
            red = false;
            colorType = Color.black;
            layer = 7;
            end = 1;
        }

        if (gameObject.name == "General" || gameObject.name == "general")
            obj = 1;
        else if (gameObject.name == "GuardL" || gameObject.name == "GuardR" || gameObject.name == "guardL" || gameObject.name == "guardR")
            obj = 2;
        else if (gameObject.name == "ElephantL" || gameObject.name == "ElephantR" || gameObject.name == "elephantL" || gameObject.name == "elephantR")
            obj = 3;
        else if (gameObject.name == "HorseL" || gameObject.name == "HorseR" || gameObject.name == "horseL" || gameObject.name == "horseR")
            obj = 4;
        else if (gameObject.name == "ChariotL" || gameObject.name == "ChariotR" || gameObject.name == "chariotL" || gameObject.name == "chariotR")
            obj = 5;
        else if (gameObject.name == "CannonL" || gameObject.name == "CannonR" || gameObject.name == "cannonL" || gameObject.name == "cannonR")
            obj = 6;
        else if (gameObject.name == "Soldiers1" || gameObject.name == "Soldiers2" || gameObject.name == "Soldiers3" || gameObject.name == "Soldiers4" || gameObject.name == "Soldiers5" ||
                 gameObject.name == "soldiers1" || gameObject.name == "soldiers2" || gameObject.name == "soldiers3" || gameObject.name == "soldiers4" || gameObject.name == "soldiers5")
            obj = 7;
    }
}
