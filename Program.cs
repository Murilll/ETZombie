

using System.Windows.Forms;

ApplicationConfiguration.Initialize();


var form = new Form();
form.WindowState = FormWindowState.Maximized;
form.FormBorderStyle = FormBorderStyle.None;

var zombieMain = new Person1(form);

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
};



form.Load += delegate
{
    form.Show();
    timer.Start();
};

form.KeyPreview = true;

Application.Run(form);