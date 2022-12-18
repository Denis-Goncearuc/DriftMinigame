using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageHandler : MonoBehaviour
{
    [SerializeField] private CarData[] cars;

    private int selectedIndex;

    public CarData CurrentCar => cars[selectedIndex];
    // Start is called before the first frame update
    void Start()
    {
        selectedIndex = PlayerPrefs.GetInt("SelectedCar", 0);
        for (int i = 0; i < cars.Length; i++)
        {
          cars[i].gameObject.SetActive(false);  
        }
        cars[selectedIndex].gameObject.SetActive(true);
    }

    public void ChangeCar(int index)
    {
        if(selectedIndex == index)
            return;
        
        cars[selectedIndex].gameObject.SetActive(false);
        selectedIndex = index;
        cars[selectedIndex].gameObject.SetActive(true);
    }


    public void SelectCar()
    {
        PlayerPrefs.SetInt("SelectedCar", selectedIndex);
    }

}
