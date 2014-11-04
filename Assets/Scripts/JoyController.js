#pragma strict

var joyStickPlayer:Joystick;

var speed:float;
var countText:GUIText;
var winText:GUIText;
var count:int;

function SetCountText()
{
	countText.text = "Count: " + count.ToString ();
	if (count >= 12) 
	{
		winText.text = "YOU WIN!";
	}
}

function Start () 
{
	count = 0;
	SetCountText();
	winText.text = "";

}

function Update ()
{
	if(joyStickPlayer.tapCount >0 )
	{
		var joyPosition_x = joyStickPlayer.position.x;
		var joyPosition_y = joyStickPlayer.position.y;
		var movement:Vector3 = new Vector3 (joyPosition_x, 0.0f, joyPosition_y);
		rigidbody.AddForce (movement * speed * Time.deltaTime);
	} else {
		var moveHorizontal:float = Input.GetAxis("Horizontal");
		var moveVertical:float = Input.GetAxis("Vertical");
		var movementAxis:Vector3 = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rigidbody.AddForce (movementAxis * speed * Time.deltaTime);
	}	
	
}

function OnTriggerEnter(other:Collider)
{
	if (other.gameObject.tag == "PickUp")
	{
		other.gameObject.SetActive(false);
		count = count+1;
		SetCountText();
	}
}
