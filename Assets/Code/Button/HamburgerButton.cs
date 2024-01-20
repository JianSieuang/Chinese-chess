using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamburgerButton : MonoBehaviour
{
    public void List()
    {
        transform.position += new Vector3(207, 0, 0);
    }

    public void CloseList()
    {
        transform.position -= new Vector3(207, 0, 0);
    }
}
