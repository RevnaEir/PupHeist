using System.Collections;
using System.Collections.Generic;
using Systems.GameEvents;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC : MonoBehaviour
{
    [SerializeField] private GameEvent showInteractionText;
    [SerializeField] private GameEvent hideInteractionText;
    [SerializeField] private ImageGameEvent changeImage;
    [SerializeField] private Sprite actorSprite;
    
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    public string[] dialogue;
    private int index = 0;

    //public GameObject contButton;
    public float wordSpeed;
    public bool playerIsClose;
    
    void Start()
    {
        dialogueText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            hideInteractionText.Raise();
            if (!dialoguePanel.activeInHierarchy)
            {
                dialoguePanel.SetActive(true);
                changeImage.Raise(actorSprite);
                StartCoroutine(Typing());
            }
            else if (dialogueText.text == dialogue[index])
            {
                NextLine();
            }

        }
        if (Input.GetKeyDown(KeyCode.Q) && dialoguePanel.activeInHierarchy)
        {
            RemoveText();
        }
    }

    public void RemoveText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {
        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            RemoveText();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            showInteractionText.Raise();
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            hideInteractionText.Raise();
            playerIsClose = false;
            RemoveText();
        }
    }
}
