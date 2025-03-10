﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI; /* Required for controlling Canvas UI system */


public class RayShooter : MonoBehaviour {
	private Camera _camera;
	[SerializeField] private GameObject reticle;
	[SerializeField] private AudioClip shootingSound;
	private AudioSource audioSource;

	void Start() {
		_camera = GetComponent<Camera>();
		audioSource = GetComponent<AudioSource>();

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

		reticle = GameObject.Find("Reticle");
		reticle.GetComponent<Text>().text = "+";
		reticle.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
		reticle.GetComponent<RectTransform>().position =
            new Vector3(_camera.pixelWidth / 2.0f,
                        _camera.pixelHeight / 2.0f,
                        0.0f);
	}

    /** Deprecated in Unity 2018 
	void OnGUI() {
		int size = 12;
		float posX = _camera.pixelWidth/2 - size/4;
		float posY = _camera.pixelHeight/2 - size/2;
		GUI.Label(new Rect(posX, posY, size, size), "*");
	}
    **/
    

	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			audioSource.PlayOneShot(shootingSound);
			Vector3 point = new Vector3(_camera.pixelWidth/2, _camera.pixelHeight/2, 0);
			Ray ray = _camera.ScreenPointToRay(point);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) {
				GameObject hitObject = hit.transform.gameObject;
				ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
				if (target != null) {
					target.ReactToHit();
				} else {
					StartCoroutine(SphereIndicator(hit.point));
				}
			}
		}
	}

	private IEnumerator SphereIndicator(Vector3 pos) {
		GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		sphere.transform.position = pos;

		yield return new WaitForSeconds(1);

		Destroy(sphere);
	}
}