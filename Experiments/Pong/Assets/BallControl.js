#pragma strict

var ballSpeed : float = 100;


function Start () {
	yield WaitForSeconds(2);
	GoBall();
}

function OnCollisionEnter2D(colInfo : Collision2D) {
	if (colInfo.collider.tag == "Player") {
		rigidbody2D.velocity.y = rigidbody2D.velocity.y/2 + colInfo.collider.rigidbody2D.velocity.y/3;
	}
}

function GoBall() {
	var randomNumber = Random.Range(0, 2);
	
	if (randomNumber <= 0.5) {
		rigidbody2D.AddForce (new Vector2 (ballSpeed, 10));
	}
	else {
		rigidbody2D.AddForce (new Vector2 (-ballSpeed, -10));
	}
}