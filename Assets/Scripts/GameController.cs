using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour {
	public Camera cam;
	private float maxWidth;
	private float maxHeight;
	private bool camControl;
	public GameObject Square;
	public GameObject Triangle;


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

			StartCoroutine(SpawnItem(Square));
		}
		//spawn new block at x location of mouse and follow
	}
}
