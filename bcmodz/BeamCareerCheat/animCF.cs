using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System.Windows;
using System.Windows.Media.Effects;
using System.Windows.Controls;

namespace BeamCareerCheat
{
    public class animCF
    {
        public async void canvasAnim(MainWindow mw)
        {
            mw.canvasMainBody.Opacity = 0;

            //cross fade to main body
            DoubleAnimation canvasAnim = new DoubleAnimation
            {
                From = 1,
                To = 0,
                Duration = TimeSpan.FromSeconds(0.8),
                AutoReverse = false
            };
            mw.canvasProfileSelect.BeginAnimation(UIElement.OpacityProperty, canvasAnim);
            
            await Task.Run(() =>
            {
                Thread.Sleep(850);
            });
            mw.canvasProfileSelect.Visibility = Visibility.Hidden;

            await Task.Run(() =>
            {
                Thread.Sleep(100);
            });

            DoubleAnimation canvasAnim2 = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.8),
                AutoReverse = false
            };
            mw.canvasMainBody.BeginAnimation(UIElement.OpacityProperty, canvasAnim2);

            await Task.Run(() =>
            {
                Thread.Sleep(800);
            });

            logger.log("Completed canvasAnim");
        }

        public async void canvasLoadAnim(MainWindow mw)
        {
            Panel.SetZIndex(mw.canvasDark, 3);
            Panel.SetZIndex(mw.loadingCanvas, 4);
            var blurEffect = new BlurEffect { Radius = 0 };
            mw.canvasProfileSelect.Effect = blurEffect;
            mw.canvasTitle.Effect = blurEffect;

            DoubleAnimation blurAnimation = new DoubleAnimation
            {
                From = 0,
                To = 15,
                Duration = TimeSpan.FromSeconds(0.5),
                AutoReverse = false
            };
            DoubleAnimation darknessAnimation = new DoubleAnimation
            {
                From = 0,
                To = 0.7,
                Duration = TimeSpan.FromSeconds(0.5),
                AutoReverse = false
            };
            DoubleAnimation canvasAnimIN = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(1),
                AutoReverse = false
            };

            mw.progressBar.Visibility = Visibility.Visible;
            mw.loadingCanvas.BeginAnimation(UIElement.OpacityProperty, canvasAnimIN);
            blurEffect.BeginAnimation(BlurEffect.RadiusProperty, blurAnimation);
            mw.canvasDark.BeginAnimation(UIElement.OpacityProperty, darknessAnimation);
            logger.log("Completed canvasLoadAnim");
        }

        public async void canvasLoadAnimOUT(MainWindow mw)
        {
            DoubleAnimation blurAnimation = new DoubleAnimation
            {
                From = 15,
                To = 0,
                Duration = TimeSpan.FromSeconds(0.5),
                AutoReverse = false
            };
            DoubleAnimation darknessAnimation = new DoubleAnimation
            {
                From = 0.7,
                To = 0,
                Duration = TimeSpan.FromSeconds(0.5),
                AutoReverse = false
            };
            DoubleAnimation canvasAnimOUT = new DoubleAnimation
            {
                From = 1,
                To = 0,
                Duration = TimeSpan.FromSeconds(1),
                AutoReverse = false
            };

            mw.loadingCanvas.BeginAnimation(UIElement.OpacityProperty, canvasAnimOUT);

            await Task.Delay(TimeSpan.FromSeconds(0.5));
            if (mw.canvasProfileSelect.Effect is BlurEffect blurEffect)
            {
                blurEffect.BeginAnimation(BlurEffect.RadiusProperty, blurAnimation);
            }
            mw.canvasDark.BeginAnimation(UIElement.OpacityProperty, darknessAnimation);
            

            await Task.Delay(TimeSpan.FromSeconds(1.2));
            Panel.SetZIndex(mw.canvasDark, -1);
            Panel.SetZIndex(mw.loadingCanvas, -1);
            mw.progressBar.Visibility = Visibility.Collapsed;

            logger.log("Completed canvasLoadAnimOUT");
        }
    }   
}
