using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText; 
    
    [System.Serializable]
    public struct DialogueLine
    {
        public string speakerName; 
        [TextArea(2, 5)]
        public string message;     
    }

    public DialogueLine[] dialogueLines; 
    private int currentLineIndex = 0;

    public string nextSceneName = "GameScene";

    void Start()
    {
        ShowLine();
    }

    void Update()
    {
            
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            currentLineIndex++;

            if (currentLineIndex < dialogueLines.Length)
            {
                ShowLine();
            }
            else
            {       
                //بيدخل عالمشهد بتاع اللعبه بقا 
                SceneManager.LoadScene(nextSceneName);
            } 
        }
    }

    void ShowLine()
    {
        if (dialogueLines.Length > 0 && currentLineIndex < dialogueLines.Length)
        {
            DialogueLine current = dialogueLines[currentLineIndex];
            // مسافة مزدوجة \n\n لفصل اسم المتكلم عن الكلام بوضوح
            dialogueText.text = "<b><color=#FFD700>" + current.speakerName + "</color></b>\n\n" + current.message;
        }
    }
}