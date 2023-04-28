using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Manager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("Manager").GetComponent < Manager > ();
    }
}
