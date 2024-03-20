using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class KnifeTowerScript : MonoBehaviour
{
	// Start is called before the first frame update


	[SerializeField] Transform knife;
	[SerializeField] float angle;
	[SerializeField] float speed;
	[SerializeField] Vector3 _rotation;
	bool _slash;

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("EnemyZombie"))
		{
			_slash = true;

		}
	}
	public void slash()
	{
		Debug.Log("nuz");
		Quaternion target = Quaternion.Euler(0, 0, angle);
		knife.Rotate(_rotation * Time.deltaTime * speed * -1);
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("EnemyZombie"))
		{
			_slash = false;

		}
	}
	private void Update()
	{
		if (_slash)
		{
			slash();
		}
	}
}