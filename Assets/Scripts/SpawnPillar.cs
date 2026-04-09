using System.Collections;
using UnityEngine;

public class SpawnPillar : MonoBehaviour
{
    public GameObject prefab;
    float lastHeight;
    float height;
    public float delay = 2f;
    int currentScore;
    void Start()
    {
        //Spawn
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            height = GetRandomHeight();

            Instantiate(prefab, new Vector3(3, height, 0), Quaternion.identity);
            if (GameManager.instance.score % 10 == 0 && GameManager.instance.score != currentScore)
            {
                if (GameManager.instance.score > 0 && GameManager.instance.score <= 50)
                    delay -= 0.2f;
                currentScore = GameManager.instance.score;
            }
            yield return new WaitForSeconds(delay);
        }
    }

    float GetRandomHeight()
    {
        float height;

        do
        {
            height = Random.Range(-3.14f, 1.96f);
        } while (Mathf.Abs(lastHeight - height) < 1f); //이전 높이와의 최소 차이

        lastHeight = height; //마지막 높이 저장
        
        return height;
    }
}
