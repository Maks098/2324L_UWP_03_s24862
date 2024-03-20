using System.Collections;
using UnityEngine;

namespace Totems.Totem1
{
    public class Totem1 : MonoBehaviour
    {
        [SerializeField] private GameObject _projectilePrefab;
        [SerializeField] private float _cooldown;
        [SerializeField] private Transform _firingPoint;
        private Animator _animator;
        private bool _canShoot = true;
        private bool _startShooting;


        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (_canShoot && _startShooting)
            {
                var transform1 = _firingPoint.transform;
                Instantiate(_projectilePrefab, transform1.position, transform1.rotation);
                StartCoroutine(nameof(SpawnCooldown));
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _animator.SetBool("attackPlayer", true);
                _startShooting = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _animator.SetBool("attackPlayer", false);
                _startShooting = false;
            }
        }

        private IEnumerator SpawnCooldown()
        {
            _canShoot = false;
            yield return new WaitForSeconds(_cooldown);
            _canShoot = true;
        }
    }
}