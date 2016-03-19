using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {
	[SerializeField]
	public float speed = 0.1f;
	[SerializeField]
	float Turn = 1;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Turn -= Time.deltaTime;
		if (Turn <= 0) {
			move ();
		}
	}

	void move()
	{
		Vector3 position = this.transform.position;
		position.y += speed;
		this.transform.position = position;
	}
}
