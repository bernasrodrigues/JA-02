using UnityEngine;

public class Data {
    
    public enum GameState { MainMenu, InGame, InPauseMenu }
    public static GameState gameState = GameState.MainMenu;

}