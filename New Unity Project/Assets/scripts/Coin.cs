using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Vector3 rotation;
    public TextAlignment ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        rotation = new Vector3(0, 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotation);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("123456");
            Destroy(this.gameObject);
            
        }
    }
}
