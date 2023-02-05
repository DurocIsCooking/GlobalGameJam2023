using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CypherSolution : MonoBehaviour
{

    public GameObject Kettle;
    public void GrantKettleAccess()
    {
        Kettle.transform.GetChild(0).gameObject.SetActive(false);
        Kettle.transform.GetChild(1).gameObject.SetActive(true);
    }
}
