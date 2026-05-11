using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _animator;
    private InputAction _mJumpAction;
    
    [Header("Player Settings")] [SerializeField]
    private float jumpForce;

    [SerializeField] private Transform powerUpTransform;

    [Header("Grounded Settings")] private bool _isGrounded;
    [SerializeField] private Transform footTransform;
    [SerializeField] private float groundedRadius;
    [SerializeField] private LayerMask groundLayer;



    [Space(10)] [Header("Audio Clips")] [SerializeField]
    private AudioClip playerHit;

    [SerializeField] private AudioClip coinCollected;


    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        _mJumpAction = InputSystem.actions.FindAction("Jump");
    }

    void Start()
    {
        _animator.CrossFade("StartAnimation", 1f);
    }

    void Update()
    {
        if (GameManager.Instance.isGameOver || !GameManager.Instance.isGameStarted)
        {
            return;
        }

        
        if (_mJumpAction.WasPressedThisFrame() && _isGrounded)
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        if (GameManager.Instance.isGameOver || !GameManager.Instance.isGameStarted)
        {
            return;
        }
        _isGrounded = IsGrounded();
    }

    private void Jump()
    {
        _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        _animator.CrossFade("Jump", 0.1f);
    }

    private bool IsGrounded() => Physics2D.OverlapCircle(footTransform.position, groundedRadius, groundLayer);



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            SoundFXManager.Instance.PlaySoundFX(coinCollected);
            EventManager.Instance.gameEvents.CoinCollected();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Enemy"))
        {
            _animator.CrossFade("Player hit", 0.1f);
            SoundFXManager.Instance.PlaySoundFX(playerHit);
            GameManager.Instance.GameOver();
            Destroy(gameObject, 1f);
        }
        else if (other.CompareTag("Power-Up"))
        {
             var p =  other.GetComponent<PickUpController>().PowerUp();
             var t = Instantiate(p.powerUpPrefab, powerUpTransform.position, Quaternion.identity);
             t.transform.SetParent(transform);
             other.gameObject.SetActive(false);
        }
    }
}