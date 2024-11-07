using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { FreeRoam, Dialog, Door }
public class GameController : MonoBehaviour
{
    [SerializeField] PlayerController playerController;

    GameState state;

    private void Start()
    {
        DialogManager.Instance.OnShowDialog += () =>
        {
            state = GameState.Dialog;
        };
        DialogManager.Instance.OnHideDialog += () =>
        {
            if (state == GameState.Dialog)
                state = GameState.FreeRoam;
        };
    }

    private void Update()
    {
        if (state == GameState.FreeRoam)
        {
            playerController.HandleUpdate();
        }
        else if (state == GameState.Dialog)
        {
            DialogManager.Instance.Handleupdate();
        } // qui si può mettere un altro else if come sopra e mettere un altro stato
    }

    public void SetState(GameState newState)
    {
        state = newState;
    }

}
