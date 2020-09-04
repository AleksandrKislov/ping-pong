using UnityEngine;
using System.Collections;

public class Player1 : MonoBehaviour
{
	[SerializeField]
	private float speed = 5.0F;

	new private Rigidbody2D rigidbody;

	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		if (Input.GetButton ("Vertical")) Move ();
	}

	public void Move()
	{
		if (Input.GetKey (KeyCode.W)) 
		{
			Vector3 direction = transform.up;
			transform.position = Vector3.MoveTowards (transform.position, transform.position + direction, speed * Time.deltaTime * 2);
		}
		if (Input.GetKey (KeyCode.S)) 
		{
			Vector3 direction = -transform.up;
			transform.position = Vector3.MoveTowards (transform.position, transform.position + direction, speed * Time.deltaTime * 2);
		}
	}
}