using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyData data;
    public static event Action<EnemyData> OnEnemyReachedEnd;
    public static event Action<Enemy> OnEnemyDestroyed; 
    
    private Path _currentPath;
    
    private Vector3 _targetPosition;
    private int _currentWayPoint;
    private float _lives;

    private void Awake()
    {
        _currentPath = GameObject.Find("Path1").GetComponent<Path>();
    }

    private void OnEnable()
    {
        _currentWayPoint = 0;
        _targetPosition = _currentPath.GetPosition(_currentWayPoint);
        _lives = data.lives;
    }

    private void Update()
    {
        // move towards target position
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, data.speed * Time.deltaTime);
        
        // when target reached, set new target position
        float relativeDistance = (transform.position - _targetPosition).magnitude;
        if (relativeDistance < 0.1f)
        {
            if (_currentWayPoint < _currentPath.Waypoints.Length - 1)
            {
                _currentWayPoint++;
                _targetPosition = _currentPath.GetPosition(_currentWayPoint);
            }
            else
            {
                OnEnemyReachedEnd?.Invoke(data);
                gameObject.SetActive(false);
            }
        }
    }

    public void TakeDamage(float damage)
    {
        _lives -= damage;
        _lives = Math.Max(_lives, 0);

        if (_lives <= 0)
        {
            OnEnemyDestroyed?.Invoke(this);
            gameObject.SetActive(false);
        }
    }
}
