using Turbo.Plugins.Default;

namespace Turbo.Plugins.User.Extensions
{
    public class CoEFocusPlugin
    {
        /**
        * Calculates and bring the default CoE buff list to the center of the screen
        */
        public static DestructablePoint CalcCoEDrawPoint(BuffRuleCalculator ruleCalculator, BuffPainter painter)
        {
            var hud = ruleCalculator.Hud;
            // Customise the look and feel
            ruleCalculator.SizeMultiplier = 0.75f;
            painter.TimeLeftFont = hud.Render.CreateFont("tahoma", 14, 255, 255, 255, 255, true, false, 255, 0, 0, 0, true);
            painter.Opacity = 0.5f;

            // Where to draw
            var screenWidth = hud.Window.Size.Width;
            var screenHeight = hud.Window.Size.Height;
            var left = (int)(screenWidth - ruleCalculator.PaintInfoList.Count * ruleCalculator.StandardIconSize) / 2;
            return new DestructablePoint(left, screenHeight / 2);
        }
    }
}