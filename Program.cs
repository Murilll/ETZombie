

using System.Windows.Forms;

ApplicationConfiguration.Initialize();


var form = new Form();
form.WindowState = FormWindowState.Maximized;
form.FormBorderStyle = FormBorderStyle.None;

var zombieMain = new ZombieMain(form);

var zombie = new Zombie(form);

// Create rectangle for displaying image.

var timer = new Timer();
timer.Interval = 15;



form.KeyDown += (s, e) =>
{
    zombieMain.go(e);
};
form.KeyUp += (s, e) =>
{
    zombieMain.stop(e);
};
timer.Tick += delegate
{
    zombieMain.movement();
    zombie.go(zombieMain.x,zombieMain.y,zombieMain.movespeed - 2);
};



form.Load += delegate
{
    form.Show();
    timer.Start();
};

form.KeyPreview = true;

Application.Run(form);