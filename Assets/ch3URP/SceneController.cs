using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneController : MonoBehaviour
{
	[SerializeField] private GameObject enemyPrefab;
	[SerializeField] private GameObject tombstonePrefab;

	private List<GameObject> _enemies = new List<GameObject>();
	private int _enemyCount = 1;

	void Update()
	{
		for (int i = _enemies.Count - 1; i >= 0; i--)
		{
			if (_enemies[i] == null)
			{
				_enemies.RemoveAt(i);
				_enemyCount++;
			}
		}

		while (_enemies.Count < _enemyCount)
		{
			GameObject enemy = Instantiate(enemyPrefab) as GameObject;
			enemy.transform.position = new Vector3(Random.Range(-10, 10), 1, Random.Range(-10, 10));
			float angle = Random.Range(0, 360);
			enemy.transform.Rotate(0, angle, 0);
			_enemies.Add(enemy);
		}
	}
}