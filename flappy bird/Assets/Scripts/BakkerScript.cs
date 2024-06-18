using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class BakkerScript : MonoBehaviour
{
    public GameObject Friekandelbroodje;
    public float SpawnRate = 2;
    private float timer = 0;
    public float heightoffset = 10;
    // Start is called before the first frame update
    void Start()
    {
        SpawnFriekandelbroodje();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < SpawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            SpawnFriekandelbroodje();
            timer = 0;
        }
    }
    void SpawnFriekandelbroodje()
    {
        float lowestpoint = transform.position.y - heightoffset;
        float highestpoint = transform.position.y + heightoffset;

        Instantiate(Friekandelbroodje, new Vector3(transform.position.x, Random.Range(lowestpoint, highestpoint), 0), transform.rotation);
    }
}
