using UnityEngine;
using System.Collections;

public class Enemie : MonoBehaviour {

	enum Emove
	{
		LEFT,
		RIGHT,
	}

	[SerializeField]
	public float speed;
	public int direction = (int)Emove.RIGHT;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Move ((int)direction);
	}

	void Move(int State)
	{
		Vector3 position = this.transform.position;
		if (State == (int)Emove.LEFT) {
			
			if (this.transform.position.y > 0)
				position.y *= -1;
			position.x =- speed;
			
		}
		else if (State == (int)Emove.RIGHT) {
			
			if (this.transform.position.y < 0)
				position.y *= -1;
			position.x = speed;
			
		}
		this.transform.position = position;
	}
}
