using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TangoCameraController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int count;

	//private PoseController pose;

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";

		//pose = new PoseController ();
	}

	// Update is called once per frame
	void Update () 
	{

	}

	void FixedUpdate () 
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);

		//countText.text = "Position: " + pose.GetTangoPosition () + " Rotation: " + pose.GetTangoRotation ();
	}

	void OnTriggerEnter (Collider other) 
	{
		if (other.gameObject.CompareTag("Pick Up"))
		{
			other.gameObject.SetActive(false);
			count = count + 1;
			SetCountText ();
		}
	}

	void SetCountText() 
	{
		//countText.text = "Position: " + pose.GetTangoPosition () + " Rotation: " + pose.GetTangoRotation ();

		if (count >= 12) 
		{
			winText.text = "You Win!";
		}
	}
}
