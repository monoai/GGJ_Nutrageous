using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{
    //holds which node that the camera is currently looking at
    public NodeContainer currentNodeLookingAt;

    [SerializeField] private Button up;
    [SerializeField] private Button down;
    [SerializeField] private Button left;
    [SerializeField] private Button right;

    //Adds or emoves buttons depending if the node it points to is null
    public void UpdateButtons()
    {
        up.gameObject.SetActive(currentNodeLookingAt.up != null);
        down.gameObject.SetActive(currentNodeLookingAt.down != null);
        left.gameObject.SetActive(currentNodeLookingAt.left != null);
        right.gameObject.SetActive(currentNodeLookingAt.right != null);
    }

    public void SetInteractables(bool state)
    {
        up.interactable = state;
        down.interactable = state;
        left.interactable = state;
        right.interactable = state;
    }

    //This is a band aid fix to apply UpdateButtons function at the start but Start function runs first before
    //the values are initialized
    private bool debouncer = false;
    private void Update()
    {
        if (!debouncer) { 
            UpdateButtons();
            debouncer = true;
        }
    }
}
