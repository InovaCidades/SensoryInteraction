#pragma strict

function Start () {
	var randomNumber = Random.Range(0, 2);
	
	if (randomNumber <= 0.5) {
		rigidbody2D.AddForce (new Vector2 (80, 10));
	}
	else {
		rigidbody2D.AddForce (new Vector2 (-80, -10));
	}
}

function OnCollisionEnter2D(colInfo : Collision2D) {
	if (colInfo.collider.tag == "Player") {
		Debug.Log("Its working!");
	}
}