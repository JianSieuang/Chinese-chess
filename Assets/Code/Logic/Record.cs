using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Record : MonoBehaviour
{
    public GameObject A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P;
    public GameObject a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p;
    public Vector3[] chesspoint;
    public NewObject NewObject;
    public int add;
    void Start()
    {
        chesspoint = new Vector3[32];
        add = 0;
    }
    void Update()
    {
        chesspoint[0] = A.transform.position;
        chesspoint[1] = B.transform.position;
        chesspoint[2] = C.transform.position;
        chesspoint[3] = D.transform.position;
        chesspoint[4] = E.transform.position;
        chesspoint[5] = F.transform.position;
        chesspoint[6] = G.transform.position;
        chesspoint[7] = H.transform.position;
        chesspoint[8] = I.transform.position;
        chesspoint[9] = J.transform.position;
        chesspoint[10] = K.transform.position;
        chesspoint[11] = L.transform.position;
        chesspoint[12] = M.transform.position;
        chesspoint[13] = N.transform.position;
        chesspoint[14] = O.transform.position;
        chesspoint[15] = P.transform.position;

        chesspoint[16] = a.transform.position;
        chesspoint[17] = b.transform.position;
        chesspoint[18] = c.transform.position;
        chesspoint[19] = d.transform.position;
        chesspoint[20] = e.transform.position;
        chesspoint[21] = f.transform.position;
        chesspoint[22] = g.transform.position;
        chesspoint[23] = h.transform.position;
        chesspoint[24] = i.transform.position;
        chesspoint[25] = j.transform.position;
        chesspoint[26] = k.transform.position;
        chesspoint[27] = l.transform.position;
        chesspoint[28] = m.transform.position;
        chesspoint[29] = n.transform.position;
        chesspoint[30] = o.transform.position;
        chesspoint[31] = p.transform.position;

        /*if (NewObject.num == 0)
            return;
        else if (NewObject.num > 0)
        {
            for (int i = 0; i < NewObject.num; i++)
            {
                chesspoint[i + 32] = NewObject.prefabDot[i].transform.position;
            }
            add = NewObject.num;
        }*/
    }
}
//to record all the movment for determining is it block the chess moving  