using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableWaterspout : MonoBehaviour
{
    public GameObject Waterspout;
    
    public void ActivateWaterspoutCollider()
    {
        Waterspout.SetActive(true);
    }

}
