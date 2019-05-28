using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SingleSwordMod.Items
{
    public class PotionOfMemory : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Potion of Memory");
            Tooltip.SetDefault("Teleports you to your last death point");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 30;
            item.maxStack = 30;
            item.rare = 1;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useStyle = 2;
            item.UseSound = SoundID.Item3;
            item.consumable = true;
            //item.buffType = mod.BuffType("DeathTeleportation");
            //item.buffTime = 1;
            item.value = Item.sellPrice(0, 0, 1, 20);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.SetResult(this);
            //recipe.AddTile(13);
            recipe.AddRecipe();
        }

        /*public override bool ConsumeItem(Player player)
        {
            return true;
        }*/

        public override bool UseItem(Player player)
        {
            //Main.NewText("Potion used");
            //Main.NewText(player.GetModPlayer<MyPlayer>().LastDeathX);
            //Main.NewText(player.GetModPlayer<MyPlayer>().LastDeathY);
            if (player.GetModPlayer<MyPlayer>().LastDeathX == 0 || player.GetModPlayer<MyPlayer>().LastDeathY == 0)
            {
                Main.NewText("You have not died recently!");
            }
            else
            {
                player.position.X = player.GetModPlayer<MyPlayer>().LastDeathX;
                player.position.Y = player.GetModPlayer<MyPlayer>().LastDeathY;
            }
            return true;
        }
    }
}