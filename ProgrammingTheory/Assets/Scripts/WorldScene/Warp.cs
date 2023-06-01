using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Warp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hero")
        {
            Debug.Log("Bing chiling");
            if (gameObject.tag == "TitleWarp")
            {
                SceneManager.LoadScene("Title", LoadSceneMode.Single);
            }
        }
    }
}
