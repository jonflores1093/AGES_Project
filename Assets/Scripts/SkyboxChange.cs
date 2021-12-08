using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class SkyboxChange : MonoBehaviour
{
   
    public Material[] skybox;
    Material skyboxMaterial;

    void Start()
    {
        skyboxMaterial = skybox[UnityEngine.Random.Range(0, skybox.Length)];
        RenderSettings.skybox = skyboxMaterial;
        TimeChange();
    }

    public void TimeChange()
    {
        TimeZoneInfo cst = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
        DateTime today = DateTime.Now;
        DateTime currentTime = TimeZoneInfo.ConvertTime(today, cst);
        Debug.Log(currentTime);

        


    }
}


