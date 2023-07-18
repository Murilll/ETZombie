using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

public class Zombie
{
    FlowLayoutPanel panel;
    Random numberRandom = new Random();
    public int x;
    public int y;

    public Zombie(Form form)
    {
        panel = new FlowLayoutPanel()
        {
            BackColor = Color.Green,
            Location = new Point(numberRandom.Next(0, 1200), numberRandom.Next(0, 1200)),
            Width = numberRandom.Next(20, 25),
            Height = numberRandom.Next(20, 30)
        };

        form.Controls.Add(panel);

        x = panel.Location.X;
        y = panel.Location.Y;
    }

    public void go(int PositionPlayerX, int PositionPlayerY, int zombieSpeed)
    {
        if (x <= PositionPlayerX && y <= PositionPlayerY)
        {
            x += zombieSpeed;
            y += zombieSpeed;
        }

        if (x >= PositionPlayerX && y <= PositionPlayerY)
        {
            x -= zombieSpeed;
            y += zombieSpeed;
        }

        if (x <= PositionPlayerX && y >= PositionPlayerY)
        {
            x += zombieSpeed;
            y -= zombieSpeed;
        }

        if (x >= PositionPlayerX && y >= PositionPlayerY)
        {
            x -= zombieSpeed;
            y -= zombieSpeed;
        }
        
        panel.Location = new Point(x, y);
    }
}
