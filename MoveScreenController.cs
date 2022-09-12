/*
    Author: Aiden Lee
    Email: aiden.lee@rectrix.io
    Company: IpserLab / Rectrix
    Website: www.ipserlab.com / www.rectrix.io 
    Copyright (C) 2022  IpserLab

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScreenController : MonoBehaviour
{
    public GameObject moveZobj;
    public GameObject buttonPackage;
    public float moveSpeed = 10;
    public bool buttonDown = false;
    private int direction = -1;

    //float limitAngle = 15;
    int toggleZ = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 r = transform.localRotation.eulerAngles;
        Vector3 s = moveZobj.transform.localScale;
        if (buttonDown)
        {
            switch (direction)
            {
                case 0: //up
                    transform.localRotation = Quaternion.Euler(r.x - Time.deltaTime * moveSpeed, r.y, r.z);
                    break;
                case 1: //down
                    transform.localRotation = Quaternion.Euler(r.x + Time.deltaTime * moveSpeed, r.y, r.z);
                    break;
                case 2: //left
                    transform.localRotation = Quaternion.Euler(r.x, r.y - Time.deltaTime * moveSpeed, r.z);
                    break;
                case 3: //right
                    transform.localRotation = Quaternion.Euler(r.x, r.y + Time.deltaTime * moveSpeed, r.z);
                    break;
                case 4: //change scale
                    moveZobj.transform.localScale = new Vector3(s.x + Time.deltaTime * (moveSpeed / 3) / 1000 * toggleZ, 
                                                                s.y + Time.deltaTime * (moveSpeed / 3) / 1000 * toggleZ, 
                                                                s.z);
                    break;
                case 5:
                    moveZobj.transform.localScale = new Vector3(s.x + Time.deltaTime * (moveSpeed / 3) / 1000 * 1,
                                                                s.y + Time.deltaTime * (moveSpeed / 3) / 1000 * 1,
                                                                s.z);
                    break;
                case 6:
                    moveZobj.transform.localScale = new Vector3(s.x + Time.deltaTime * (moveSpeed / 3) / 1000 * -1,
                                                                s.y + Time.deltaTime * (moveSpeed / 3) / 1000 * -1,
                                                                s.z);
                    break;
            }
        }
    }

    public void RotateScreen(int _direction) //use this function with unity button Event Trigger Component Pointer Down
    {
        direction = _direction;
        buttonDown = true;
    }

    public void Zoom(int intOrOut) //use this function with unity button Event Trigger Component Pointer Down
    {
        buttonDown = true;
        direction = intOrOut;
    }

    public void ButtonUp() //use this function with unity button Event Trigger Component Pointer Up
    {
        buttonDown = false;
        toggleZ *= -1;
    }

    public void TogglePacakage() //use this function with unity button onClick()
    {
        buttonPackage.SetActive(!buttonPackage.activeSelf);
    }

    public void PlaceToTop() //use this function with unity button OnClick()
    {
        transform.localRotation = Quaternion.Euler(-17.5f, 0, 0);
    }

    public void ResetPosition() //use this function with unity button OnClick()
    {
        transform.localRotation = Quaternion.Euler(0, 0, 0);
    }
}
