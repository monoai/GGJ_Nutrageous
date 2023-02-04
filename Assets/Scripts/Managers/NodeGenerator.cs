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
	public List<Sprite> eyesList = new List<Sprite>();
	//public Sprite eye_tri;
	//public Sprite eye_sqr, eye_cir, eye_ova, eye_rec, eye_dia;

	// Ears
	[Header("Ears")]
	public List<Sprite> earsList = new List<Sprite>();
	//public Sprite ears_tri;
	//public Sprite ears_sqr, ears_cir, ears_ova, ears_rec, ears_dia;

	// Nose
	[Header("Nose")]
	public List<Sprite> nosesList = new List<Sprite>();
    //public Sprite nose_tri;
	//public Sprite nose_sqr, nose_cir, nose_ova, nose_rec, nose_dia;

    // Mouth
    //[Header("Mouth")]
    //public Sprite mouth_tri, mouth_sqr, mouth_cir, mouth_ova, mouth_rec, mouth_dia;

    [Header("Hair")]
	public List<Sprite> hairsList = new List<Sprite>();
    //public Sprite hair_0;
	//public Sprite hair_1, hair_2, hair_3, hair_4, hair_5, hair_6, hair_7, hair_8, hair_9, hair_10;

    [Header("Makeup")]
	public List<Sprite> makeupsList = new List<Sprite>();
    //public Sprite makeup_0;
	//public Sprite makeup_1, makeup_2, makeup_3, makeup_4, makeup_5, makeup_6, makeup_7, makeup_8, makeup_9, makeup_10;

    [Header("Frame")]
	public List<Sprite> framesList = new List<Sprite>();
    //public Sprite frame_1;
	//public Sprite frame_2, frame_3;

	// While we haven't done the actual level implementations, any other necessary information about the level that the node generator also needs will be here. Maybe we could transfer it somewhere else or maybe reworked into another script, we'll figure it out.
    [Header("Level Information")]
    [Header("Tiers")]
    [SerializeField] private int[] tier;

    // This shouldn't be visible, only needed by the generator's algorithm
    [Header("Algorithm Variables")]
    private int currDepth = 0;
    private int currNodes = 0;
    private int hiddenCount = 0;

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
		GenerateNode(3, null, currDepth);
		//currDepth++;
	//}
    }

    private GameObject GenerateNode(int children, GameObject parent, int currDepth){
	// Assume that the object is being generated on a proper game object, else replace this with the proper parent gameobject.
	GameObject nodeObj = Instantiate(nodeTemplate, this.transform);
	// Don't forget to replace with proper node script
	Node node = nodeObj.GetComponent<Node>();
	node.Parent = parent;
	assignTrait(nodeObj, currDepth);
	node.SetDepth(currDepth);
	//SetSprites(nodeObj);
	if(currDepth < 3) {
		for(int i = 0; i < children; i++){
			int child = 0;
			// Every time the depth is the third tier/layer, it will instead spawn 3 children instead of 2.
			if(currDepth % 3 == 0) {
				child = 3;
			} else {
				child = 2;
			}
			var newNode = GenerateNode(child, nodeObj, currDepth+1);
			node.Connections.Add(newNode);
			//newNode.GetComponent<Node>().Parent = nodeObj;
			newNode.GetComponent<Node>().SetDepth(currDepth+1);
			if(CoinFlip() == 1 && hiddenCount < 3) {
				newNode.GetComponent<Node>().SetHidden(true);
				hiddenCount++;
			}
			if (CoinFlip() == 2 && !newNode.GetComponent<Node>().GetPlayerFlag()){
				newNode.GetComponent<Node>().SetPlayerFlag(true);
            }

		}
	}
	return nodeObj;
    }

    private int CoinFlip() {
	return Random.Range(0,2);
    }

    private void assignTrait(GameObject nodeObj, int currDepth) {
	Node node = nodeObj.GetComponent<Node>();
	//SetFrame
	var attribute = (TraitNames.Attributes)Random.Range(0,6);
	node.SetFrame(TraitNames.Traits.Frame, (TraitNames.Frame)1);
	node.SetSprite(TraitNames.Traits.Frame, framesList[1]);
		if (currDepth == 1)
		{
			node.SetTrait(TraitNames.Traits.Eyes, attribute);
			node.SetSprite(TraitNames.Traits.Eyes, eyesList[(int)attribute]);
		}
		else if (currDepth == 2) {
		//Gets parents' traits then assigns
		var eyes = node.Parent.GetComponent<Node>().GetTraits(TraitNames.Traits.Eyes);
		node.SetTrait(TraitNames.Traits.Eyes, (TraitNames.Attributes)eyes);
		node.SetSprite(TraitNames.Traits.Eyes, eyesList[eyes]);

		node.SetTrait(TraitNames.Traits.Ears, attribute);
		node.SetSprite(TraitNames.Traits.Ears, earsList[(int)attribute]);

		node.SetFrame(TraitNames.Traits.Frame, (TraitNames.Frame)2);
		node.SetSprite(TraitNames.Traits.Frame, framesList[2]);
			//SetFrame
		}
		else if (currDepth == 3) {
		//Gets parents' traits then assigns
		var eyes = node.Parent.GetComponent<Node>().GetTraits(TraitNames.Traits.Eyes);
		node.SetTrait(TraitNames.Traits.Eyes, (TraitNames.Attributes)eyes);
		node.SetSprite(TraitNames.Traits.Eyes, eyesList[eyes]);

		var ears = node.Parent.GetComponent<Node>().GetTraits(TraitNames.Traits.Ears);
		node.SetTrait(TraitNames.Traits.Ears, (TraitNames.Attributes)ears);
		node.SetSprite(TraitNames.Traits.Ears, earsList[ears]);

		node.SetTrait(TraitNames.Traits.Nose, attribute);
		node.SetSprite(TraitNames.Traits.Nose, nosesList[(int)attribute]);

		node.SetFrame(TraitNames.Traits.Frame, (TraitNames.Frame)3);
		node.SetSprite(TraitNames.Traits.Frame, framesList[3]);
			//SetFrame
		}
		else {
		Debug.Log("It is a mystery");
	}
	var hair = (TraitNames.Hair)Random.Range(0,11);
	var makeup = (TraitNames.Makeup)Random.Range(0,8);
	node.SetHair(TraitNames.Traits.Hair, hair);
	node.SetMakeup(TraitNames.Traits.Makeup, makeup);

	node.SetSprite(TraitNames.Traits.Hair, hairsList[(int)hair]);
	node.SetSprite(TraitNames.Traits.Makeup, makeupsList[(int)makeup]);
	}


 //   private void SetSprites(GameObject node){
	//// TODO: Add actual sprite replacements.
	//SpriteRenderer sprite = node.GetComponent<SpriteRenderer>();
	//sprite.color = Color.blue;
 //   }
}
