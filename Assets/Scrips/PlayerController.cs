using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 0f;
    [SerializeField] private Animator animator;
    private int numberOfJumps;
    private SpriteRenderer colorPlayer;
    public int numberOfLives;
    [SerializeField] private InGameView gameView;
    [SerializeField] private GameObject _gameOver;
    public int Level;
    private void Start()
    {
        colorPlayer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        var SaveData = SavesService.Instance.Load<SaveData>();
        numberOfJumps = SaveData.JumpCount;

        numberOfLives = 3;
        Time.timeScale = 1f;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && numberOfJumps != 0)
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            animator.SetBool("Jump", true);
            numberOfJumps--;
        }
        if (numberOfLives == 0)
        {
            _gameOver.SetActive(true);
            Time.timeScale = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            var SaveData = SavesService.Instance.Load<SaveData>();
            numberOfJumps = SaveData.JumpCount;
            animator.SetBool("Jump", false);
        }
        if(collision.gameObject.tag == "Enemy")
        {
            colorPlayer.color = Color.red;
            numberOfLives--;
            StartCoroutine(ColorDamage());
            gameView.HealchBarController(numberOfLives);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Coint")
        {
            gameView.CointBar();
            Destroy(collision.gameObject);
        }
    }
    IEnumerator ColorDamage ()
    {
        yield return new WaitForSeconds(0.5f);
        colorPlayer.color = Color.white;
    }
}
