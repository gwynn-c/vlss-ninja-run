using UnityEngine;

public class ThrownObjectController : MonoBehaviour
{
    [SerializeField] private float throwForce;    
    private void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(throwForce * Vector2.right, ForceMode2D.Impulse);
    }
}