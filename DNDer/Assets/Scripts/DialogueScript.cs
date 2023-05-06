using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueScript : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public float typingSpeed = 0.1f;
    public float displayTime = 3f;

    //bubble SFX
    public AudioSource audioSource;
    public AudioClip popSound;

    private string fullText;
    private string currentText = "";

    public void Show(string text)
    {
        gameObject.SetActive(true);
        fullText = text;
        currentText = "";
        dialogueText.text = "";
        StartCoroutine(TypeText());
        audioSource.PlayOneShot(popSound);
    }

    IEnumerator TypeText()
    {
        foreach (char c in fullText)
        {
            currentText += c;
            dialogueText.text = currentText;
            yield return new WaitForSeconds(typingSpeed);
        }

        yield return new WaitForSeconds(displayTime);

        gameObject.SetActive(false);
    }
}
