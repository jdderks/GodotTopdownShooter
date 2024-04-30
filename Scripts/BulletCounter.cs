using Godot;
using System;

public partial class BulletCounter : Label
{
    public static int bulletAmount = 0;

    public override void _Process(double delta)
    {
        Text = bulletAmount.ToString();
    }
}
