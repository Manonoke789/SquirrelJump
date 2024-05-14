using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
       _spriteRenderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
    }
}
