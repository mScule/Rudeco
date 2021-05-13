using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PoyLang;

public class Rudeco : MonoBehaviour
{
    Poy console;
    Dictionary<string, CustomCommand> customCommands;

    bool backgroundProcess = false;

    [Header("PlayerMovement")]
    [SerializeField] PlayerMovement playerMovement;

    [Header("Header")]
    [SerializeField] Text header;

    [Header("Input & Output")]
    [SerializeField] InputField input;
    [SerializeField] OutputViewer output;

    [Header("Window")]
    [SerializeField] Image background;
    [SerializeField] GameObject consoleWindow;

    [Tooltip("Here you can link every custom command script in the scene that the player can use through the console.")]
    [Header("CustomCommandInterface")]

    public CustomCommand[] commands;

    void CustomCommandInit()
    {
        foreach(CustomCommand command in commands)
            customCommands.Add(command.key, command);
    }

    private void Start()
    {
        // Initializing console
        customCommands = new Dictionary<string, CustomCommand>();
        CustomCommandInit();

        console = new Poy(customCommands);
        output.Print( 
            console.GetOutputOut() + "To clear screen, write: $R@cls$W; \n");
    }

    // Console header buttons
    public void ClearInput()
    {
        input.Select();
        input.text = "";
    }

    public void Interprete()
    {
        if (!backgroundProcess)
        {
            console.Interprete(input.text);
            output.Print(console.GetOutputOut() + '\n');
        }
    }

    public void SetBackgroundProcess()
    {
        if (backgroundProcess)
        {
            backgroundProcess = false;
            input.readOnly = false;
            input.textComponent.color = Color.white;
            header.text = "F1 exit ~ F2 clear inputfield ~ F5 run code ~ F10 set background process";
        }
        else
        {
            backgroundProcess = true;
            input.readOnly = true;
            input.textComponent.color = Color.grey;
            header.text = "F1 exit ~ F2 clear inputfield ~ F5 LOCKED ~ F10 end background process";
        }
    }

    private void Update() // F1 open/close console | F2 clear inputfield | F5 run code | F10 set background process
    {
        if (backgroundProcess)
        {
            console.Interprete(input.text);
            output.Print(console.GetOutputOut() + '\n');
        }

        if (consoleWindow.activeSelf
        && Input.GetKeyDown(KeyCode.F5))
            Interprete();

        if (!console.IsOutputInNull())
            input.text += console.GetOutputIn();

        if (Input.GetKeyDown(KeyCode.F1))
        {
            switch (consoleWindow.activeSelf)
            {
                case false:
                    consoleWindow.SetActive(true);
                    background.enabled = true;
                    playerMovement.Enable(false);
                    break;

                case true:
                    consoleWindow.SetActive(false);
                    background.enabled = false;
                    playerMovement.Enable(true);
                    break;
            }
        }

        if (consoleWindow.activeSelf
            && Input.GetKeyDown(KeyCode.F2))
            ClearInput();

        if (consoleWindow.activeSelf
            && Input.GetKeyDown(KeyCode.F10))
            SetBackgroundProcess();
    }
}
