﻿using UnityEngine;
using UnityEngine.UI;
using CnControls;
using System.Collections;


public class PlayerController : MonoBehaviour {

	public float speed;
	private int count;
	private Rigidbody rb;
	public Text countText;
	public Text winText;


	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";

	}

	void FixedUpdate ()
	{
		
		float moveHorizontal = CnInputManager.GetAxis ("Horizontal");
		float moveVertical = CnInputManager.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Pick Up")) {
		
			other.gameObject.SetActive (false);
			count += 1;
			SetCountText ();
		}
	}
	void SetCountText ()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 10)
		{
			winText.text = "You Win! ";
		}
		if (count == 9) {
		
			winText.text = "Last Left!! ";
		}
	}

}

