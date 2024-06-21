using System.Collections;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] Group1Parts;
    public GameObject[] Group2Parts;
    public GameObject[] Group3Parts;
    public GameObject[] Group4Parts;
    public GameObject[] Group5Parts;
    public GameObject[] Group6Parts;
    public GameObject[] Group7Parts;
    public GameObject[] Group8Parts;
    public GameObject[] Group9Parts;
    public GameObject[] Group10Parts;
    public GameObject[] Group11Parts;
    public GameObject[] Group12Parts;

    private int currentGroupIndex = 0;
    private int currentPartIndex = 0;
    private bool isPaused = false;
    private GameObject currentPart;
    private Transform[] currentTexts;
    private int currentTextIndex = 0;

    void Start()
    {
        HideAllTutorialTexts();
    }

    void Update()
    {
        if (isPaused && Input.GetMouseButtonDown(0))
        {
            DisplayNextText();
        }
    }

    public void StartTutorial(int groupIndex)
    {
        isPaused = true;
        Time.timeScale = 0;
        currentGroupIndex = groupIndex;
        currentPartIndex = 0;
        DisplayNextPart();
    }

    private void DisplayNextPart()
    {
        currentTextIndex = 0;
        currentPart = GetCurrentPart();

        if (currentPart != null)
        {
            currentTexts = new Transform[currentPart.transform.childCount];
            for (int i = 0; i < currentPart.transform.childCount; i++)
            {
                currentTexts[i] = currentPart.transform.GetChild(i);
                currentTexts[i].gameObject.SetActive(false);
            }
            DisplayNextText();
        }
        else
        {
            isPaused = false;
            Time.timeScale = 1;
        }
    }

    private void DisplayNextText()
    {
        if (currentTextIndex > 0 && currentTextIndex <= currentTexts.Length)
        {
            currentTexts[currentTextIndex - 1].gameObject.SetActive(false);
        }

        if (currentTextIndex < currentTexts.Length)
        {
            currentTexts[currentTextIndex].gameObject.SetActive(true);
            currentTextIndex++;
        }
        else
        {
            isPaused = false;
            Time.timeScale = 1;
        }
    }

    private GameObject GetCurrentPart()
    {
        GameObject[] currentGroup = GetGroupByIndex(currentGroupIndex);

        if (currentGroup != null && currentPartIndex < currentGroup.Length)
        {
            return currentGroup[currentPartIndex++];
        }
        return null;
    }

    private GameObject[] GetGroupByIndex(int index)
    {
        switch (index)
        {
            case 0: return Group1Parts;
            case 1: return Group2Parts;
            case 2: return Group3Parts;
            case 3: return Group4Parts;
            case 4: return Group5Parts;
            case 5: return Group6Parts;
            case 6: return Group7Parts;
            case 7: return Group8Parts;
            case 8: return Group9Parts;
            case 9: return Group10Parts;
            case 10: return Group11Parts;
            case 11: return Group12Parts;
            default: return null;
        }
    }

    private void HideAllTutorialTexts()
    {
        HideGroupTexts(Group1Parts);
        HideGroupTexts(Group2Parts);
        HideGroupTexts(Group3Parts);
        HideGroupTexts(Group4Parts);
        HideGroupTexts(Group5Parts);
        HideGroupTexts(Group6Parts);
        HideGroupTexts(Group7Parts);
        HideGroupTexts(Group8Parts);
        HideGroupTexts(Group9Parts);
        HideGroupTexts(Group10Parts);
        HideGroupTexts(Group11Parts);
        HideGroupTexts(Group12Parts);
    }

    private void HideGroupTexts(GameObject[] group)
    {
        foreach (var part in group)
        {
            foreach (Transform child in part.transform)
            {
                child.gameObject.SetActive(false);
            }
        }
    }
}