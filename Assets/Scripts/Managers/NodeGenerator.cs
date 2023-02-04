using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeGenerator : MonoBehaviour
{
    // We supply the base node template here which should be a prefab.
    [Header("Node Template")]
    [SerializeField] private GameObject nodeTemplate;

    // Collection of sprites for the node parts
    [Header("Sprites")]
    // Eyes
    [Header("Eyes")]
    public Sprite eye_tri;
    public Sprite eye_sqr, eye_cir, eye_ova, eye_rec, eye_dia;
    // Nose
    [Header("Nose")]
    public Sprite nose_tri;
    public Sprite nose_sqr, nose_cir, nose_ova, nose_rec, nose_dia;
    // Mouth
    //[Header("Mouth")]
    //public Sprite mouth_tri, mouth_sqr, mouth_cir, mouth_ova, mouth_rec, mouth_dia;
    // Ears
    [Header("Ears")]
    public Sprite ears_tri;
    public Sprite ears_sqr, ears_cir, ears_ova, ears_rec, ears_dia;

    // Start is called before the first frame update
    void Start()
    {
	// Assume on level start/open the nodes will be generated.
	GenerateNode();
    }

    private void GenerateNode(){
	// Assume that the object is being generated on a proper game object, else replace this with the proper parent gameobject.
	GameObject nodeObj = Instantiate(nodeTemplate, this.transform);
	NodeDummy node = nodeObj.GetComponent<NodeDummy>();
	node.SetTrait(TraitNames.Traits.Eyes, TraitNames.Attributes.TRIANGLE);
    }
}
