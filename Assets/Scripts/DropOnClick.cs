using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOnClick : MonoBehaviour {
	public Rigidbody2D rb2D;
	public Collider2D cldr2D;
	private float maxWidth;
	private bool mouseClicked=false;
	private float lastClick=1;
	public Camera cam;
	public DropOnClick(){
	}
	// Use this for initialization
	void Start () {
			if (cam==null)
			{
				cam = Camera.main;
			}
		cldr2D = GetComponent<Collider2D>();
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targW = cam.ScreenToWorldPoint (upperCorner);
		maxWidth = targW.x;

	}

	// Update is called once per frame
	void FixedUpdate () {
		//lastClick -= Time.deltaTime;
		if (!mouseClicked) {
			Vector3 rawPos = cam.ScreenToWorldPoint (Input.mousePosition);
			Vector3 targPos = new Vector3 (rawPos.x, transform.position.y, 0.0f);
			float targW = Mathf.Clamp (targPos.x, -maxWidth, maxWidth);
			targPos = new Vector3 (targW, targPos.y, targPos.z);
			rb2D.MovePosition (targPos);
		}
		if (Input.GetMouseButtonDown(0)) {//And if 1 second since the last click
			mouseClicked = true;
			rb2D.bodyType = RigidbodyType2D.Dynamic;
			cldr2D.enabled = true;
	}
}
}
