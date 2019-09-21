using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChampionMod.Items.Consumables
{
    class Apple : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.useTime = 17;
            item.useAnimation = 17;
            item.useStyle = 2;
            item.healLife = 10;
            item.consumable = true;
            item.maxStack = 30;
            item.potion = true; // For potion sickness and quick heal
            item.value = 100; // 20 copper coins
            item.scale = 0.7f;
        }

        // So the item is smaller in the world (when dropped)
        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            scale = 0.4f;
            Texture2D texture = Main.itemTexture[item.type];
            // Since item.height (hitbox) is smaller than texture.Height it will add a negative number which brings the position upwards
            Vector2 position = item.position - Main.screenPosition + new Vector2(item.width / 2, item.height - texture.Height * scale);

            spriteBatch.Draw(texture, position, null, lightColor, rotation, Vector2.Zero, scale, SpriteEffects.None, 0f);
            return false;
        }
    }
}