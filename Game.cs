using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;


public class Game
{
    public void go()
    {
        List<Zombie> zombies = new List<Zombie>();
        bool running = true;

        ApplicationConfiguration.Initialize();

        PictureBox pb = new PictureBox();
        pb.Dock = DockStyle.Fill;

        Graphics g = null;
        Bitmap bmp = null;

        var form = new Form();
        form.WindowState = FormWindowState.Maximized;
        form.FormBorderStyle = FormBorderStyle.None;
        form.Controls.Add(pb);



        var zombieMain = new ZombieMain(form, new SolidBrush(Color.Red));
        var human = new Human(form, new SolidBrush(Color.Red));
        var zombie = new Zombie(form);

        // Create rectangle for displaying image.

        var timer = new Timer();
        timer.Interval = 15;



        Application.Idle += delegate
        {
            while (running)
            {

                zombieMain.draw(form, g, new SolidBrush(Color.Red));
                zombieMain.movement();

                foreach (var z in zombies)
                {
                    z.go(zombieMain.x, zombieMain.y, zombieMain.movespeed - 1);
                }
                pb.Refresh();
                g.Clear(Color.Transparent);
                Application.DoEvents();
            }
        };


        form.KeyDown += (s, e) =>
        {
            if (e.KeyCode == Keys.Escape)
            {
                running = false;
                Application.Exit();
            }
            zombieMain.go(e);
            // if ((zombieMain.x >= human.x) && (zombieMain.y >= human.y))
            // {
            //     human.life -= zombieMain.attackDamage;
            //     if (human.life < -0)
            //     {
            //         var zombie = new Zombie(form, human.x, human.y);
            //         human.death(form);
            //         human = new Human(form);
            //         zombies.Add(zombie);

            //     }
            // }

        };

        form.KeyUp += (s, e) =>
        {
            zombieMain.stop(e);
        };

        timer.Tick += delegate
        {
            zombieMain.movement();
            zombie.go(zombieMain.x, zombieMain.y, zombieMain.movespeed - 1);
            human.escape(zombieMain.x, zombieMain.y);
        };

        form.Load += delegate
        {
            bmp = new Bitmap(pb.Width, pb.Height);
            g = Graphics.FromImage(bmp);
            pb.Image = bmp;


            timer.Start();
        };





        form.KeyPreview = true;

        Application.Run(form);
    }
}
