using System;
using System.Windows.Forms;
using System.Drawing;

public class Person1
{
    FlowLayoutPanel panel;

    int x;
    int y;
    bool goLeft = false;
    bool goRight = false;
    bool goTop = false;
    bool goDown = false;
    int playerspeed = 5;



    public Person1(Form form)
    {
        panel = new FlowLayoutPanel()
        {
            ForeColor = Color.DarkBlue,
            BackColor = Color.Coral,
            Height = 40,
            Width = 40
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
            x -= playerspeed;
        if (goRight)
            x += playerspeed;
        if (goTop)
            y -= playerspeed;
        if (goDown)
            y += playerspeed;

        panel.Location = new Point(x, y);

    }
}









