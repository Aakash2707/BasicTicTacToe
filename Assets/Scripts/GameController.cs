using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Player
{
    public Image panel;
    public Text text;
    public Button button;

}
[System.Serializable]
public class PlayerColor
{
    public Color panelColor;
    public Color textColor;

}
public class GameController : MonoBehaviour
{
    public Text[] buttonList; // creating an array 

    public GameObject gameOverPanel;
    public Text gameOverText;
    public GameObject restartButton;
    public Player playerX;
    public Player playerO;
    public PlayerColor activePlayerColor;
    public PlayerColor inactivePlayerColor;
    public GameObject startInfo;

    private int moveCount;
    
    private string playerSide;
    public string computerSide;
    public bool playerMove;
    public float delay;
    private int value;


    void Awake()
    {
        gameOverPanel.SetActive(false);
        SetGameControllerReferenceOnButtons();
        moveCount = 0;
        restartButton.SetActive(false);
        playerMove = true;

    }

    void Update()
    {
        if(playerMove == false)
        {
            delay += delay * Time.deltaTime;
            if(delay >= 100)
            {
                value= Random.Range(0,8);
                if(buttonList[value].GetComponentInParent<Button>().interactable == true)
                {
                    buttonList[value].text = GetComputerSide();
                    buttonList[value].GetComponentInParent<Button>().interactable = false;
                    EndTurn();
                }
            }
        }
    }

    void SetGameControllerReferenceOnButtons()
    {
        for (int i= 0; i< buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }

    public void SetStartingSide(string startingSide){
        playerSide = startingSide;
        if(playerSide == "X")
        {
            computerSide ="O";
            SetPlayerColors(playerX,playerO);
        }
        else if(playerSide == "O")
        {
            computerSide = "X";
            SetPlayerColors(playerO,playerX);
        }

        StartGame();
    }

    void StartGame()
    {
        SetGameBoardInteractable(true);
        SetGameButtons(false);
        startInfo.SetActive(false);
    }
    public string GetPlayerSide()
    {
        return playerSide;    
    } 
    public string GetComputerSide(){
        return computerSide;
    }
    public void EndTurn()
    {
        moveCount ++;
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        if(buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide )
        {
            GameOver(playerSide);
        }
        else if(buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide )
        {
            GameOver(playerSide);
        }
        else if(buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide )
        {
            GameOver(playerSide);
        }

        else if(buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide )
        {
            GameOver(playerSide);
        }
        else if(buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide )
        {
            GameOver(playerSide);
        }
        else if(buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide )
        {
            GameOver(playerSide);
        }

        else if(buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide )
        {
            GameOver(playerSide);
        }
        else if(buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide )
        {
            GameOver(playerSide);
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        else if(buttonList[0].text == computerSide && buttonList[1].text == computerSide && buttonList[2].text == computerSide )
        {
            GameOver(computerSide);
        }
        else if(buttonList[3].text == computerSide && buttonList[4].text == computerSide && buttonList[5].text == computerSide )
        {
            GameOver(computerSide);
        }
        else if(buttonList[6].text == computerSide && buttonList[7].text == computerSide && buttonList[8].text == computerSide )
        {
            GameOver(computerSide);
        }

        else if(buttonList[0].text == computerSide && buttonList[3].text == computerSide && buttonList[6].text == computerSide )
        {
            GameOver(computerSide);
        }
        else if(buttonList[1].text == computerSide && buttonList[4].text == computerSide && buttonList[7].text == computerSide )
        {
            GameOver(computerSide);
        }
        else if(buttonList[2].text == computerSide && buttonList[5].text == computerSide && buttonList[8].text == computerSide )
        {
            GameOver(computerSide);
        }

        else if(buttonList[0].text == computerSide && buttonList[4].text == computerSide && buttonList[8].text == computerSide )
        {
            GameOver(computerSide);
        }
        else if(buttonList[2].text == computerSide && buttonList[4].text == computerSide && buttonList[6].text == computerSide )
        {
            GameOver(computerSide);
        }

        else if(moveCount >= 9){
            
            GameOver("draw");
        }
        else 
        {
            ChangeSides();
            delay = 10;
            
        }
    }

    void SetPlayerColors(Player newPlayer, Player oldPlayer)
    {
        newPlayer.panel.color = activePlayerColor.panelColor;
        newPlayer.panel.color = activePlayerColor.textColor;
        oldPlayer.panel.color = inactivePlayerColor.panelColor;
        oldPlayer.panel.color = inactivePlayerColor.panelColor;

    }
    void GameOver(string winningPlayer)
    {
        SetGameBoardInteractable(false);
        if(winningPlayer == "draw")
        {
            SetGameOverText("Its a Draw!");
            SetPlayerColorInactive();
        }
        else
        {
            SetGameOverText(winningPlayer + " Wins!");
        }
        restartButton.SetActive(true);
    }
    
    void ChangeSides()
    {
        //playerSide = (playerSide =="X") ? "O" : "X" ;

        if(playerMove == true)
        {
            playerMove = false;
            if(playerSide == "X")
            {
                computerSide ="O";

                SetPlayerColors(playerO,playerX);
            }
            else if(playerSide == "O")
            {
                computerSide = "X";
                SetPlayerColors(playerX,playerO);
            }
            
           
        }

        else if(playerMove == false)
        {
            playerMove = true;
            if(playerSide == "X")
            {
                computerSide ="O";
                SetPlayerColors(playerX,playerO);
                
                
            }
            else if(playerSide == "O")
            {
                computerSide = "X";
                SetPlayerColors(playerO,playerX);             
            }
        }
    }

    void SetGameOverText(string value)
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = value;
    
    }

    public void RestartGame()
    {     
        moveCount = 0;
        gameOverPanel.SetActive(false);
        restartButton.SetActive(false);
        SetGameButtons(true); 
        SetPlayerColorInactive();
        startInfo.SetActive(true); 
        playerMove =true;
        delay= 10;
        for(int i= 0 ; i< buttonList.Length; i++)
        {
            buttonList[i].text = "";
        }

    }

    void SetGameBoardInteractable(bool toggle){
        for(int i= 0 ; i< buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = toggle;
        }
    }

    void SetGameButtons(bool toggle){
        playerX.button.interactable = toggle;
        playerO.button.interactable = toggle;

    }

    void SetPlayerColorInactive(){
        playerX.panel.color = inactivePlayerColor.panelColor;
        playerX.text.color = inactivePlayerColor.textColor;
        playerO.panel.color = inactivePlayerColor.panelColor;
        playerO.text.color = inactivePlayerColor.textColor;

    }
    
}
