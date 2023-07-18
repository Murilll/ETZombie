using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

public class Human
{
    Rectangle human;
    Random numberRandom = new Random();
    int x;
    int y;
    int maxSpeed = 10;
    double direcaoX;
    double direcaoY;
    int pointOfView = 300;
    double range;
    double d;

    public Human(Form form, SolidBrush mybrush)
        => human = new Rectangle(0, 0, 20, 20); 

    public void escape(int zombieX, int zombieY)
    {
        x = human.Location.X;
        y = human.Location.Y;

        d = Math.Pow((x - zombieX), 2) + Math.Pow((y - zombieY),2);

        range = Math.Sqrt(d);

        if (range <= pointOfView)
        {
            direcaoX = (x - zombieX)*-1;
            direcaoY = (y - zombieY)*-1;

            double pita = Math.Sqrt(direcaoX * direcaoX + direcaoY * direcaoY);
            
            x -= (int)direcaoX / (int)pita * maxSpeed;
            y -= (int)direcaoY / (int)pita * maxSpeed;
             
        }

        human.Location = new Point(x, y);
    }

    public void draw(Form form, Graphics g, SolidBrush color)
    {
        var human = new Human(form, color);
        g.FillRectangle(Brushes.Red, new Rectangle(x, y, 20, 20)); 
    }
}
