using Godot;
using System;

//Class này được sử dụng để chuyển đổi các Scene, thay đổi màn chơi
public class Global : Node
{
    static AutoLoad autoLoad;
    static PlayerStats playerStats;
    static string playerName = "Player";
    static MainMusicPlayer mainMusicPlayer;
    static UISFX uiSFXPlayer;

    public override void _Ready()
    {
        Viewport root = GetTree().Root;
        CurrentScene = root.GetChild(root.GetChildCount() - 1);

        autoLoad = (AutoLoad)GetTree().Root.GetNode("AutoLoad");
        playerStats = (PlayerStats)GetTree().Root.GetNode("PlayerStats"); 
        uiSFXPlayer = (UISFX)GetTree().Root.GetNode("Uisfx");
        mainMusicPlayer = (MainMusicPlayer)GetTree().Root.GetNode("MainMusicPlayer");
    }

    public void GotoScene(string path)
    {
        CallDeferred(nameof(DeferredGotoScene), path);
    }

    public void ReloadScene(Node scene)
    {
        GotoScene("res://Scenes/Stage1/Stage1.tscn");
    }

    public void DeferredGotoScene(string path)
    {
        CurrentScene.Free();
        var nextScene = (PackedScene)GD.Load(path);
        CurrentScene = nextScene.Instance();
        GetTree().Root.AddChild(CurrentScene);
        GetTree().CurrentScene = CurrentScene;
    }



    public static void SpawnMonster(PackedScene scene, Vector2 position)
    {
        Monster newMonster = (Monster)scene.Instance();
        Global.CurrentScene.GetNode("MainSort").AddChild(newMonster);
        newMonster.GlobalPosition = position;
    }

    public static Control GetMainUI()
    {
        return (Control)CurrentScene.GetNode("CanvasLayer").GetNode("GUI");
    }

    public static Player GetPlayer()
    {
        return (Player)CurrentScene.GetNode("MainSort").GetNode(playerName);
    }

    public static Node CurrentScene { get; set; }
    public static String StartMenu { get { return "res://Scenes/GUI/OverallUI/StartMenu.tscn"; } }
    public static String Ranking { get { return "res://Scenes/GUI/OverallUI/Ranking.tscn"; } }
    public static String Game { get { return "res://Scenes/Stage1/Stage1.tscn"; } }
    public static String Option { get { return "res://Scenes/GUI/OverallUI/Option.tscn"; } }
    public static String LoginScreen { get { return "res://Scenes/GUI/OverallUI/LoginScreen.tscn"; } }
    public static MainMusicPlayer MainMusicPlayer { get => mainMusicPlayer;}
    public static UISFX UiSFXPlayer { get => uiSFXPlayer;}
    public static PlayerStats PlayerStats { get => playerStats;}
    public static AutoLoad AutoLoad { get => autoLoad;}
}