using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxChange : MonoBehaviour
{
   
    public Material[] skybox;
    Material skyboxMaterial;

    void Start()
    {
        skyboxMaterial = skybox[Random.Range(0, skybox.Length)];
        RenderSettings.skybox = skyboxMaterial;
    }

    //public playGame() 
    //{
    //    TimeZoneInfo cst = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
    //    System.DateTime today = System.DateTime.Now;
    //    DateTime currentTime = TimeZoneInfo.ConvertTime(today, cst);



    //}
}


