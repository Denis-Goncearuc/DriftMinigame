using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarData : MonoBehaviour
{
    [SerializeField] private string saveKey;
    [SerializeField] private int unlockPrice;

    [SerializeField] private Color color;
    [SerializeField] private MeshRenderer body;
   
    
   


    public void Start()
    {
        //SetWheels(wheelIndex);
        
        Color savedColor = new Color(PlayerPrefs.GetFloat(saveKey + "_color_r",1),
                                        PlayerPrefs.GetFloat(saveKey + "_color_g",1),
                                        PlayerPrefs.GetFloat(saveKey + "_color_b",1));
        
        SetColor(savedColor);
    }

    public void SetColor(Color newColor)
    {
        color = newColor;
        body.material.color = color;
        PlayerPrefs.SetFloat(saveKey + "_color_r", color.r);
        PlayerPrefs.SetFloat(saveKey + "_color_g", color.g);
        PlayerPrefs.SetFloat(saveKey + "_color_b",color.b);
    }
    
    
}
