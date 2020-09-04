using UnityEngine;
using System.Collections;

public class Player2 : MonoBehaviour
{
	#region fields
	public Score score;
	#endregion

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
		if (Input.GetKey (KeyCode.Space) && (score.p2score == 5 || score.p1score ==5)) Application.LoadLevel (0);
	}

	public void Move()
	{
		if (Input.GetKey (KeyCode.UpArrow))
		{
			Vector3 direction = transform.up;
			transform.position = Vector3.MoveTowards (transform.position, transform.position + direction, speed * Time.deltaTime * 2);
		}
			if (Input.GetKey (KeyCode.DownArrow)) 
		{
			Vector3 direction = -transform.up;
			transform.position = Vector3.MoveTowards (transform.position, transform.position + direction, speed * Time.deltaTime * 2);	
		}
	}
}
