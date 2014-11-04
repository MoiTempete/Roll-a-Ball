using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float speed;
	public GUIText countText;
	public GUIText winText;
	private int count;

	void Start()
	{
		count = 0;
		SetCountText ();
		winText.text = "";
	}
	/*
	 * function Update ()
{
if(joyStickPlayer.tapCount >0 )
{
        var joyPosition_x = joyStickPlayer.position.x;
        var joyPosition_y = joyStickPlayer.position.y;
         
        if(joyPosition_y != 0 || joyPosition_x != 0)
        {
                hero.transform.Translate(Vector3.forward* Time.deltaTime * 5);
                hero.transform.LookAt(Vector3(hero.transform.position.x + joyPosition_x,hero.transform.position.y,hero.transform.position.z + joyPosition_y));
                hero.animation.Play("run");
        }
        else
        {
                hero.animation.Play("idle");
        }
}     
	 * */

	void FixedUpdate()
	{

		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rigidbody.AddForce (movement * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "PickUp")
		{
			other.gameObject.SetActive(false);
			count = count+1;
			SetCountText();
		}
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 12) 
		{
			winText.text = "YOU WIN!";
		}
	}

}
