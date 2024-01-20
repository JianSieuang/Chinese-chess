using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public ChangeColor ChangeColor;
    public static Turn Turn;
    public NewObject NewObject;
    public MovementCheck MovementCheck;
    public Captured Captured;
    public Identity Identity;

    private Vector3 hitTarget;
    void Update()
    {
        Identity.Check();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Turn.turn == Identity.turn)
        {
            if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out RaycastHit hit, 100))
            {
                if (ChangeColor.Obj.material.color == Identity.colorType)
                {
                    if (hit.collider.gameObject.layer == Identity.layer && hit.transform.name != gameObject.name)
                    {
                        ChangeColor.ChangeColorOri();
                        NewObject.DestroyObject();
                        return;
                    }
                    else
                        hitTarget = new Vector3(Mathf.RoundToInt(hit.point.x), transform.position.y, Mathf.RoundToInt(hit.point.z));

                    for (int i = 0; i < NewObject.num; i++)
                        if (hitTarget == NewObject.prefabDot[i].transform.position)
                        {
                            ChangeColor.ChangeColorOri();
                            transform.position = hitTarget;
                            NewObject.DestroyObject();
                            Turn.turn = Identity.end;
                        }
                }
            }
        }
        Captured.Check(Identity.turn);
    }
    void LateUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Turn.turn == Identity.turn)
        {
            if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out RaycastHit hit, 100))
            {
                if (ChangeColor.Obj.material.color == ChangeColor.originalColor)
                    if (hit.transform.name == gameObject.name)
                    {
                        if (Identity.red)
                            ChangeColor.ChangeColorRed();
                        else
                            ChangeColor.ChangeColorBlack();

                        MovementCheck.Check(Identity.turn, Identity.obj);
                    }
            }
        }

        if (Captured.c == 2 && Turn.turn == Identity.turn)
        {
            gameObject.transform.position = Captured.captured[Captured.x];
            ChangeColor.ChangeColorOri();
            NewObject.DestroyObject();
        }
    }
}