using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    // TO DO: make it possible to interact with items in inventory

    private void Update()
    {
        // Clicking can do a few different things
            // Progress dialogue
            // Interact with items
            // Close an item pop-up
        // But what it can do depends on the game state
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            
            switch (GameManager.Instance.CurrentGameState)
            {
                case GameManager.GameStates.Dialogue:
                    DialogueManager.Instance.ProgressDialogue();
                    break;
                case GameManager.GameStates.FreePlay:
                case GameManager.GameStates.UsingItem:
                    IClickable objectClicked = CheckForClickableObject();
                    if (objectClicked != null)
                    {
                        objectClicked.OnClick();
                    }
                    break;
            }   
        }
    }

    private IClickable CheckForClickableObject()
    {
        IClickable objectFound = null;

        // Get mouse position in world
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;

        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector3 raycastPos = new Vector3(mousePos.x, mousePos.y, 0);

        RaycastHit2D hit = Physics2D.Raycast(raycastPos, Vector3.forward);
        if (hit)
        {
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject.GetComponent<IClickable>() != null)
            {
                objectFound = hitObject.GetComponent<IClickable>();
                //hitObject.GetComponent<IClickable>().OnClick();
            }
        }
        return objectFound;
    }    

}