using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private GridController _gridController;

    public Canvas GameOverCanvas;
    public Text GameOverText;
    
    public bool gameOver = false;

    private BattleManager _battleManager;
    
    private void Awake()
    {
        instance = this;
    }
    
    void Start() {
        _battleManager = BattleManager.instance;
        // GameOverCanvas.enabled = false;
    }

    public void GameOver()
    {
        gameOver = true;
        GameOverText.text = _battleManager.GetActiveStack().Owner.Name + " won!";
        GameOverCanvas.gameObject.SetActive(true);
    }
}
