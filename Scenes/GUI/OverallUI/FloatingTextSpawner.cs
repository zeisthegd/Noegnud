using Godot;
using System;

public class FloatingTextSpawner : Node2D
{
	PackedScene messageBoxScene = (PackedScene)GD.Load("res://Scenes/GUI/OverallUI/MessageBox.tscn");

	public void ShowMessage(string message)
	{
		MessageBox messageBox = (MessageBox)messageBoxScene.Instance();
		messageBox.Message = message;
		Global.CurrentScene.AddChild(messageBox);
	}
}
