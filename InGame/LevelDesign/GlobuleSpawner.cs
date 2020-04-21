using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GlobuleSpawner : MonoBehaviour
{
    [SerializeField]
    private float speedRange, frequence, zSpawn;
    [SerializeField]
    private GameObject globule;

    

    private BoxCollider2D collider;
    Vector2 border;
    Vector2 go;

    private void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        border = Vector2.zero;
        go = transform.position;
        border.x = collider.size.x / 2;
        border.y = collider.size.y / 2;
        StartCoroutine(startSpawn());
        
    }





    IEnumerator startSpawn()
    {
        GameObject obj = Instantiate(globule, transform);
        Vector2 addpos = new Vector2(Random.Range(-border.x, border.x), Random.Range(-border.y, border.y));

        obj.transform.position = go + addpos;
        obj.GetComponent<GlobuleBlanc>().setSpeed(Random.Range(-speedRange, speedRange));

        Vector3 totalpos = obj.transform.position;
        totalpos.z = zSpawn;
        obj.transform.position = totalpos;


        yield return new WaitForSeconds(frequence);
        StartCoroutine(startSpawn());
    }
}
