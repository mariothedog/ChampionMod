using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace ChampionMod.UI
{
    // Temporarily removed as I could not find a way to keep the button above the armor slots in all resolutions.

    /*class VanitySwitch : UIState
    {
        internal void Unload()
        {

        }

        public override void OnInitialize()
        {
            UIPanel panel = new UIPanel();
            panel.Width.Set(30, 0);
            panel.Height.Set(30, 0);

            panel.HAlign = 1f;
            panel.MarginRight = 103;
            panel.VAlign = 0.368f;
            panel.OnClick += SwitchVanity;
            Append(panel);
        }

        public override void Update(GameTime gameTime)
        {
            if (Main.playerInventory)
            {

            }
            else
            {

            }
        }

        public void SwitchVanity(UIMouseEvent evt, UIElement listeningElement)
        {
            Main.NewText("SWITCH VANITY BUTTON PRESSED");
        }
    }*/
}
