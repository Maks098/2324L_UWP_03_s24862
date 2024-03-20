using ScripInterfaces;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	[SerializeField] private float _speed;
	private Rigidbody2D _rb;

	private void Awake()
	{
		//Destroy(gameObject, 20);
		_rb = GetComponent<Rigidbody2D>();
	}

	private void Start()
	{
		_rb.velocity = transform.right * -_speed;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			var hittable = other.gameObject.GetComponent<IHittable>();
			hittable?.GetHit();
			Destroy(gameObject);
		}

		if (other.CompareTag("Platform")) Destroy(gameObject);
		if (other.CompareTag("MovableBox")) Destroy(gameObject);
	}
}