using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_Dialogue : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogue;
    private int index;

    public float wordSpeed;
    public bool playerIsClose;

    public GameObject cButton;

    public GameObject DialogueSreen;

    public GameObject PressE;
    

    void Start()
    {
        PressE.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogueText.text == dialogue[index])
        {
            cButton.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            
            if(dialoguePanel.activeInHierarchy)
            {
                
                zeroText();
            }else
            {
                DialogueSreen.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }
    
        
    }



    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        DialogueSreen.SetActive(false);
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
        cButton.SetActive(false);

        if(index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }else
        {
            zeroText();
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            PressE.SetActive(true);
            playerIsClose = true;
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        PressE.SetActive(false);

        if(other.CompareTag("Player"))
        {
            
            playerIsClose = false;
            zeroText();
        }
    }
}
