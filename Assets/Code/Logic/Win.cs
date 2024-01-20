using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    private Vector3 R;
    private Vector3 B;

    private float midwidth;
    private float midheight;
    private float sizewidth;
    private float sizeheight;

    private void Start()
    {
        R = new Vector3(6, 0, 0);
        B = new Vector3(-6, 0, 0);
    }
    private void Update()
    {
        sizewidth = Screen.width / 3;
        sizeheight = Screen.height / 3;
        midwidth = Screen.width / 2 - sizewidth / 2;
        midheight = Screen.height / 2 - sizeheight / 2;
    }
    private void OnGUI()
    {
        if (gameObject.transform.position.x == R.x)//red win
        {
            if (GUI.Button(new Rect(midwidth, midheight, sizewidth, sizeheight), "Red Win\n Restart"))
            {
                SceneManager.LoadScene("ChessScreen");
            }
        }
        else if (gameObject.transform.position.x == B.x)//black win
        {
            if (GUI.Button(new Rect(midwidth, midheight, sizewidth, sizeheight), "Black Win\n Restart"))
            {
                SceneManager.LoadScene("ChessScreen");
            }
        }
    }
}
