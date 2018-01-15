using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour {
	public Camera cam;
	private float maxWidth;
	private float maxHeight;
	private bool camControl;
	private int whatIsSpawned;

	public GameObject Square;
	public GameObject Triangle;
	public GameObject Circle;
	public GameObject Rectangle;


	// Use this for initialization
	void Start () {
		if (cam==null)
		{
			cam = Camera.main;
		}

		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targ = cam.ScreenToWorldPoint (upperCorner);
		maxWidth = targ.x;
		maxHeight = targ.y;
		SpawnItem (Square);

	}

	IEnumerator SpawnItem(GameObject item){

		Vector3 rawPos = cam.ScreenToWorldPoint (Input.mousePosition);
		Vector3 targPos = new Vector3 (rawPos.x, rawPos.y , 0.0f);
		float targW = Mathf.Clamp (targPos.x, -maxWidth, maxWidth);
		float targH = Mathf.Clamp (targPos.y, -maxHeight, maxHeight);
		targPos = new Vector3(targW, targH, targPos.z);
		Instantiate(item, targPos, Quaternion.Euler(new Vector3(0, 0, 0)));
		yield return new WaitForSeconds (1);

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			whatIsSpawned=(Random.Range(0,4));
			switch(whatIsSpawned) {
			case 0 :StartCoroutine(SpawnItem(Square));  // prints "1"
				break;       // and exits the switch
			case 1 : StartCoroutine(SpawnItem(Triangle));
				break;
			case 2 : StartCoroutine(SpawnItem(Circle));
				break;
			case 3: StartCoroutine(SpawnItem(Rectangle));
				break;
			
			}
	
		}
		//spawn new block at x location of mouse and follow
	}
}
