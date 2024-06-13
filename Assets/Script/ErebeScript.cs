using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ErebeScript : MonoBehaviour, IDropHandler
{
    public List<GameObject> SoulList;

    public GameObject RespawnPos;

    private int CurrentNumberOfList = 0;

    public GameObject TranslateTarget;


    public FloatScriptable ErebeCooldown;

    private Vector3 initialTranslateTargetPos; // Nouvelle variable pour stocker la position initiale

    private bool isErebActive = true;
    private bool canLaunchTimer = true;

    void Start()
    {
        initialTranslateTargetPos = TranslateTarget.transform.position; // Initialisation de la position initiale
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
            Debug.Log("Je suis récupéré");
            if (droppedObject != null)
            {
                Debug.Log("dans le if");
                SoulList.Add(droppedObject);
                SoulList[CurrentNumberOfList].gameObject.SetActive(false);
                CurrentNumberOfList++;
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

            currentSoul.gameObject.transform.position = RespawnPos.transform.position;

            Vector3 targetPosition = initialTranslateTargetPos + new Vector3(-100 * i, 0, 0); // Calculer la position cible pour chaque âme

            StartCoroutine(TranslateSoul(currentSoul, targetPosition));

            Debug.Log(currentSoul + "Va en" + targetPosition);
            yield return new WaitForSeconds(0.1f);
        }

        SoulList.Clear();
        CurrentNumberOfList = 0;
        isErebActive = false;
        gameObject.GetComponent<Image>().color = Color.red;
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
}