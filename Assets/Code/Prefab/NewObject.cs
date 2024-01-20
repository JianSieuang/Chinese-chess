using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewObject : MonoBehaviour
{
    public GameObject prefab;
    public GameObject[] prefabDot;
    public int num;
    public GameObject dot;

    void Start()
    {
        num = 0;
        prefabDot = new GameObject[40];
        dot = new GameObject("Dot");
    }
    public void CreateObject(float x, float y, float z)
    {
        if(dot == null)
            dot = new GameObject("Dot");

        dot.transform.parent = transform;

        prefabDot[num] = GameObject.Instantiate(prefab, new Vector3(x, y, z), Quaternion.identity, transform);
        prefabDot[num].name = "Predot";
        num++;
    }
    public void DestroyObject()
    {
        if (num == 0)
            return;
        else 
        {
            for (; num > 0; num--)
            {
                Destroy(prefabDot[num - 1]);
            }
            Destroy(dot);
        }
    }
}
