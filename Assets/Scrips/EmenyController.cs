using UnityEngine;

public class EmenyController : MonoBehaviour
{
    [SerializeField] private float speed = -0.01f;

    private void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);

        if (transform.position.x < -20)
        {
            Destroy(gameObject);
        }
    }
}
