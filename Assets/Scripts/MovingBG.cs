using UnityEngine;

public class MovingBG : MonoBehaviour
{
    void Update()
    {
        //Scrolling
        Scrolling();
        //Respawn
        if (transform.position.x <= -17.8f)
        {
            transform.position = new Vector3(18.05f, 0, 0);
        }
    }

    void Scrolling()
    {
        transform.position -= new Vector3(3f, 0, 0) * Time.deltaTime;
    }
}
