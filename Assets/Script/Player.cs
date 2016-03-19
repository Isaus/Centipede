using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	Dictionary<string, bool> Action;
	[SerializeField]
	GameObject Missile;
	[SerializeField]
	public float speed;
	[SerializeField]
	public float TurnTime = 10;
	[SerializeField]
	float Turn;
	[SerializeField]
	int CouldDownShot = 3;
	int CDShot = 0;
	Animator anime;

	enum Emove
	{
		LEFT,
		RIGHT,
	}

	// Use this for initialization
	void Start () {
		Action = new Dictionary<string, bool>(){{"Rigth", false},
			{"Left", false},
			{"Shot", false}};
		anime = GetComponent<Animator> ();
		Turn = TurnTime;
	}
	
	// Update is called once per frame
	void Update () {
		Turn -= Time.deltaTime;
		if (Turn <= 0) {
			if (Input.GetKeyDown (KeyCode.LeftArrow))
				Action ["Left"] = true;
			if (Input.GetKeyUp (KeyCode.LeftArrow)) {
				Action ["Left"] = false;
				anime.SetInteger ("Id", 8);
			}
			if (Input.GetKeyDown (KeyCode.RightArrow))
				Action ["Rigth"] = true;
			if (Input.GetKeyUp (KeyCode.RightArrow)) {
				Action ["Rigth"] = false;
				anime.SetInteger ("Id", 2);
			}
			if (Input.GetKeyDown (KeyCode.Space))
				Action ["Shot"] = true;
			else if (Input.GetKeyUp (KeyCode.Space)) {
				Debug.Log ("Poney");
				Action ["Shot"] = false;
				anime.SetInteger ("Id", 4);
			}

			/*Action["left"] = Input.GetKey(KeyCode.LeftArrow);
			if (Action["left"] == false)
				anime.SetInteger ("Id", 8);
			Action["Rigth"] = Input.GetKey(KeyCode.RightArrow);
			if (Action["Rigth"] == false)
				anime.SetInteger ("Id", 2);
			Action["Shot"] = Input.GetKey(KeyCode.Space);
			if (Action["Shot"] == false)
				anime.SetInteger ("Id", 4);*/

			if (Action ["Left"] == true)
				Move ((int)Emove.LEFT);
			else if (Action ["Rigth"] == true)
				Move ((int)Emove.RIGHT);
			if (Action ["Shot"] && CDShot <= 0)
				Shot ();
			CDShot -= CDShot == 0 ? 0 : 1;
			}
	}

	void Shot()
	{
		CDShot = CouldDownShot;
		anime.SetInteger("Id", 3);
		Instantiate (Missile, this.transform.position, new Quaternion());
	}

	void Move(int State)
	{
		Vector3 position = this.transform.position;
		if (State == (int)Emove.LEFT) {
			anime.SetInteger("Id", 7);
			position.x -= speed;

		}
		if (State == (int)Emove.RIGHT) {
			anime.SetInteger("Id", 1);
			position.x += speed;
			
		}
		this.transform.position = position;
	}
}
