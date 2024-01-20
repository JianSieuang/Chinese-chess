using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Captured : MonoBehaviour
{
    public static Turn Turn;
    public Record Record;
    public ChangeColor ChangeColor;

    public int i, c, x;
    public Vector3[] captured;
    private int[] z;
    void Start()
    {
        captured = new Vector3[2];
        z = new int[2];
        z[0] = 9;
        z[1] = 0;
        captured[0] = new Vector3(-6, gameObject.transform.position.y, z[0]);
        captured[1] = new Vector3(6, gameObject.transform.position.y, z[1]);
    }
    public void Check(int a)
    {
        c = 0;
        for (i = 0; i < 32; i++)
        {
            if (gameObject.transform.position == Record.chesspoint[i])
            {
                c++;
            }
        }

        if (a == 1)
            x = 0;
        else if (a == 2)
            x = 1;

        i = 0;
        do
        {
            if (captured[x] == Record.chesspoint[i])
            {
                if (x == 0)
                {
                    z[0]--;
                    captured[0] = new Vector3(-6, gameObject.transform.position.y, z[0]);
                }
                else if (x == 1)
                {
                    z[1]++;
                    captured[1] = new Vector3(6, gameObject.transform.position.y, z[1]);
                }

                i = 0;
            }
            else
                i++;

        } while (i < 32);
    }
}
