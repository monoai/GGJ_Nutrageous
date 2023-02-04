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

    // While we haven't done the actual level implementations, any other necessary information about the level that the node generator also needs will be here. Maybe we could transfer it somewhere else or maybe reworked into another script, we'll figure it out.
    [Header("Level Information")]
    [Header("Tiers")]
    [SerializeField] private int[] tier;

    // This shouldn't be visible, only needed by the generator's algorithm
    [Header("Algorithm Variables")]
    private int currDepth;
    private int currNodes = 0;

    // Start is called before the first frame update
    void Start()
    {
	// Assume on level start/open the nodes will be generated.
	init();
	//GenerateNode();
    }

    private void init() {
	Debug.Log("currDepth: " + currDepth);
	Debug.Log("tier.Length: " + tier.Length);
	//while(currDepth != tier.Length) {
		GenerateNode(2, currDepth);
		//currDepth++;
	//}
    }

    private GameObject GenerateNode(int children, int currDepth){
	// Assume that the object is being generated on a proper game object, else replace this with the proper parent gameobject.
	GameObject nodeObj = Instantiate(nodeTemplate, this.transform);
	// Don't forget to replace with proper node script
	Node node = nodeObj.GetComponent<Node>();
	/*
	node.SetTrait(TraitNames.Traits.Eyes, TraitNames.Attributes.TRIANGLE);
	node.SetTrait(TraitNames.Traits.Nose, TraitNames.Attributes.SQUARE);
	//node.SetTrait(TraitNames.Traits.Mouth, TraitNames.Attributes.TRIANGLE);
	node.SetTrait(TraitNames.Traits.Ears, TraitNames.Attributes.CIRCLE);
	*/
	SetSprites(nodeObj);
	if(currDepth < 3) {
		for(int i = 0; i < children; i++){
			var newNode = GenerateNode(2, currDepth+1);
			node.Connections.Add(newNode);
			newNode.GetComponent<Node>().Parent = nodeObj;
		}
	}
	return nodeObj;
    }

    private void SetSprites(GameObject node){
	// TODO: Add actual sprite replacements.
	SpriteRenderer sprite = node.GetComponent<SpriteRenderer>();
	sprite.color = Color.blue;
    }
}
