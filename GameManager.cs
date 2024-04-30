using Godot;
using System;

public partial class GameManager : Node2D
{

    [Export] private PlayerMove _playerMove;
    private PlayerShoot _playerShoot;

    public static GameManager instance;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {

        if (instance == null)
        {
            instance = this;
        }
        _playerShoot = PlayerShoot.instance;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        //if input escape is pressed
        if (Input.IsKeyPressed(Key.Escape))
        {
            GameOver();
        }
    }


    public void GameOver()
    {
        for (int i = 0; i < _playerShoot.Bullets.Count; i++)
        {
            _playerShoot.Bullets[i].QueueFree();
        }
        _playerShoot.Bullets.Clear();
        BulletCounter.bulletAmount = 0;
    }
}
