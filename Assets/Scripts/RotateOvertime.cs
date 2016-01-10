using UnityEngine;
using System.Collections;

public class RotateOvertime : MonoBehaviour {


	public float speed = 3f;

	// Use this for initialization
	void Start () {

	}

	void Update()
	{
		transform.eulerAngles += new Vector3(0f, 1f * Time.deltaTime * speed, 0f);
	}

}
