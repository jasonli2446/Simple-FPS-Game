using UnityEngine;
using System.Collections;

public class PlayerCharacter : MonoBehaviour
{
	private int _health;
	public GameObject gameOverText;

	void Start()
	{
		_health = 2;
	}

	public void Hurt(int damage)
	{
		_health -= damage;
		if (_health <= 0)
		{
			if (gameOverText != null)
			{
				gameOverText.SetActive(true);
			}
		}
	}

	public int GetHealth()
	{
		return _health;
	}
}
