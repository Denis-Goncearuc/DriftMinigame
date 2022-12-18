using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GarageUI : MonoBehaviour
{
    [SerializeField] private GarageHandler garageHandler;
    [SerializeField] private Color[] availableColors;
    





    public void PreviewColor(int index)
    {
        if(index >= availableColors.Length || index < 0)
            return;
        
        garageHandler.CurrentCar.SetColor(availableColors[index]);
    }

    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    
}
