using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _speed;
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        if (GameManager.Instance.isGameOver)
        {
            return;
        }
        _rigidbody2D.AddForce(Vector2.left * (_speed * Time.fixedDeltaTime), ForceMode2D.Force);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Weapon"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}