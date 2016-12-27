using UnityEngine;
using System.Collections;

public class RotateMe : MonoBehaviour 
{
	public float speed = 1.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 eulerAngle = transform.eulerAngles;
		eulerAngle.y += Time.deltaTime * speed;
		this.transform.eulerAngles = eulerAngle;
	}
}
