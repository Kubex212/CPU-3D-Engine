using System;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace Cpu3DEngine
{
    public partial class Form1
    {
        private void flatShadingRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (flatShadingRadioButton.Checked)
            {
                device.ShadingMode = ShadingMode.Flat;
            }
        }

        private void gouraudShadingRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (gouraudShadingRadioButton.Checked)
            {
                device.ShadingMode = ShadingMode.Gouraud;
            }
        }

        private void phongRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (phongRadioButton.Checked)
            {
                device.ShadingMode = ShadingMode.Phong;
            }
        }

        private void staticCameraRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (staticCameraRadioButton.Checked)
            {
                device.activeCamera = staticCamera;
            }
        }

        private void followingCameraRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (followingCameraRadioButton.Checked)
            {
                device.activeCamera = followingCamera;
            }
        }

        private void dynamicCameraRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (dynamicCameraRadioButton.Checked)
            {
                device.activeCamera = rotatingCamera;
            }
        }
        private void ambientTrackBar_Scroll(object sender, EventArgs e)
        {
            device.K_a = (float)ambientTrackBar.Value / 100.0f;
        }

        private void specularTrackBar_Scroll(object sender, EventArgs e)
        {
            device.K_s = (float)specularTrackBar.Value / 100.0f;
        }

        private void diffuseTrackBar_Scroll(object sender, EventArgs e)
        {
            device.K_d = (float)diffuseTrackBar.Value / 100.0f;
        }


        private void shininessTrackBar_Scroll(object sender, EventArgs e)
        {
            device.M = shininessTrackBar.Value;
        }

        private void rotationTrackBar_Scroll(object sender, EventArgs e)
        {
            cylinderAngle = (rotationTrackBar.Value - 50) / 50.0;
            var dx = Math.Sin(cylinderAngle * Math.PI);
            var dz = Math.Cos(cylinderAngle * Math.PI);

            flashlight.ResetModel();
            flashlight.Rotate(Axis.Y, Math.PI * cylinderAngle);
            spotLight.Direction = new Vector3((float)dx, 0, (float)dz);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            hitAngle = trackBar1.Value / 100.0;
            pictureBox2.Invalidate();
        }

        private void globalLightCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            mainLight.Off = !globalLightCheckBox.Checked;
        }

        private void spotLightCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            spotLight.Off = !spotLightCheckBox.Checked;
            if(!spotLightCheckBox.Checked)
            {
                flashlight.ChangeMarkedFacesColor(flashlight.Color, false);
            }
            else 
            {
                flashlight.ChangeMarkedFacesColor(Color.Yellow, true);
            }
        }

        private void fogCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            device.fogGenerator = fogCheckBox.Checked ? fogGenerator : null;
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.TranslateTransform(50.0f, 50.0f);
            e.Graphics.RotateTransform((float)(hitAngle * 360));
            e.Graphics.TranslateTransform(-50.0f, -50.0f);
            e.Graphics.DrawImage(image, 0, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double angle = Math.PI * 2 * hitAngle;

            sphereSpeed.X = (float)numericUpDown1.Value / 10f * (float)Math.Abs(Math.Sin(angle));
            sphereSpeed.Z = (float)numericUpDown1.Value / 10f * (float)Math.Abs(Math.Cos(angle));
            sphereAcceleration = (sphereSpeed.X / 100f, sphereSpeed.Z / 100f);

            if (angle <= Math.PI / 2)
            {
                direction = (1, 1);
            }
            if (angle >= Math.PI / 2 && angle <= Math.PI)
            {
                direction = (1, -1);
            }
            if (angle >= Math.PI && angle <= 3 * Math.PI / 2)
            {
                direction = (-1, -1);
            }
            if (angle >= 3 * Math.PI / 2)
            {
                direction = (-1, 1);
            }
        }
    }
}
