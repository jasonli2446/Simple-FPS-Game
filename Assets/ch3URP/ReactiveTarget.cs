using UnityEngine;
using System.Collections;

public class ReactiveTarget : MonoBehaviour
{
	[SerializeField] private GameObject tombstonePrefab;
	[SerializeField] private GameObject deathParticlesPrefab;
	[SerializeField] private AudioClip enemyFallSound;
	private AudioSource audioSource;

	void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

	public void ReactToHit()
	{
		WanderingAI behavior = GetComponent<WanderingAI>();
		if (behavior != null)
		{
			behavior.SetAlive(false);
		}
		StartCoroutine(Die());
	}

	private IEnumerator Die()
	{
		float rotationSpeed = 90.0f;
		float totalRotation = 0;

		while (totalRotation < 90.0f)
		{
			float rotationStep = rotationSpeed * Time.deltaTime;
			transform.Rotate(-rotationStep, 0, 0);
			totalRotation += rotationStep;
			yield return null;
		}

		Vector3 tombstonePosition = transform.position;
		tombstonePosition.y -= .3f;
		GameObject tombstone = Instantiate(tombstonePrefab, tombstonePosition, Quaternion.identity) as GameObject;

		Vector3 particlePosition = transform.position;
		GameObject particles = Instantiate(deathParticlesPrefab, particlePosition, Quaternion.identity) as GameObject;
		Destroy(particles, 2.0f);

    audioSource.PlayOneShot(enemyFallSound);

		yield return new WaitForSeconds(1.5f);

		Destroy(this.gameObject);
	}
}
