using System.Collections;
using UnityEngine;

public class SpawnPillar : MonoBehaviour
{
    public GameObject prefab;
    float lastHeight;
    float height;
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
            yield return new WaitForSeconds(2f);
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
