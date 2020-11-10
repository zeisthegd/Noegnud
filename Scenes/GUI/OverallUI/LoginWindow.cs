using Godot;
using System;
using Database;

public class LoginWindow : TextureRect
{
	LineEdit username, password; 
    public override void _Ready()
	{
		username = (LineEdit)GetNode("Username");
		password = (LineEdit)GetNode("Password");
        
    }
	public override void _Process(float delta)
	{
		base._Process(delta);
		if (Input.IsActionJustPressed("ui_accept"))
			Login();

		if (Input.IsActionJustPressed("ui_autoLogin"))
		{
			AutoLogin();
		}
	}

	private void _on_Login_pressed()
	{
        
        Login();
	}

    private void Login()
    {
        Global.UiSFXPlayer.PlayUIConfirm();
        AutoLoad.InitPlayerBUS();
        if (IsValidated())
        {
            
            if (CheckUser())
                AutoLoad.Global.GotoScene(Global.StartMenu);
        }
    }


	private bool CheckUser()
	{
		return AutoLoad.PlayerBUS.CheckPlayerLoginData(username.Text, password.Text);

	}
	private void _on_ToRegister_pressed()
	{
		this.Hide();
        Global.UiSFXPlayer.PlayUIConfirm();
        TextureRect registerWindow = (TextureRect)GetParent().GetNode("RegisterWindow");
		registerWindow.Show();
	}
	private bool IsValidated()
	{
		if (username.Text == "")
		{
			AutoLoad.FloatingTextSpawner.ShowMessage("Please input username!");
			return false;
		}
		else if (password.Text == "")
		{
			AutoLoad.FloatingTextSpawner.ShowMessage("Please input password!");
			return false;
		}
		return true;
	}

	private void AutoLogin()
    {
		username.Text = "phong";
		password.Text = "123";
		Login();
    }
	private void _on_Clear_pressed()
	{
        Global.UiSFXPlayer.PlayUIBack();
        username.Text = "";
		password.Text = "";
	}
	private void _on_Close_pressed()
	{
        Global.UiSFXPlayer.PlayUIBack();
        this.Hide();
	}

	
    public LineEdit Username { get => username; }
}









