using System.Windows.Forms;

namespace Platformer
{
    public static class Engine
    {
        public static Form1 form;

        public static void Initialize(Form1 f)
        {
            form = f;
        }

        public static void PlayerCollision()
        {
            form.player.isJumping = true;
            foreach (var control in form.Controls)
            {
                if (control is PictureBox && !control.Equals(form.player.image))
                {
                    if (form.player.image.Bounds.IntersectsWith((control as PictureBox).Bounds))
                    {
                        form.player.gravity = 0;
                        form.player.isJumping = false;
                        form.player.image.Top = (control as PictureBox).Top - form.player.image.Height + 1;
                    }
                }
            }
        }

        public static void CheckIfYouLose()
        {
            if (form.player.image.Top > form.Height)
            {
                form.timer1.Enabled = false;
                MessageBox.Show("You lose!");
                form.Close();
            }
        }
    }
}
