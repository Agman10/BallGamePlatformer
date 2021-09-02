using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerInput : MonoBehaviour
{
    public Vector3 moveInput;

    public Vector3 rollInput;
    public bool is2D = false;

    public void OnMoveInput(InputAction.CallbackContext ctx)
    {
        Vector2 inputValue = ctx.ReadValue<Vector2>();
        if (is2D)
        {
            moveInput = new Vector3(inputValue.x, 0, 0);

            rollInput = new Vector3(0, 0, -inputValue.x);
        } else
        {
            moveInput = new Vector3(inputValue.x, 0, inputValue.y);

            rollInput = new Vector3(inputValue.y, 0, -inputValue.x);
        }
        
    }

    public void OnResetSaveInput(InputAction.CallbackContext ctx)
    {
        /*PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("PlayerLives", 10);*/
        Debug.Log("Delete save shortcut is disabled for now");
    }

    public void OnQuitInput(InputAction.CallbackContext ctx)
    {
        //Application.Quit();
        SceneManager.LoadScene(0);
    }
}
