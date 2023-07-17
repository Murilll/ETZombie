using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

ApplicationConfiguration.Initialize();

var form = new Form();

Random random = new Random();
Random numberRandom = new Random();

form.WindowState = FormWindowState.Maximized;
form.FormBorderStyle = FormBorderStyle.Fixed3D;

Panel pn = new Panel();
pn.BackColor = Color.Pink;
form.Controls.Add(pn);

Panel zombie = new Panel();
for (int i = 0; i < 5; i++)
{
    zombie.BackColor = Color.Green;
    zombie.Location = new Point(numberRandom.Next(0, 1200), numberRandom.Next(0, 1200));
    zombie.Width = numberRandom.Next(30, 100);
    zombie.Height = numberRandom.Next(30, 100);
    form.Controls.Add(zombie);
}

var flagX = 10;
var flagY = 10;

var tm = new Timer();
tm.Interval = 20;
tm.Tick += delegate
{
    var xpn = pn.Location.X;
    var ypn = pn.Location.Y;

    var x = zombie.Location.X;
    var y = zombie.Location.Y;

    if (x <= xpn && y <= ypn)
    {
        x += 5;
        y += 5;
    }

    if (x >= xpn && y <= ypn)
    {
        x -= 5;
        y += 5;
    }

    if (x <= xpn && y >= ypn)
    {
        x += 5;
        y -= 5;
    }

    if (x >= xpn && y >= ypn)
    {
        x -= 5;
        y -= 5;
    }

    if (pn.Location.X >= form.Width - pn.Width || pn.Location.X < 0)
    {
        flagX *= -1;
        pn.BackColor = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), 0);
    }

    if (pn.Location.Y < 0 || pn.Location.Y >= form.Height - pn.Height)
    {
        flagY *= -1;
        pn.BackColor = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), 0);
    }

    xpn += flagX;
    ypn += flagY;

    zombie.Location = new Point(x, y);
    pn.Location = new Point(xpn, ypn);
};

form.Load += delegate
{
    form.Show();
    tm.Start();
};

Application.Run(form);