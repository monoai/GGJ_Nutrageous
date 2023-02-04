using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] private Transform MockUpNode;
    [SerializeField] private Transform TargetNode;

    [SerializeField] private Camera cam;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private float speed = 3f;
    public void CameraPan()
    {
        Debug.Log("I run");
        cam.transform.position = new Vector3(TargetNode.position.x, cam.transform.position.y, cam.transform.position.z);

        Transform hold;

        hold = MockUpNode;
        MockUpNode = TargetNode;
        TargetNode = hold;
    }
}
