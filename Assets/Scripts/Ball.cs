using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	private int randomNumber;	
	private float timeout;
	new private Rigidbody2D rigidbody;
	private Vector3 ballPosition;
	public GameObject ball;

	#region fields
	public Score score;
	#endregion

	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody2D>();
	}
		
	IEnumerator Start()
	{
		yield return new WaitForSeconds (3);
			randomNumber = Random.Range (0, 3);
			if (randomNumber < 2) {
				rigidbody.AddForce (new Vector3 (-40, Random.Range (-20, 20)));
			} else {
				rigidbody.AddForce (new Vector3 (40, Random.Range (-20, 20)));
			}
	}

	private void Update()
	{
		timeout += Time.deltaTime;
		if (timeout > 10) 
		{
			timeout = 0;
			randomNumber = Random.Range (0, 3);
			if (randomNumber < 2) {
				rigidbody.AddForce (new Vector3 (-40, Random.Range (-20, 20)));
			} else {
				rigidbody.AddForce (new Vector3 (40, Random.Range (-20, 20)));
			}
		}
	}

    void OnCollisionEnter2D(Collision2D col)
	{
		if (col.collider.tag == "Balk") 
		{
			timeout = 0;
			rigidbody.AddForce (new Vector3 (10, Random.Range (-20, 20)));
		}

		int PlayerNumberWhoScored = 0;
		if (col.collider.tag == "Wall1") 
		{
			PlayerNumberWhoScored = 2;
		}
		if (col.collider.tag == "Wall2") 
		{
			PlayerNumberWhoScored = 1;
		}

		score.HandlePlayerScore (PlayerNumberWhoScored);

		if (col.collider.tag == "Wall1" || col.collider.tag == "Wall2") 
		{
			if (score.p1score <= 4 && score.p2score <= 4) 
			{
				GameObject NewBall = Instantiate (ball, ballPosition, Quaternion.identity) as GameObject;	
			}
			GameOver ();
			Start ();
		}
	}

	public void GameOver()
	{
		Destroy (gameObject);
	}
}
