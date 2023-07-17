

using System.Windows.Forms;

ApplicationConfiguration.Initialize();


var form = new Form();
form.WindowState = FormWindowState.Maximized;
form.FormBorderStyle = FormBorderStyle.None;

var per1 = new Person1(form);

var zombie = new Zombie(form);

// Create rectangle for displaying image.

var timer = new Timer();
timer.Interval = 15;



form.KeyDown += (s, e) =>
{
    per1.go(e);
};
form.KeyUp += (s, e) =>
{
    per1.stop(e);
};
timer.Tick += delegate
{
    per1.movement();
    zombie.go(0,0);
};




form.Load += delegate
{
    form.Show();
    timer.Start();
};

form.KeyPreview = true;

Application.Run(form);