using BepInEx;
using BepInEx.Unity.IL2CPP;
using Il2CppSystem.IO;
using UnityEngine;
using WildfrostModMiya;

namespace WildfrostReptileFaction;

[BepInPlugin("Wildfrost.ArtlessAvian.ReptileFaction", "ReptileFaction", "0.1.0")]
[BepInDependency("WildFrost.Miya.WildfrostAPI")]
public class WildfrostReptileFaction : BasePlugin
{
    // Taken from library code.
    public static readonly string PluginFolder = typeof(WildfrostReptileFaction).Assembly.Location.Replace("WildfrostReptileFaction.dll", "");

    // static StatusEffectData whenSnowAppliedToSelfGainTeeth;

    public override void Load()
    {
        Log.LogInfo("helllllooooo");
        Log.LogInfo("loaded at " + PluginFolder);

        CardAdder.OnAskForAddingCards += (int i) =>
        {
            Log.LogInfo("Adding Gates");

            CardData cardData = CardAdder.CreateCardData("ReptileFaction", "Gates")
                .SetIsUnit()
                .SetStats(12, 1, 0)
                .SetCanPlay(CardAdder.CanPlay.CanPlayOnBoard)
                .SetStartWithEffects(
                    CardAdder.VanillaStatusEffects.WhenHitTriggerToSelf.StatusEffectStack(1),
                    CardAdder.VanillaStatusEffects.WhenSnowAppliedToSelfGainEqualAttack.StatusEffectStack(1)
                )
                // Flavor
                .SetTitle("Gates")
                .SetSprites(LoadSprite("assets/gates/sketch1690152179600.png"), LoadSprite("assets/gates/white.png"))
                // Metagame
                // .AddToPool(CardAdder.VanillaRewardPools.GeneralUnitPool)
                .RegisterCardInApi();
        };

        // // Commented because broken. Also not fun. (Teeth still hits when snowed. Smackback does not.)
        // // Intended for Gates.
        // StatusEffectAdder.OnAskForAddingStatusEffects += (int i) =>
        // {
        //     Log.LogInfo("Adding WhenSnowAppliedToSelfGainTeeth");
        //     whenSnowAppliedToSelfGainTeeth =
        //     StatusEffectAdder.CreateStatusEffectData<StatusEffectApplyXWhenYAppliedToSelf>("ReptileFaction", "WhenSnowAppliedToSelfGainTeeth")
        //         .SetText("When <keyword=snow>'d, gain equal <keyword=teeth>")
        //         .ModifyFields(
        //             (StatusEffectApplyXWhenYAppliedToSelf effect) =>
        //             {
        //                 effect.effectToApply = CardAdder.VanillaStatusEffects.Teeth.StatusEffectData();
        //                 effect.whenAppliedType = "Snow";
        //                 return effect;
        //             })
        //         .RegisterStatusEffectInApi();
        // };

        // // Commented because not fun, needs work.
        // CardAdder.OnAskForAddingCards += (int i) =>
        // {
        //     Log.LogInfo("Adding Reggie");
        //     CardData cardData = CardAdder.CreateCardData("ReptileFaction", "Reggie")
        //         .SetIsUnit()
        //         .SetStats(4, 5, 2)
        //         .SetCanPlay(CardAdder.CanPlay.CanPlayOnBoard)
        //         .SetStartWithEffects(
        //             CardAdder.VanillaStatusEffects.Snow.StatusEffectStack(3)
        //             )
        //         // Flavor
        //         .SetTitle("Reggie")
        //         .SetText("Start with 3 <keyword=snow>.")
        //         // Metagame
        //         .AddToPool(CardAdder.VanillaRewardPools.GeneralUnitPool)
        //         .RegisterCardInApi();
        // };

        // CardAdder.OnAskForAddingCards += (int i) =>
        // {
        //     Log.LogInfo("Adding Scorpy");
        //     CardData cardData = CardAdder.CreateCardData("ReptileFaction", "Scorpy")
        //         .SetIsUnit()
        //         .SetStats(6, 4, 2)
        //         .SetCanPlay(CardAdder.CanPlay.CanPlayOnBoard)
        //         .SetStartWithEffects(
        //             CardAdder.VanillaStatusEffects.HitFurthestTarget.StatusEffectStack(1)
        //         )
        //         .SetAttackEffects(
        //             CardAdder.VanillaStatusEffects.Pull.StatusEffectStack(1)
        //         )
        //         // Flavor
        //         .SetTitle("Scorpy")
        //         .SetText("Yank\nLongshot")
        //         // Metagame
        //         .AddToPool(CardAdder.VanillaRewardPools.GeneralUnitPool)
        //         .RegisterCardInApi();
        // };
    }

    private static Sprite LoadSprite(string path)
    {
        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage(File.ReadAllBytes(PluginFolder + path));
        return tex.ToSprite();
    }
}
