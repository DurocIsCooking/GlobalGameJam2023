using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // Get mouse position in world
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            Debug.Log(mousePos);

            Vector3 raycastPos = new Vector3(mousePos.x, mousePos.y, 0);

            RaycastHit2D hit = Physics2D.Raycast(raycastPos, Vector3.forward);
            if(hit)
            {
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.GetComponent<IClickable>() != null)
                {
                    hitObject.GetComponent<IClickable>().OnClick();
                }
            }
        }
    }
}