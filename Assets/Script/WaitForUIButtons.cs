using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaitForUIButtons : CustomYieldInstruction
{
    private Button button;
    private bool isPressed = false;

    public WaitForUIButtons(Button button)
    {
        this.button = button;
        this.button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        isPressed = true;
    }

    public override bool keepWaiting
    {
        get { return !isPressed; }
    }

    public IEnumerator Reset()
    {
        isPressed = false;
        yield return null;
    }
}