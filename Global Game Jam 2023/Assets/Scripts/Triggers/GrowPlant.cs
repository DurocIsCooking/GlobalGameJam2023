using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowPlant : MonoBehaviour
{
    public GameObject PresentBackgroundNoPlant;
    public GameObject PresentBackgroundWithPlant;

    private void Awake()
    {
        PresentBackgroundNoPlant.SetActive(true);
        PresentBackgroundWithPlant.SetActive(false);
    }

    public void GrowFuturePlant()
    {
        PresentBackgroundNoPlant.SetActive(false);
        PresentBackgroundWithPlant.SetActive(true);
    }
}
