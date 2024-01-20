using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Renderer Obj;
    public Color originalColor;
    public void Start()
    {
        Obj = GetComponent<Renderer> ();
        originalColor = Obj.material.color;
    }
    public void ChangeColorRed()
    {
        Obj.material.color = Color.red;
    }
    public void ChangeColorBlack()
    {
        Obj.material.color = Color.black;
    }
    public void ChangeColorOri()
    {
        Obj.material.color = originalColor ;
    }
}
