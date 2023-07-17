using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

public class Zombie
{
    FlowLayoutPanel panel;
    Random numberRandom = new Random();
    int x;
    int y;

    public Zombie(Form form)
    {
        panel = new FlowLayoutPanel()
        {
            BackColor = Color.Green,
            Location = new Point(numberRandom.Next(0, 1200), numberRandom.Next(0, 1200)),
            Width = numberRandom.Next(30, 100),
            Height = numberRandom.Next(30, 100)
        };

        form.Controls.Add(panel);

        x = panel.Location.X;
        y = panel.Location.Y;
    }

    public void go(int PositionPlayerX, int PositionPlayerY)
    {
        if (x <= PositionPlayerX && y <= PositionPlayerY)
        {
            x += 5;
            y += 5;
        }

        if (x >= PositionPlayerX && y <= PositionPlayerY)
        {
            x -= 5;
            y += 5;
        }

        if (x <= PositionPlayerX && y >= PositionPlayerY)
        {
            x += 5;
            y -= 5;
        }

        if (x >= PositionPlayerX && y >= PositionPlayerY)
        {
            x -= 5;
            y -= 5;
        }
        
        panel.Location = new Point(x, y);
    }
}
