using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class SkyboxChange : MonoBehaviour
{
   
    public Material[] skybox;
    Material skyboxMaterial;


    /// <summary>
    /// As the game is loaded, a random skybox material is pulled from the set list and then loaded into each scene.(Not menu or Credits)
    /// </summary>
    void Start()
    {
        skyboxMaterial = skybox[UnityEngine.Random.Range(0, skybox.Length)];
        RenderSettings.skybox = skyboxMaterial;
       
    }


    /// <summary>
    /// Currently not being used.
    /// Switches the skybox based on current time
    /// </summary>
    //public void TimeChange()
    //{
    //    TimeZoneInfo cst = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
    //    DateTime today = DateTime.Now;
    //    DateTime currentTime = TimeZoneInfo.ConvertTime(today, cst);
    //    Debug.Log(currentTime);

        
    //}
   
}


