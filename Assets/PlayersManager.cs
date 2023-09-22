using UnityEngine;

public class PlayersManager : MonoBehaviour
{
    public static PlayersManager instance;
    
    public string leftPlayerName;
    public string rightPlayerName;
    public Material leftPlayerMaterial;
    public Material rightPlayerMaterial;

    private Player leftPlayer;
    private Player rightPlayer;

    private void Awake()
    {
        instance = this;
        
        leftPlayer = new Player(leftPlayerName, leftPlayerMaterial);
        rightPlayer = new Player(rightPlayerName, rightPlayerMaterial);
    }

    public Player GetLeftPlayer()
    {
        return leftPlayer;
    }
    
    public Player GetRightPlayer()
    {
        return rightPlayer;
    }

    public Player GetOtherPlayer(Player player)
    {
        return player == leftPlayer ? rightPlayer : leftPlayer;
    }
}
