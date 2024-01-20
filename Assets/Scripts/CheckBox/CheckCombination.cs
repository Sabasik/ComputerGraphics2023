using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CheckCombination : MonoBehaviour
{
    public List<GameObject> checkboxes;
    public static CheckCombination checkCombination;

    public int[] combination1 = new int[] {3, 1, 8, 2, 7, 4};
    public int[] combination2 = new int[] {0, 2, 4, 6, 8};
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
            if (combination1.Contains(i)) {
                if (!checkboxes[i].GetComponent<CheckBoxController>().getCheck()) {
                    Debug.Log(i + " wrong");
                    return false;
                }
            } else {
                if (checkboxes[i].GetComponent<CheckBoxController>().getCheck()) {
                    return false;
                    Debug.Log(i + " wrong");
                }
            }
        }
        return true;
    }

    private bool isSecondCombination() {
        
        for (int i = 0; i < 9; i++) {
            if (combination2.Contains(i)) {
                if (!checkboxes[i].GetComponent<CheckBoxController>().getCheck()) {
                    return false;
                }
            } else {
                if (checkboxes[i].GetComponent<CheckBoxController>().getCheck()) {
                    return false;
                }
            }
        }
        return true;
    }

}
