using System;
using System.Windows.Forms;
using System.Drawing;

public class ZombieMain
{
    FlowLayoutPanel panel;

    int life = 20;
    public int movespeed = 3;



    public int x;
    public int y;
    bool goLeft = false;
    bool goRight = false;
    bool goTop = false;
    bool goDown = false;



    public ZombieMain(Form form)
    {
        panel = new FlowLayoutPanel()
        {
            ForeColor = Color.DarkBlue,
            BackColor = Color.Coral,
            Height = 20,
            Width = 20
        };

        form.Controls.Add(panel);

        x = panel.Location.X;
        y = panel.Location.Y;
    }

    public void go(KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Escape)
            Application.Exit();

        if (e.KeyCode == Keys.D)
            goRight = true;

        if (e.KeyCode == Keys.A)
            goLeft = true;

        if (e.KeyCode == Keys.S)
            goDown = true;

        if (e.KeyCode == Keys.W)
            goTop = true;
    }

    public void stop(KeyEventArgs e)
    {
        if (e.KeyCode == Keys.D)
            goRight = false;

        if (e.KeyCode == Keys.A)
            goLeft = false;

        if (e.KeyCode == Keys.S)
            goDown = false;

        if (e.KeyCode == Keys.W)
            goTop = false;
    }

    public void movement()
    {
        if (goLeft)
            x -= movespeed;
        if (goRight)
            x += movespeed;
        if (goTop)
            y -= movespeed;
        if (goDown)
            y += movespeed;

        panel.Location = new Point(x, y);

    }
}









