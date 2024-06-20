using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ErebeScript : MonoBehaviour, IDropHandler
{
    public List<GameObject> SoulList;
    public GameObject RespawnPos;
    public GameObject TranslateTarget;
    public FloatScriptable ErebeCooldown;
    public int tailleMaxErebe = 10;
    public TMP_Text tailleErebeText;
    public bool isErebActive = true;
    public AudioSource ErebeOut;
    private Vector3 initialTranslateTargetPos; 
    private int CurrentNumberOfList = 0;
    private bool canLaunchTimer = true;



    void Start()
    {
        initialTranslateTargetPos = TranslateTarget.transform.position; 
        tailleErebeText.text = CurrentNumberOfList + " / " + tailleMaxErebe;
    }

    void Update()
    {
        if(isErebActive == false && canLaunchTimer)
        {
            StartCoroutine(TimerErebe());
            canLaunchTimer = false;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (isErebActive)
        {
            Debug.Log("Je suis drop");
            GameObject droppedObject = eventData.pointerDrag;
            droppedObject.GetComponent<SoulDataGrab>().InErebe = true;
            StartCoroutine(AnimErebe());
            Debug.Log("Je suis récupéré");
            if (droppedObject != null && CurrentNumberOfList < tailleMaxErebe)
            {
                Debug.Log("dans le if");
                SoulList.Add(droppedObject);
                SoulList[CurrentNumberOfList].gameObject.SetActive(false);
                if(!droppedObject.gameObject.GetComponent<SoulDataGrab>().AmeData.IsBig)
                CurrentNumberOfList++;
                else
                CurrentNumberOfList += 2;
                tailleErebeText.text = CurrentNumberOfList + " / " + tailleMaxErebe;
            }
        }
    }

    public IEnumerator TimerErebe()
    {
        float timer = 0;
        while(timer <= ErebeCooldown.Value)
        {
            timer += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        canLaunchTimer = true;
        isErebActive = true;
        
        gameObject.GetComponent<Image>().color = Color.blue;
    }

    public void Ejection()
    {
        StartCoroutine(ExpulseSouls());
    }

    public IEnumerator ExpulseSouls()
    {
        for (int i = 0; i < CurrentNumberOfList; i++)
        {
            GameObject currentSoul = SoulList[i];
            currentSoul.GetComponent<CanvasGroup>().blocksRaycasts = true;

            currentSoul.gameObject.SetActive(true);
            currentSoul.GetComponent<SoulDataGrab>().InErebe = false;

            currentSoul.gameObject.transform.position = RespawnPos.transform.position;

            Vector3 targetPosition = initialTranslateTargetPos + new Vector3(-100 * i, 0, 0); // Calculer la position cible pour chaque âme

            StartCoroutine(TranslateSoul(currentSoul, targetPosition));

            Debug.Log(currentSoul + "Va en" + targetPosition);
            yield return new WaitForSeconds(0.1f);
        }
        ErebeOut.Play();
        SoulList.Clear();
        CurrentNumberOfList = 0;
        isErebActive = false;
        gameObject.GetComponent<Image>().color = Color.red;
        tailleErebeText.text = CurrentNumberOfList + " / " + tailleMaxErebe;
    }

    public IEnumerator TranslateSoul(GameObject currentSoul, Vector3 targetPosition)
    {
        while (currentSoul.gameObject.transform.position.x > targetPosition.x)
        {
            currentSoul.gameObject.transform.position += new Vector3(-1000f, 0, 0) * Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
        currentSoul.gameObject.transform.position = targetPosition;
        Debug.Log(currentSoul + "translate en" + targetPosition);
    }

    public IEnumerator AnimErebe()
    {
        GetComponent<Animator>().SetBool("PutInErebe", true);
        yield return new WaitForSeconds(2);
        GetComponent<Animator>().SetBool("PutInErebe", false);
    }
}