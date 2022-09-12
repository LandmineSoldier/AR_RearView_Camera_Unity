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
using UnityEngine.UI;

public class CamSwitcher : MonoBehaviour
{
    public RawImage mainScreen;
    public MeshRenderer[] textures;
    public Text IdText;
    int deviceID = 0;
    
    public void SwitchTexture() //use this function to unity button OnClick()
    {
        deviceID++;
        
        if (deviceID == 4)
        {
            deviceID = 0;
        }

        IdText.text = "Cam" + deviceID;
        mainScreen.texture = textures[deviceID].material.mainTexture;
    }
}
