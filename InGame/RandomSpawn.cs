using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject[] spawnObject;
    public bool isDropping = false;
    public Transform centrePos;
    private Vector3 spawn;
    private GameObject instantiatedObj;
    private Rigidbody2D rb;
    
    [SerializeField]
    private float hauteur, largeur, MinVitesseX, MaxVitesseX, MinVitesseY, MaxVitesseY;
    private float RandomHauteur, RandomLargeur, vitesseX, vitesseY;
    
    [Range(0f, 25f)]
    public float frequence;
    
    [SerializeField]
    private float lifeTime, deathPosition;
    

    private int randomObject;

    void Awake()
    {
        hauteur/=2;
        largeur/=2;
        spawn=centrePos.position;
    }

    // Update is called once per frame
    void Update () 
    {
        if (isDropping == false) return;
        spawn=centrePos.position;

        RandomHauteur=Random.Range(-hauteur, hauteur);
        RandomLargeur=Random.Range(-largeur, largeur);

        spawn.y+=RandomHauteur;
        spawn.x+=RandomLargeur;

        float RandomSpawn=Random.Range(0, 1000);
		if(RandomSpawn<frequence) 
        {
			SpawnRandom();
		}
        
	}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(centrePos.position, new Vector3(largeur, hauteur, 0));
    }


    void SpawnRandom() 
    {
		randomObject = Random.Range(0, spawnObject.Length);
		instantiatedObj = Instantiate(spawnObject[randomObject], spawn, spawnObject[randomObject].transform.rotation);
        instantiatedObj.AddComponent<Rigidbody2D>();


        vitesseX=Random.Range(MinVitesseX, MaxVitesseX);
        vitesseY=Random.Range(MinVitesseY, MaxVitesseY);

        rb = instantiatedObj.GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        rb.gravityScale = 0;
        rb.velocity+= new Vector2(rb.velocity.x + vitesseX,rb.velocity.y+vitesseY);
        
        if(lifeTime>0)
        {
            Destroy(instantiatedObj, lifeTime); 
        }
        if(instantiatedObj.transform.position.y <= deathPosition) {
			Destroy(instantiatedObj);
		}
        
	}
}
