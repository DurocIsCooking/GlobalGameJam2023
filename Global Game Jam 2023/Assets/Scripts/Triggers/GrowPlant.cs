using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowPlant : MonoBehaviour
{
    public GameObject FuturePlant;
    public GameObject FutureCarpetSigils;

    public void GrowFuturePlant()
    {
        FuturePlant.SetActive(true);
        FutureCarpetSigils.SetActive(true);
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
