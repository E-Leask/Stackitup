using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public Camera cam;
	private float maxWidth;
	private bool camControl;
	public GameObject dropItem;

	// Use this for initialization
	void Start () {
		if (cam==null)
		{
			cam = Camera.main;
		}
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targW = cam.ScreenToWorldPoint (upperCorner);
		maxWidth = targW.x;
	}

	IEnumerator SpawnItem(GameObject item){

		Vector3 rawPos = cam.ScreenToWorldPoint (Input.mousePosition);
		Vector3 targPos = new Vector3 (rawPos.x, transform.position.y , 0.0f);
		float targW = Mathf.Clamp (targPos.x, -maxWidth, maxWidth);
		targPos = new Vector3(targW, targPos.y, targPos.z);
	Instantiate(item, targPos, Quaternion.Euler(new Vector3(0, 0, 0)));
		yield return new WaitForSeconds (5);

	}
	
	// Update is called once per frame
	void Update () {
		//yield return new WaitForSeconds (2);
		if (Input.GetMouseButtonDown (0)) {
			StartCoroutine(SpawnItem(dropItem));
		}
		//on mouse click release block
		//wait 2 seconds
		//spawn new block at location of gamecontroller
	}
}
