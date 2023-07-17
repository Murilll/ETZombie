using System;
using System.Windows.Forms;
using System.Drawing;


ApplicationConfiguration.Initialize();


var form = new Form();
form.WindowState = FormWindowState.Maximized;
form.FormBorderStyle = FormBorderStyle.None;


FlowLayoutPanel panel = new FlowLayoutPanel();
form.Controls.Add(panel);
panel.ForeColor = Color.DarkBlue;
panel.BackColor = Color.LightBlue;
panel.BackColor = Color.Coral;
panel.Height = 40;
panel.Width = 40;



// Create rectangle for displaying image.

var timer = new Timer();
timer.Interval = 15;


var x = panel.Location.X;
var y = panel.Location.Y;
var goLeft = false;
var goRight = false;
var goTop = false;
var goDown = false;
var playerspeed = 5;


timer.Tick += delegate
{
    if(goLeft)
        x -= playerspeed;
    if(goRight)
        x += playerspeed;
    if(goTop)
        y -= playerspeed;
    if(goDown)
        y += playerspeed;


    panel.Location = new Point(x, y);
};



form.KeyDown += (s, e) =>
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
};

form.KeyUp += (s, e) =>
{
    if (e.KeyCode == Keys.D)
        goRight = false;

    if (e.KeyCode == Keys.A)
        goLeft = false;

    if (e.KeyCode == Keys.S)
        goDown = false;

    if (e.KeyCode == Keys.W)
        goTop = false;
};



form.Load += delegate
{
    form.Show();
    timer.Start();
};

form.KeyPreview = true;

Application.Run(form);
