using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    // enum/int Traits
    // enum/int Personality
    // List of connections
    enum Traits { Eyes, Ears, Nose, Mouth }
    enum Personality { Personality1 = 0, Personality2 = 1, Personality3 = 2 }
    LinkedList<Node> Connections = new LinkedList<Node> ();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
