using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Manager manager;
    void Start()
    {
        manager = GameObject.Find("Manager").GetComponent<Manager>();
    }
}
