using Godot;
using System;
using System.Collections.Generic;

public partial class PlayerShoot : Node2D
{
    [Export] private PackedScene bulletPrefab;

    private List<Node2D> bullets = new List<Node2D>();

    public List<Node2D> Bullets { get => bullets; set => bullets = value; }

    // Called when the node enters the scene tree for the first time.
    public static PlayerShoot instance;

    public override void _Ready()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        if (Input.IsActionPressed("shoot"))
        {

            Shoot();

        }
    }

    public void Shoot()
    {
        BulletProjectile bullet = bulletPrefab.Instantiate() as BulletProjectile;
        GetTree().Root.AddChild(bullet);

        var parent = GetParent<Sprite2D>();

        bullet.GlobalPosition = GlobalPosition;

        float offsetAngle = parent.Rotation + Mathf.DegToRad(-90f);

        bullet.Rotation = offsetAngle;

        Vector2 direction = new Vector2(Mathf.Cos(offsetAngle), Mathf.Sin(offsetAngle));

        bullet.moveDirection = direction;

        Bullets.Add(bullet);
        BulletCounter.bulletAmount = Bullets.Count;
    }

}
