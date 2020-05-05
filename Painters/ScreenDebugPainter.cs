using System.Collections.Generic;

namespace Turbo.Plugins.User.Painters
{
    public class ScreenDebugPainter : ITransparentCollection
    {
        private IFont _centreFont;
        private IController _hud;

        public ScreenDebugPainter(IController hud)
        {
            _hud = hud;
            _centreFont = _hud.Render.CreateFont("arial", 8, 255, 255, 255, 255, true, false, 255, 0, 0, 0, true);
        }

        public void Paint(string msg)
        {
            var x = (int)(_hud.Window.Size.Width - 100) / 2;
            var y = (_hud.Window.Size.Height / 3) * 2;

            _centreFont.DrawText(msg, x, y);
        }

        public IEnumerable<ITransparent> GetTransparents()
        {
            yield return _centreFont;
        }
    }
}