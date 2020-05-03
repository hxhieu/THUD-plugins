using System;
using System.Collections.Generic;

namespace Turbo.Plugins.User.Painters
{
    public class CentreSlotPainter : ITransparentCollection
    {
        private IFont _centreFont;
        private IController _hud;

        public CentreSlotPainter(IController hud)
        {
            _hud = hud;
            _centreFont = _hud.Render.CreateFont("arial", 14, 255, 255, 255, 255, true, false, 255, 0, 0, 0, true);
        }

        public void Paint(IBuff buff)
        {
            if ((buff == null) || (buff.IconCounts[0] <= 0)) return;
            var cooldown = buff.TimeLeftSeconds[1].ToString("F");
            var textLayout = _centreFont.GetTextLayout(cooldown);
            var x = (_hud.Window.Size.Width - (float)Math.Ceiling(textLayout.Metrics.Width)) / 2;
            var y = (_hud.Window.Size.Height - textLayout.Metrics.Height) / 2;

            //_centreFont.DrawText(buff.TimeLeftSeconds[1].ToString("F"), x, y);
            _centreFont.DrawText(buff.TimeLeftSeconds.Length.ToString(), x, y);
        }

        public IEnumerable<ITransparent> GetTransparents()
        {
            yield return _centreFont;
        }
    }
}