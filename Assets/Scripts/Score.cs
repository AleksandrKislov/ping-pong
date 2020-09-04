using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {
	#region fields
	public Text scoreText;
	public Ball ball;
	#endregion
	public int p1score = 0;
	public int p2score = 0;

	public void HandlePlayerScore (int PlayerScoredNumberIn)
	{
		if (PlayerScoredNumberIn == 1) 
		{
			p1score++;
		} 
		if (PlayerScoredNumberIn == 2) 
		{
			p2score++;
		}
		UpdateScore ();
	}

	public void UpdateScore()
	{
		scoreText.text = p1score + "             " + p2score;
		if (p1score > 4 || p2score > 4) 
		{
			scoreText.color = Color.white;
			scoreText.text = "  game      over\n\r" + "    press     Space";
		}
	}
}
