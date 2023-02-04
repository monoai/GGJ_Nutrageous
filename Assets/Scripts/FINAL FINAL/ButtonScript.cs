using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    //Determines the direction in which the button points
    public enum direction { up, down, left, right}
    [SerializeField] private Camera cam;

    [SerializeField] private direction dir;

    private Vector3 targetLocation = Vector3.zero;

    private NodeContainer bufferedNode = null;

    //Moves camera to the next node based on NodeContainer. Checks first if the Node is not null
    public void MoveCamera()
    {
        
        NodeContainer currentNode = cam.GetComponent<CameraScript>().currentNodeLookingAt;

        NodeContainer newNode = null;

        switch (dir)
        {
            case direction.up: 
                if(currentNode.up != null) newNode = currentNode.up; 
            break;
            case direction.down:
                if (currentNode.down != null) newNode = currentNode.down;
            break;
            case direction.left:
                if (currentNode.left != null) newNode = currentNode.left;
            break;
            case direction.right:
                if (currentNode.right != null) newNode = currentNode.right;
            break;
        }

        if (newNode != null) {

            targetLocation = new Vector3(newNode.coord.x, newNode.coord.y, cam.transform.position.z);
            cam.GetComponent<CameraScript>().SetInteractables(false);
           
            bufferedNode = newNode;        
        }
    }

    private void Update()
    {
        if(bufferedNode != null)
        {
            cam.transform.position = Vector3.MoveTowards(cam.transform.position,
             new Vector3(targetLocation.x, targetLocation.y, cam.transform.position.z), speed);

            if (Vector3.Equals(cam.transform.position, targetLocation))
            { 
                cam.GetComponent<CameraScript>().currentNodeLookingAt = bufferedNode;
                cam.GetComponent<CameraScript>().UpdateButtons();
                cam.GetComponent<CameraScript>().SetInteractables(true);
                bufferedNode = null;
            }
        }
    }

     
}
