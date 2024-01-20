using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCheck : MonoBehaviour
{
    public Record Record;
    public NewObject NewObject;

    int army, enemy, lf, lb, ll, lr, ef, eb, river;//ef and eb is elephant's limit for front and back
    int limitLeft, limitRight, limitFront, limitBack;
    public void Check(int a, int b)
    {
        bool front = true, back = true, left = true, right = true, king = true;//king == feitianjiang, fucking stupid one
        bool NE = true, SE = true, SW = true, NW = true;//for elephant and guard
        bool frontLeft = true, frontRight = true, backLeft = true, backRight = true, leftUp = true, leftDown = true, rightUp = true, rightDown = true;//for horse
        Vector3 frontCheck, backCheck, leftCheck, rightCheck;//for chariot 
        Vector3 frontCapture, backCapture, leftCapture, rightCapture;
        int frontcancapture = 0, backcancapture = 0, leftcancapture = 0, rightcancapture = 0;

        limitFront = 9;
        limitBack = 0;
        limitLeft = -4;
        limitRight = 4;

        if (a == 1)
        {
            army = 0;
            enemy = 16;

            lf = 2;
            lb = 0;
            ll = -1;
            lr = 1;
            ef = 4;
            eb = 0;
            river = 4;
        }
        else if (a == 2)
        {
            army = 16;
            enemy = 0;
            lf = 9;
            lb = 7;
            ll = -1;
            lr = 1;
            ef = 9;
            eb = 5;
            river = 5;
        }

        if (b == 1)//this is general
        {

            for (int i = army; i < army + 16; i++)
            {
                if (transform.position.z + 1 == Record.chesspoint[i].z && transform.position.x == Record.chesspoint[i].x)
                    front = false;

                if (transform.position.z - 1 == Record.chesspoint[i].z && transform.position.x == Record.chesspoint[i].x)
                    back = false;

                if (transform.position.z == Record.chesspoint[i].z && transform.position.x - 1 == Record.chesspoint[i].x)
                    left = false;

                if (transform.position.z == Record.chesspoint[i].z && transform.position.x + 1 == Record.chesspoint[i].x)
                    right = false;
            }


            for (int j = 0; j < 32; j++)
            {
                if (transform.position.x == Record.chesspoint[enemy].x && Record.chesspoint[enemy].x == Record.chesspoint[j].x)
                {
                    if ((transform.position.z < Record.chesspoint[j].z && Record.chesspoint[j].z < Record.chesspoint[enemy].z) ||
                        (transform.position.z > Record.chesspoint[j].z && Record.chesspoint[j].z > Record.chesspoint[enemy].z))
                    {
                        king = false;
                    }
                }
            }

            if (front && transform.position.z < lf)
                NewObject.CreateObject(transform.position.x, transform.position.y, transform.position.z + 1);

            if (back && transform.position.z > lb)
                NewObject.CreateObject(transform.position.x, transform.position.y, transform.position.z - 1);

            if (left && transform.position.x > ll)
                NewObject.CreateObject(transform.position.x - 1, transform.position.y, transform.position.z);

            if (right && transform.position.x < lr)
                NewObject.CreateObject(transform.position.x + 1, transform.position.y, transform.position.z);

            if (king)
                NewObject.CreateObject(transform.position.x, transform.position.y, Record.chesspoint[enemy].z);
        }
        else if (b == 2)//this is guard
        {
            for (int i = army; i < army + 16; i++)
            {
                if (transform.position.z + 1 == Record.chesspoint[i].z && transform.position.x + 1 == Record.chesspoint[i].x)
                    NE = false;

                if (transform.position.z - 1 == Record.chesspoint[i].z && transform.position.x + 1 == Record.chesspoint[i].x)
                    SE = false;

                if (transform.position.z - 1 == Record.chesspoint[i].z && transform.position.x - 1 == Record.chesspoint[i].x)
                    SW = false;

                if (transform.position.z + 1 == Record.chesspoint[i].z && transform.position.x - 1 == Record.chesspoint[i].x)
                    NW = false;
            }

            if (NE && transform.position.x < lr && transform.position.z < lf)
                NewObject.CreateObject(transform.position.x + 1, transform.position.y, transform.position.z + 1);

            if (SE && transform.position.x < lr && transform.position.z > lb)
                NewObject.CreateObject(transform.position.x + 1, transform.position.y, transform.position.z - 1);

            if (SW && transform.position.x > ll && transform.position.z > lb)
                NewObject.CreateObject(transform.position.x - 1, transform.position.y, transform.position.z - 1);

            if (NW && transform.position.x > ll && transform.position.z < lf)
                NewObject.CreateObject(transform.position.x - 1, transform.position.y, transform.position.z + 1);
        }
        else if (b == 3)//this is elephant
        {
            for (int j = 0; j < 32; j++)
                for (int i = army; i < army + 16; i++)
                {
                    if (transform.position.z + 1 == Record.chesspoint[j].z && transform.position.x + 1 == Record.chesspoint[j].x ||
                        transform.position.z + 2 == Record.chesspoint[i].z && transform.position.x + 2 == Record.chesspoint[i].x)
                        NE = false;

                    if (transform.position.z - 1 == Record.chesspoint[j].z && transform.position.x + 1 == Record.chesspoint[j].x ||
                        transform.position.z - 2 == Record.chesspoint[i].z && transform.position.x + 2 == Record.chesspoint[i].x)
                        SE = false;

                    if (transform.position.z - 1 == Record.chesspoint[j].z && transform.position.x - 1 == Record.chesspoint[j].x ||
                        transform.position.z - 2 == Record.chesspoint[i].z && transform.position.x - 2 == Record.chesspoint[i].x)
                        SW = false;

                    if (transform.position.z + 1 == Record.chesspoint[j].z && transform.position.x - 1 == Record.chesspoint[j].x ||
                        transform.position.z + 2 == Record.chesspoint[i].z && transform.position.x - 2 == Record.chesspoint[i].x)
                        NW = false;
                }

            if (NE && transform.position.x < limitRight && transform.position.z < ef)
                NewObject.CreateObject(transform.position.x + 2, transform.position.y, transform.position.z + 2);

            if (SE && transform.position.x < limitRight && transform.position.z > eb)
                NewObject.CreateObject(transform.position.x + 2, transform.position.y, transform.position.z - 2);

            if (SW && transform.position.x > limitLeft && transform.position.z > eb)
                NewObject.CreateObject(transform.position.x - 2, transform.position.y, transform.position.z - 2);

            if (NW && transform.position.x > limitLeft && transform.position.z < ef)
                NewObject.CreateObject(transform.position.x - 2, transform.position.y, transform.position.z + 2);
        }
        else if (b == 4)//this is horse
        {
            for (int j = 0; j < 32; j++)
            {
                if (transform.position.x == Record.chesspoint[j].x && transform.position.z + 1 == Record.chesspoint[j].z)
                {
                    frontRight = false;
                    frontLeft = false;
                }

                if (transform.position.x == Record.chesspoint[j].x && transform.position.z - 1 == Record.chesspoint[j].z)
                {
                    backRight = false;
                    backLeft = false;
                }

                if (transform.position.x - 1 == Record.chesspoint[j].x && transform.position.z == Record.chesspoint[j].z)
                {
                    leftUp = false;
                    leftDown = false;
                }

                if (transform.position.x + 1 == Record.chesspoint[j].x && transform.position.z == Record.chesspoint[j].z)
                {
                    rightUp = false;
                    rightDown = false;
                }
            }

            for (int i = army; i < army + 16; i++)
            {
                if(transform.position.z + 2 == Record.chesspoint[i].z)
                {
                    if (transform.position.x - 1 == Record.chesspoint[i].x)
                    frontLeft = false;

                    if (transform.position.x + 1 == Record.chesspoint[i].x)
                    frontRight = false;
                }

                if(transform.position.z - 2 == Record.chesspoint[i].z)
                {
                    if (transform.position.x - 1 == Record.chesspoint[i].x)
                    backLeft = false;

                    if (transform.position.x + 1 == Record.chesspoint[i].x)
                    backRight = false;
                }

                if(transform.position.x - 2 == Record.chesspoint[i].x)
                {
                    if (transform.position.z + 1 == Record.chesspoint[i].z)
                    leftUp = false;

                    if (transform.position.z - 1 == Record.chesspoint[i].z)
                    leftDown = false;
                }
                if(transform.position.x + 2 == Record.chesspoint[i].x)
                {
                    if (transform.position.z + 1 == Record.chesspoint[i].z)
                    rightUp = false;

                    if (transform.position.z - 1 == Record.chesspoint[i].z)
                    rightDown = false;
                }
            }

            if (frontLeft && transform.position.z < limitFront - 1 && transform.position.x > limitLeft)
                NewObject.CreateObject(transform.position.x - 1, transform.position.y, transform.position.z + 2);

            if (frontRight && transform.position.z < limitFront - 1 && transform.position.x < limitRight)
                NewObject.CreateObject(transform.position.x + 1, transform.position.y, transform.position.z + 2);

            if (backLeft && transform.position.z > limitBack + 1 && transform.position.x > limitLeft)
                NewObject.CreateObject(transform.position.x - 1, transform.position.y, transform.position.z - 2);

            if (backRight && transform.position.z > limitBack + 1 && transform.position.x < limitRight)
                NewObject.CreateObject(transform.position.x + 1, transform.position.y, transform.position.z - 2);

            if (leftUp && transform.position.z < limitFront && transform.position.x > limitLeft + 1)
                NewObject.CreateObject(transform.position.x - 2, transform.position.y, transform.position.z + 1);

            if (leftDown && transform.position.z > limitBack && transform.position.x > limitLeft + 1)
                NewObject.CreateObject(transform.position.x - 2, transform.position.y, transform.position.z - 1);

            if (rightUp && transform.position.z < limitFront && transform.position.x < limitRight - 1)
                NewObject.CreateObject(transform.position.x + 2, transform.position.y, transform.position.z + 1);

            if (rightDown && transform.position.z > limitBack && transform.position.x < limitRight - 1)
                NewObject.CreateObject(transform.position.x + 2, transform.position.y, transform.position.z - 1);
        }
        else if (b == 5)//this is chariot
        {
            frontCheck = new Vector3(0, transform.position.y, 0);//this is default setting, position y is the height of chess, means the chess is floating on the board
            backCheck = new Vector3(0, transform.position.y, 0);
            leftCheck = new Vector3(0, transform.position.y, 0);
            rightCheck = new Vector3(0, transform.position.y, 0);

            for (int j = 0; j < 32; j++)
            {
                if (transform.position.x == Record.chesspoint[j].x)
                {
                    if (transform.position.z < Record.chesspoint[j].z)
                    {
                        if (front)//the first chess infront on it 
                        {
                            frontCheck.x = Record.chesspoint[j].x;
                            frontCheck.z = Record.chesspoint[j].z;
                            front = false;
                        }
                        else if (frontCheck.z > Record.chesspoint[j].z)//get the nearest chess compare to others
                        {
                            frontCheck.z = Record.chesspoint[j].z;
                        }
                    }

                    if (transform.position.z > Record.chesspoint[j].z)
                    {
                        if (back)
                        {
                            backCheck.x = Record.chesspoint[j].x;
                            backCheck.z = Record.chesspoint[j].z;
                            back = false;
                        }
                        else if (backCheck.z < Record.chesspoint[j].z)
                        {
                            backCheck.z = Record.chesspoint[j].z;
                        }
                    }
                }

                if (transform.position.z == Record.chesspoint[j].z)
                {
                    if (transform.position.x > Record.chesspoint[j].x && Record.chesspoint[j].x > limitLeft)//stupid way to avoid the chess to capture the captured chess
                    {
                        if (left)
                        {
                            leftCheck.x = Record.chesspoint[j].x;
                            leftCheck.z = Record.chesspoint[j].z;
                            left = false;
                        }
                        else if (leftCheck.x < Record.chesspoint[j].x)
                        {
                            leftCheck.x = Record.chesspoint[j].x;
                        }
                    }

                    if (transform.position.x < Record.chesspoint[j].x && Record.chesspoint[j].x < limitRight)
                    {
                        if (right)
                        {
                            rightCheck.x = Record.chesspoint[j].x;
                            rightCheck.z = Record.chesspoint[j].z;
                            right = false;
                        }
                        else if (rightCheck.x > Record.chesspoint[j].x)
                        {
                            rightCheck.x = Record.chesspoint[j].x;
                        }
                    }
                }
            }

            if (front && transform.position.z < limitFront)//if no chess infront on it, it will show how many ways it can moves
            {
                frontCheck.x = transform.position.x;
                frontCheck.z = 10;
            }

            if (back && transform.position.z > limitBack)
            {
                backCheck.x = transform.position.x;
                backCheck.z = -1;
            }

            if (left && transform.position.x > limitLeft)
            {
                leftCheck.x = -5;
                leftCheck.z = transform.position.z;
            }

            if (right && transform.position.x < limitRight)
            {
                rightCheck.x = 5;
                rightCheck.z = transform.position.z;
            }

            for (int i = enemy; i < enemy + 16; i++)// if the nearest chess is enemy, add one way to move which is capture 
            {
                if (frontCheck.z == Record.chesspoint[i].z && frontCheck.x == Record.chesspoint[i].x)
                    frontCheck.z++;

                if (backCheck.z == Record.chesspoint[i].z && backCheck.x == Record.chesspoint[i].x)
                    backCheck.z--;

                if (leftCheck.z == Record.chesspoint[i].z && leftCheck.x == Record.chesspoint[i].x)
                    leftCheck.x--;

                if (rightCheck.z == Record.chesspoint[i].z && rightCheck.x == Record.chesspoint[i].x)
                    rightCheck.x++;
            }

            for (int i = 1; i < 10; i++)
            {
                if (transform.position.z + i < frontCheck.z)
                    NewObject.CreateObject(transform.position.x, transform.position.y, transform.position.z + i);

                if (transform.position.z - i > backCheck.z)
                    NewObject.CreateObject(transform.position.x, transform.position.y, transform.position.z - i);

                if (transform.position.x - i > leftCheck.x)
                    NewObject.CreateObject(transform.position.x - i, transform.position.y, transform.position.z);

                if (transform.position.x + i < rightCheck.x)
                    NewObject.CreateObject(transform.position.x + i, transform.position.y, transform.position.z);
            }
        }
        else if (b == 6)//this is cannon
        {

            frontCheck = new Vector3(0, transform.position.y, 0);//this is default setting, position y is the height of chess, means the chess is floating on the board
            backCheck = new Vector3(0, transform.position.y, 0);//to store the nearest chess position
            leftCheck = new Vector3(0, transform.position.y, 0);
            rightCheck = new Vector3(0, transform.position.y, 0);

            frontCapture = new Vector3(0, transform.position.y, 0);//to store the second nearest chess positon which is can captureable
            backCapture = new Vector3(0, transform.position.y, 0);
            leftCapture = new Vector3(0, transform.position.y, 0);
            rightCapture = new Vector3(0, transform.position.y, 0);

            for (int j = 0; j < 32; j++)
            {
                if (transform.position.x == Record.chesspoint[j].x)
                {
                    if (transform.position.z < Record.chesspoint[j].z)
                    {
                        if (front)
                        {
                            frontCheck.x = Record.chesspoint[j].x;
                            frontCheck.z = Record.chesspoint[j].z;
                            front = false;
                        }
                        else if (frontCheck.z > Record.chesspoint[j].z)//find the nearest chess
                        {
                            frontCheck.z = Record.chesspoint[j].z;
                        }
                        frontcancapture++;//means there more than one chess 
                    }

                    if (transform.position.z > Record.chesspoint[j].z)
                    {
                        if (back)
                        {
                            backCheck.x = Record.chesspoint[j].x;
                            backCheck.z = Record.chesspoint[j].z;
                            back = false;
                        }
                        else if (backCheck.z < Record.chesspoint[j].z)
                        {
                            backCheck.z = Record.chesspoint[j].z;
                        }
                        backcancapture++;
                    }
                }

                if (transform.position.z == Record.chesspoint[j].z)
                {
                    if (transform.position.x > Record.chesspoint[j].x && Record.chesspoint[j].x > limitLeft)
                    {
                        if (left)
                        {
                            leftCheck.x = Record.chesspoint[j].x;
                            leftCheck.z = Record.chesspoint[j].z;
                            left = false;
                        }
                        else if (leftCheck.x < Record.chesspoint[j].x)
                        {
                            leftCheck.x = Record.chesspoint[j].x;
                        }
                        leftcancapture++;
                    }

                    if (transform.position.x < Record.chesspoint[j].x && Record.chesspoint[j].x < limitRight)
                    {
                        if (right)
                        {
                            rightCheck.x = Record.chesspoint[j].x;
                            rightCheck.z = Record.chesspoint[j].z;
                            right = false;
                        }
                        else if (rightCheck.x > Record.chesspoint[j].x)
                        {
                            rightCheck.x = Record.chesspoint[j].x;
                        }
                        rightcancapture++;
                    }
                }
            }

            if (front && transform.position.z < limitFront)//if no chess infront on it, it will show how many ways it can moves
            {
                frontCheck.x = transform.position.x;
                frontCheck.z = 10;
            }

            if (back && transform.position.z > limitBack)
            {
                backCheck.x = transform.position.x;
                backCheck.z = -1;
            }

            if (left && transform.position.x > limitLeft)
            {
                leftCheck.x = -5;
                leftCheck.z = transform.position.z;
            }

            if (right && transform.position.x < limitRight)
            {
                rightCheck.x = 5;
                rightCheck.z = transform.position.z;
            }

            for (int i = 1; i < 10; i++)
            {
                if (transform.position.z + i < frontCheck.z)
                    NewObject.CreateObject(transform.position.x, transform.position.y, transform.position.z + i);

                if (transform.position.z - i > backCheck.z)
                    NewObject.CreateObject(transform.position.x, transform.position.y, transform.position.z - i);

                if (transform.position.x - i > leftCheck.x)
                    NewObject.CreateObject(transform.position.x - i, transform.position.y, transform.position.z);

                if (transform.position.x + i < rightCheck.x)
                    NewObject.CreateObject(transform.position.x + i, transform.position.y, transform.position.z);
            }

            front = true;
            back = true;
            left = true;
            right = true;

            for (int j = 0; j < 32; j++)
            {
                if (frontCheck.x == Record.chesspoint[j].x)
                {
                    if (frontcancapture > 1 && frontCheck.z < Record.chesspoint[j].z)//find the second nearest chess
                    {
                        if (front)
                        {
                            frontCapture.x = Record.chesspoint[j].x;
                            frontCapture.z = Record.chesspoint[j].z;
                            front = false;
                        }
                        else if (frontCapture.z > Record.chesspoint[j].z)
                        {
                            frontCapture.z = Record.chesspoint[j].z;
                        }
                    }
                }

                if (backCheck.x == Record.chesspoint[j].x)
                {
                    if (backcancapture > 1 && backCheck.z > Record.chesspoint[j].z)
                    {
                        if (back)
                        {
                            backCapture.x = Record.chesspoint[j].x;
                            backCapture.z = Record.chesspoint[j].z;
                            back = false;
                        }
                        else if (backCapture.z < Record.chesspoint[j].z)
                        {
                            backCapture.z = Record.chesspoint[j].z;
                        }
                    }
                }

                if (leftCheck.z == Record.chesspoint[j].z)
                {
                    if (leftcancapture > 1 && leftCheck.x > Record.chesspoint[j].x && Record.chesspoint[j].x > limitLeft)
                    {
                        if (left)
                        {
                            leftCapture.x = Record.chesspoint[j].x;
                            leftCapture.z = Record.chesspoint[j].z;
                            left = false;
                        }
                        else if (leftCapture.x < Record.chesspoint[j].x)
                        {
                            leftCapture.x = Record.chesspoint[j].x;
                        }
                    }
                }

                if (rightCheck.z == Record.chesspoint[j].z)
                {
                    if (rightcancapture > 1 && rightCheck.x < Record.chesspoint[j].x && Record.chesspoint[j].x < limitRight)
                    {
                        if (right)
                        {
                            rightCapture.x = Record.chesspoint[j].x;
                            rightCapture.z = Record.chesspoint[j].z;
                            right = false;
                        }
                        else if (rightCapture.x > Record.chesspoint[j].x)
                        {
                            rightCapture.x = Record.chesspoint[j].x;
                        }
                    }
                }
            }

            for (int i = enemy; i < enemy + 16; i++)
            {
                if (frontCapture.x == Record.chesspoint[i].x && frontCapture.z == Record.chesspoint[i].z && frontcancapture > 1)//need to above 2 chess cus the default position is red general position, lmao
                    NewObject.CreateObject(frontCapture.x, transform.position.y, frontCapture.z);

                if (backCapture.x == Record.chesspoint[i].x && backCapture.z == Record.chesspoint[i].z && backcancapture > 1)
                    NewObject.CreateObject(backCapture.x, transform.position.y, backCapture.z);

                if (leftCapture.x == Record.chesspoint[i].x && leftCapture.z == Record.chesspoint[i].z && leftcancapture > 1)
                    NewObject.CreateObject(leftCapture.x, transform.position.y, leftCapture.z);

                if (rightCapture.x == Record.chesspoint[i].x && rightCapture.z == Record.chesspoint[i].z && rightcancapture > 1)
                    NewObject.CreateObject(rightCapture.x, transform.position.y, rightCapture.z);
            }
        }
        else if (b == 7)//this is soldier
        {
            for (int i = army; i < army + 16; i++)
            {
                if (a == 1)
                    back = false;
                else if (a == 2)
                    front = false;

                if (transform.position.x == Record.chesspoint[i].x)
                {
                    if (transform.position.z + 1 == Record.chesspoint[i].z)
                        front = false;

                    if (transform.position.z - 1 == Record.chesspoint[i].z)
                        back = false;
                }

                if (transform.position.z == Record.chesspoint[i].z)
                {
                    if (transform.position.x + 1 == Record.chesspoint[i].x)
                        right = false;

                    if (transform.position.x - 1 == Record.chesspoint[i].x)
                        left = false;
                }
            }

            if (front && transform.position.z < limitFront)
                NewObject.CreateObject(transform.position.x, transform.position.y, transform.position.z + 1);

            if (back && transform.position.z > limitBack)
                NewObject.CreateObject(transform.position.x, transform.position.y, transform.position.z - 1);

            if (a == 1)
            {
                if (left && transform.position.z > river && transform.position.x > limitLeft) //soldier chess only across the river then can move left and right
                    NewObject.CreateObject(transform.position.x - 1, transform.position.y, transform.position.z);

                if (right && transform.position.z > river && transform.position.x < limitRight)
                    NewObject.CreateObject(transform.position.x + 1, transform.position.y, transform.position.z);
            }
            else if (a == 2)
            {
                if (left && transform.position.z < river && transform.position.x > limitLeft)
                    NewObject.CreateObject(transform.position.x - 1, transform.position.y, transform.position.z);

                if (right && transform.position.z < river && transform.position.x < limitRight)
                    NewObject.CreateObject(transform.position.x + 1, transform.position.y, transform.position.z);
            }
        }
    }
}
