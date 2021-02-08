using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

    public PlayerSwitch playerScript;

    void Update () 
    {
        transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            other.gameObject.SetActive(false);
            playerScript.scoreCount = playerScript.scoreCount + 1;
            playerScript.SetCountText();
            this.gameObject.SetActive(false);
        }
    }

    
}
