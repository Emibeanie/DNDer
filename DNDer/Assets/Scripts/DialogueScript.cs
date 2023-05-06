using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueScript : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public float typingSpeed = 0.1f;
    public float displayTime = 3f;

    private string fullText;
    private string currentText = "";

    public void Show(string text)
    {
        gameObject.SetActive(true);
        fullText = text;
        currentText = "";
        dialogueText.text = "";
        StartCoroutine(TypeText());
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
