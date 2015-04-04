using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	CharacterController controller;

	public float speed = 2f;

	void Start () {
		controller = GetComponent<CharacterController>();
	}

	void Update () {
		HandleMovement();
	}

	void HandleMovement() {
		Vector3 dir = new Vector3(Input.GetAxis("Vertical"), 0f, Input.GetAxis("Horizontal"));

		controller.Move(dir * speed * Time.deltaTime);
	}
}
