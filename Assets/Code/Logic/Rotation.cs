using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public static Turn Turn;

    private int rotate;
    public float speed;
    private float rotateSpeed;
    public float lastTime;
    private float time;
    void Start()
    {
        speed = 0;
        rotateSpeed = 200;
        rotate = 2;
        lastTime = 0;
        time = 180 / rotateSpeed;
    }
    void Update()
    {
        if (Turn.turn == 2)
        {
            if (lastTime <= 0 && rotate == 2)
            {
                SetTime(rotate);
            }
            else
            {
                StartRotate();
            }
        }
        else if (Turn.turn == 1)
        {
            if (lastTime <= 0 && rotate == 1)
            {
                SetTime(rotate);
            }
            else
            {
                StartRotate();
            }
        }
    }
    void SetTime (int r)
    {
        lastTime = time;
        if (r == 2)
        {
            rotate = 1;
            speed = -rotateSpeed;
            return;
        }
        else if (r == 1)
        {
            rotate = 2;
            speed = rotateSpeed;
            return;
        }
    }
    void StartRotate()
    {
        if (lastTime > 0)
        {
            lastTime -= Time.deltaTime;
            transform.Rotate(0, speed * Time.deltaTime, 0);
        }
        else if (lastTime <= 0)
        {
            speed = 0;
            if(Turn.turn == 1)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if(Turn.turn == 2)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }
}
