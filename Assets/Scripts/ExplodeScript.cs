using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeScript : MonoBehaviour {

    public GameObject explosionPrefab;

    public void Explode()
    {
        GameObject explosion = (GameObject)Instantiate(explosionPrefab, transform.position, Quaternion.identity);
    }

}
