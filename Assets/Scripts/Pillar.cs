using UnityEngine;

public class Pillar : MonoBehaviour
{
    void Update()
    {
        //Scrolling
        transform.position -= new Vector3(3f, 0, 0) * Time.deltaTime;
        //Destroy
        if (transform.position.x <= -17.8f)
            Destroy(gameObject);
    }
}
