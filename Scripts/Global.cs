using Godot;
using System;

//Class này được sử dụng để chuyển đổi các Scene, thay đổi màn chơi
public class Global : Node
{
    static string playerName = "Player";
    
    public override void _Ready()
    {
        Viewport root = GetTree().Root;
        CurrentScene = root.GetChild(root.GetChildCount() - 1);
    }

    public void GotoScene(string path)
    {
        CallDeferred(nameof(DeferredGotoScene), path);
    }

    public void ReloadScene(Node scene)
    {
        scene.GetTree().ReloadCurrentScene();
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
        Global.CurrentScene.AddChild(newMonster);
        newMonster.GlobalPosition = position;
        GD.Print("Spawn");
    }

    public static Player GetPlayer()
    {
        return (Player)CurrentScene.GetNode("MainSort").GetNode(playerName);

    }

    public static Node CurrentScene { get; set; }//Scene hiện tại, VD:Stage1


}