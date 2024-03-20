using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkScript : MonoBehaviour
{

	[Header("Attributes")]
	[SerializeField] private Rigidbody2D rb;


	[Header("Attributes")]
	[SerializeField] private float bulletSpeed = 5f;


	private Transform target;

	// Start is called before the first frame update
	public void SetTarget(Transform _target)
	{
		target = _target;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (!target)
			return;

		Vector2 direction = (target.position - transform.position).normalized;

		rb.velocity = direction * bulletSpeed;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("EnemyZombie"))
		{
			var hittable = collision.gameObject.GetComponent<IHittable>();
			hittable.GetHit(150);
			Destroy(gameObject);
		}
	}



}