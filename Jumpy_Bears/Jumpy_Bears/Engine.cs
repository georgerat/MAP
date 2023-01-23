using System.Windows.Forms;

namespace Jumpy_Bears
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
                    if (form.player.image.Bounds.IntersectsWith((control as PictureBox).Bounds) && (control as PictureBox).Top >= 80)
                    {
                        if (TopCollision(control as PictureBox, form.player.image))
                        {
                            form.player.gravity = 5;
                            form.player.isJumping = false;
                            form.player.image.Top = (control as PictureBox).Top - form.player.image.Height + 1;
                        }
                        
                        else if (BottomCollision(control as PictureBox, form.player.image))
                        {
                            form.player.gravity = 5;
                            form.player.isJumping = false;
                            form.player.image.Top = (control as PictureBox).Bottom;
                        }
                        
                    }
                }
            }

            if (form.player.image.Top <= 0)
            {
                form.player.gravity = 5;
                form.player.isJumping = false;
                form.player.image.Top = 0;
            }
        }

        static bool BottomCollision(PictureBox pB1, PictureBox pB2)
        {
            if (pB1.Bottom <= pB2.Top)
                return true;
            return false;
        }

        static bool TopCollision(PictureBox pB1, PictureBox pB2)
        {
            if (pB1.Top >= pB2.Bottom)
                return true;
            return false;
        }

        static bool RightCollision(PictureBox pB1, PictureBox pB2)
        {
            if (pB1.Right > pB2.Left && pB1.Left < pB2.Left
                && pB1.Bottom > pB2.Top && pB1.Top < pB2.Bottom)
                return true;
            return false;
        }

        static bool LeftCollision(PictureBox pB1, PictureBox pB2)
        {
            if (pB1.Left < pB2.Right && pB1.Right > pB2.Right
                && pB1.Bottom > pB2.Top && pB1.Top < pB2.Bottom)
                return true;
            return false;
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
