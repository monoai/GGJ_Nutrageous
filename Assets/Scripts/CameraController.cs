using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private float speed = 3f;
    float horizontalInput;
    private Vector3 velocity = Vector3.zero;
    [SerializeField]private Camera m_Camera;

    [SerializeField] Transform currentNode;

    [SerializeField] Transform left;
    [SerializeField] Transform right;
    [SerializeField] Transform up;
    [SerializeField] Transform down;

    private void Start()
    {
        SwitchCurrentNode(currentNode);
    }

    public enum direction { up, down, left, right}

    public void MoveCamera(int dir)
    {
        Transform TargetNode = null;

        switch ((direction)dir)
        {
                case direction.up: TargetNode = up; break;
                case direction.down: TargetNode = down;break;
                case direction.left: TargetNode = left; break;
                case direction.right: TargetNode = right; break;
        }

        if (TargetNode != null) {

            m_Camera.transform.position = new Vector3(TargetNode.position.x, m_Camera.transform.position.y, m_Camera.transform.position.z);
            SwitchCurrentNode(TargetNode);

        }

    }

    private void SwitchCurrentNode(Transform TargetNode)
    {
        //if (TargetNode == null) return;

        currentNode = TargetNode;

        MockUpNodes noderef = currentNode.GetComponent<MockUpNodes>();

        left = noderef.left;
        right = noderef.right; 
        up = noderef.up; 
        down = noderef.down;
    }

}
