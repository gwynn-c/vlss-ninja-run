using UnityEngine;

public class PickUpController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private PowerUpSO _powerUp;
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

    public PowerUpSO PowerUp()
    {
        return _powerUp;
    }
}