using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class CheckCombination : MonoBehaviour
{
    public List<GameObject> checkboxes;
    public static CheckCombination checkCombination;

    public int[] combination1;
    public int[] combination2;
    public Activatable activatable1;
    public Activatable activatable2;

    void Awake() {
        checkCombination = this;
    }

    public void doCheck() {
        if (isFirstCombination()) {
            Debug.Log("first combination");
            if (activatable1 != null)
            {
                activatable1.Activate();
            }
        }
        if (isSecondCombination()) {
            Debug.Log("second combination");
            if (activatable2 != null)
            {
                activatable2.Activate();
            }
        }
    }

    private bool isFirstCombination() {
        
        for (int i = 0; i < 9; i++) {
            bool shouldBeChecked = combination1.Contains(i+1);
            if (checkboxes[i].GetComponent<CheckBoxController>().getCheck() != shouldBeChecked)
            {
                Debug.Log("combination 1: " + i + " wrong");
                return false;
            }
        }
        return true;
    }

    private bool isSecondCombination() {
        
        for (int i = 0; i < 9; i++) {
            bool shouldBeChecked = combination2.Contains(i+1);
            if (checkboxes[i].GetComponent<CheckBoxController>().getCheck() != shouldBeChecked)
            {
                Debug.Log("combination 2: " + i + " wrong");
                return false;
            }
        }
        return true;
    }

}
