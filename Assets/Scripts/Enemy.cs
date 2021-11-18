using UnityEngine;

public class Enemy : MonoBehaviour
{
    private const float Lifespan = 10f;

    [SerializeField, Min(0.1f)] private float _movementSpeed = 1f;

    private void Start()
    {
        Destroy(gameObject, Lifespan);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * _movementSpeed * Time.deltaTime);
    }
}