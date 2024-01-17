using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CheckCombination : MonoBehaviour
{
    public List<GameObject> checkboxes;
    public static CheckCombination checkCombination;

    void Awake() {
        checkCombination = this;
    }

    public void doCheck() {
        if (isFirstCombination()) {
            Debug.Log("first combination");
        }
        if (isSecondCombination()) {
            Debug.Log("second combination");
        }
    }

    private bool isFirstCombination() {
        int[] mustBeChecked = new int[] {1, 5, 6};
        for (int i = 0; i < 9; i++) {
            if (mustBeChecked.Contains(i)) {
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

    private bool isSecondCombination() {
        int[] mustBeChecked = new int[] {0, 2, 4, 6, 8};
        for (int i = 0; i < 9; i++) {
            if (mustBeChecked.Contains(i)) {
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
