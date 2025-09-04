using System.Collections;
using UnityEngine;

public class WeaponShoot : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Bullet _prefab;
    [SerializeField] private float _waitingTime = 1f;

    private Transform _currentTarget;
    private Coroutine _currentCoroutine;
    private WaitForSeconds _waitForSeconds;

    public Transform Target => _currentTarget;

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(_waitingTime);

        if (_currentCoroutine == null)
        {
            StopCoroutine(Shooting());
        }

        _currentCoroutine = StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
        bool isWork = true;

        while (isWork)
        {
            Vector3 direction = (_currentTarget.position - transform.position).normalized;
            Bullet currentBullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);
            currentBullet.Initialize(direction,_speed);

            yield return _waitForSeconds;
        }
    }  
}