using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class heroAttackButton : ButtonManager
{
    public void TaskOnClick()
    {
        manager.HeroAttack();
    }
}
