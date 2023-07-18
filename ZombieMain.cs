using System;
using System.Drawing;
using System.Windows.Forms;

public class ZombieMain
{

    Rectangle zombie;
    int life = 20;
    public int movespeed = 3;
    public int attackDamage = 5;
    public int x;
    public int y;
    bool goLeft = false;
    bool goRight = false;
    bool goTop = false;
    bool goDown = false;



    public ZombieMain(Form form, SolidBrush mybrush)
    {
        zombie = new Rectangle(0, 0, 20, 20);
    }

    public void go(KeyEventArgs e)
    {
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

        zombie.Location = new Point(x, y);

    }


    public void draw(Form form, Graphics g, SolidBrush color)
    {
        var zombieMain = new ZombieMain(form, color);
        g.FillRectangle(Brushes.Red, new Rectangle(x, y, 20, 20));
    }
}









