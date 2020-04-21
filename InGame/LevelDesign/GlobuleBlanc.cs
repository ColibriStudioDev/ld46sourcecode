using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobuleBlanc : MonoBehaviour
{
    private Vector3 direction;
    private float speed;

    public void setSpeed(float _speed)
    {
        speed = _speed;
    }

    void Start()
    {
        direction.x = Random.Range(-1f,1f);
        direction.y = Random.Range(-1f, 1f);
        direction.z = Random.Range(-1f, 1f);
    }

    
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }


    IEnumerator deathcounter()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }


}
