using ChampionMod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons.Throwing
{
    public class CorruptorsKnife : ModItem
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Corruptors Knife");
        }
        
        public override void SetDefaults() {
            item.shootSpeed = 12f;
            item.damage = 45;
            item.knockBack = 6f;
            item.useStyle = 1;
            item.useAnimation = 22;
            item.useTime = 22;
            item.width = 30;
            item.height = 30;
            item.maxStack = 1;
            item.rare = 4;

            item.consumable = false;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.thrown = true;

            item.UseSound = SoundID.Item1;
            item.value = Item.sellPrice(gold: 1);
            item.shoot = mod.ProjectileType("CorruptKnife");
        }
    }
}