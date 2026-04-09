using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var playerRigid = collision.GetComponent<Rigidbody2D>();
            if (playerRigid.bodyType == RigidbodyType2D.Kinematic)
                return;
            else
                GameManager.instance.ScoreUp();
        }
    }
}
