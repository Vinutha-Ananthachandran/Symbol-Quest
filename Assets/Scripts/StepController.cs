using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StepController : MonoBehaviour
{
    private Text textComponent;
    // Start is called before the first frame update
    void Start()
    {
        // Get the Text component attached to the same GameObject.
        textComponent = GetComponentInChildren<Text>();

        // Check if the Text component was found.
        //if (textComponent == null)
        //{
        //    Debug.LogError("Text component not found on this GameObject.");
        //}
        //else
        //{
            // You can now manipulate the text property of the Text component.
        //    textComponent.text = "Hello, wassup!";
        //    Debug.Log("hello");
        //}
    }

    public Text get_text_component()
    {
        return this.textComponent;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
