using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeContainer : MonoBehaviour
{
    //holds objects containing nodes  here
    public Transform upContainer;
    public Transform downContainer;
    public Transform leftContainer;
    public Transform rightContainer;


    //Nodes extracted
    public NodeContainer up { get; private set; }
    public NodeContainer down { get; private set; }
    public NodeContainer left { get; private set; }
    public NodeContainer right { get; private set; }

    //coordinate of the transform. Reference for moving the camera to the node
    public Vector3 coord;

    //initializes nodes
    private void Start()
    {
        coord = transform.position;
        up = upContainer != null ? upContainer.GetComponent<NodeContainer>() : null;
        down = downContainer != null ? downContainer.GetComponent<NodeContainer>() : null;
        left = leftContainer != null ? leftContainer.GetComponent<NodeContainer>() : null;
        right = rightContainer != null ? rightContainer.GetComponent<NodeContainer>() : null;
 
    }

}
