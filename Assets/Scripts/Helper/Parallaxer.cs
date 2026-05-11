using UnityEngine;

public class Parallaxer : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField] private GameObject background;
    [SerializeField] private float offset;
    [SerializeField]  float animationSpeed = 1f;
    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.isGameOver || !GameManager.Instance.isGameStarted)
        {
            return;
        }
        if (transform.position.x < mainCamera.transform.position.x - offset)
        {
            transform.position = new Vector3(transform.position.x + offset * 2, transform.position.y, transform.position.z);
        }

        transform.Translate(-animationSpeed * Time.deltaTime , 0, 0);
    }
}