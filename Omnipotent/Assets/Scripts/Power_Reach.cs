﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Power_Reach : Powers {

	public GameObject Reach;

	// Use this for initialization
	void Start () {
		time_left = Cooldown;
		refresh = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (cursor.mode == cursor_handle.MODE.BUILD)
			GetComponent<Button> ().interactable = false;
		else if (cursor.mode == cursor_handle.MODE.DEFAULT)
			GetComponent<Button> ().interactable = true;

		if ( !enabled )	return;

		if (active && time_left <= Cooldown - CastTime) {
			active = false;
			Reach.SetActive (false);
			cursor.setMode (cursor_handle.MODE.DEFAULT);
		}

		if (time_left <= 0.0f) {
			time_left = Cooldown;
			refresh = true;
		}
		if (active) {
			Reach.transform.position = cursor.cursor3d;
		}

		UpdateLast ();
	}

	public void Trigger (Vector3 loc) {
		if (!enabled)	return;

		if (time_left <= 0.0f) {
			time_left = Cooldown;
			refresh = true;
		}

		if ( refresh ) {
			refresh = false;
			active = true;
			time_left = Cooldown;
			location = loc;
			Reach.SetActive (true);
			Reach.transform.position = loc;
		}
	}

	public void AddXP (int num_of_people, int flag) {
		XP.AddXP (num_of_people * XP_per_NPC, PowerType);
	}
	
	public void OnClick () {
		cursor.setMode (cursor_handle.MODE.REACH);
	}
}