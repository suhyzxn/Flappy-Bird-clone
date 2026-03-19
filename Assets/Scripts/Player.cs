using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float jumpForce;
    Rigidbody2D rigid;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pillar"))
        {
            rigid.AddForce(new Vector2(-5, 5), ForceMode2D.Impulse);
            transform.Rotate(0, 0, 150);
        }
        GameManager.instance.Die();
    }
}
