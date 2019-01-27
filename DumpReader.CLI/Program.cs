namespace DumpReader.CLI
{
    using System;
    using System.IO;
    using System.Threading.Tasks;

    internal static class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        private static async Task Main()
        {
            var CurrentDir  = Directory.GetCurrentDirectory();
            var OutputPath  = Path.Combine(CurrentDir, "Output.txt");
            var DumpsDir    = Path.Combine(CurrentDir, "Dumps");
            var DumpPath    = Path.Combine(DumpsDir, "PUBG_5.1.8.1.txt");
            var Dump        = new Dump(DumpPath);
            var OutputFile  = new FileInfo(OutputPath);

            if (OutputFile.Exists)
            {
                OutputFile.Delete();
            }

            // ..

            Dump.Read();

            // ..

            using (var Stream = OutputFile.CreateText())
            {
                if (Dump.Classes.TryGetValue("PlayerController", out var PlayerController))
                {
                    await Stream.WriteHeader("PlayerController");
                    await Stream.WriteOffset(PlayerController, "PlayerCameraManagerPtr", PlayerController["PlayerCameraManager"]);
                    await Stream.WriteOffset(PlayerController, "SpectatorPawnPtr", PlayerController["SpectatorPawn"]);
                    await Stream.WriteOffset(PlayerController, "AcknowledgedPawnPtr", PlayerController["AcknowledgedPawn"]);
                    await Stream.WriteOffset(PlayerController, "InputRotation", PlayerController["NetConnection"] + 0x08);
                }

                if (Dump.Classes.TryGetValue("Controller", out var Controller))
                {
                    await Stream.WriteHeader("Controller");
                    await Stream.WriteOffset(Controller, "PawnPtr", Controller["Pawn"]);
                    await Stream.WriteOffset(Controller, "ControlRotation", Controller["ControlRotation"]);
                    await Stream.WriteOffset(Controller, "PlayerStatePtr", Controller["PlayerState"]);
                }

                if (Dump.Classes.TryGetValue("Actor", out var Actor))
                {
                    await Stream.WriteHeader("Actor");
                    await Stream.WriteOffset(Actor, "RootComponentPtr", Actor["RootComponent"]);
                }

                if (Dump.Classes.TryGetValue("TslVehicleCommonComponent", out var TslVehicleCommonComponent))
                {
                    await Stream.WriteHeader("TslVehicleCommonComponent");
                    await Stream.WriteOffset(TslVehicleCommonComponent, "Health", TslVehicleCommonComponent["Health"]);
                    await Stream.WriteOffset(TslVehicleCommonComponent, "HealthMax", TslVehicleCommonComponent["HealthMax"]);
                    await Stream.WriteOffset(TslVehicleCommonComponent, "Fuel", TslVehicleCommonComponent["Fuel"]);
                    await Stream.WriteOffset(TslVehicleCommonComponent, "FuelMax", TslVehicleCommonComponent["FuelMax"]);
                }

                if (Dump.Classes.TryGetValue("PlayerState", out var PlayerState))
                {
                    await Stream.WriteHeader("PlayerState");
                    await Stream.WriteOffset(PlayerState, "PlayerName", PlayerState["PlayerName"]);
                }

                if (Dump.Classes.TryGetValue("SceneComponent", out var SceneComponent))
                {
                    await Stream.WriteHeader("SceneComponent");
                    await Stream.WriteOffset(SceneComponent, "RelativeLocation", SceneComponent["RelativeLocation"]);
                    await Stream.WriteOffset(SceneComponent, "ComponentVelocity", SceneComponent["ComponentVelocity"]);
                }

                if (Dump.Classes.TryGetValue("SkinnedMeshComponent", out var SkinnedMeshComponent))
                {
                    await Stream.WriteHeader("SkinnedMeshComponent");
                    await Stream.WriteOffset(SkinnedMeshComponent, "CachedBoneSpaceTransforms", SkinnedMeshComponent["MasterPoseComponent"] + 0x08);
                }

                if (Dump.Classes.TryGetValue("PrimitiveComponent", out var PrimitiveComponent))
                {
                    await Stream.WriteHeader("PrimitiveComponent");
                    await Stream.WriteOffset(PrimitiveComponent, "LastRenderTimeOnScreen", PrimitiveComponent["LastRenderTimeOnScreen"]);
                    await Stream.WriteOffset(PrimitiveComponent, "LastRenderTime", PrimitiveComponent["LastRenderTime"]);
                    await Stream.WriteOffset(PrimitiveComponent, "LastSubmitTime", PrimitiveComponent["LastSubmitTime"]);
                }

                if (Dump.Classes.TryGetValue("SkeletalMeshComponent", out var SkeletalMeshComponent))
                {
                    await Stream.WriteHeader("SkeletalMeshComponent");
                    await Stream.WriteOffset(SkeletalMeshComponent, "AnimScriptInstancePtr", SkeletalMeshComponent["AnimScriptInstance"]);
                }

                if (Dump.Classes.TryGetValue("WeaponProcessorComponent", out var WeaponProcessorComponent))
                {
                    await Stream.WriteHeader("WeaponProcessorComponent");
                    await Stream.WriteOffset(WeaponProcessorComponent, "EquippedWeapons", WeaponProcessorComponent["EquippedWeapons"]);
                    await Stream.WriteOffset(WeaponProcessorComponent, "WeaponArmInfo", WeaponProcessorComponent["WeaponArmInfo"]);
                }

                if (Dump.Classes.TryGetValue("TslAnimInstance", out var TslAnimInstance))
                {
                    await Stream.WriteHeader("TslAnimInstance");
                    await Stream.WriteOffset(TslAnimInstance, "ControlRotation_CP", TslAnimInstance["ControlRotation_CP"]);
                    await Stream.WriteOffset(TslAnimInstance, "ControlRotationFPP_CP", TslAnimInstance["ControlRotationFPP_CP"]);
                }

                if (Dump.Classes.TryGetValue("TslWeapon_Gun", out var TslWeapon_Gun))
                {
                    await Stream.WriteHeader("TslWeapon_Gun");
                    await Stream.WriteOffset(TslWeapon_Gun, "CurrentZeroLevel", TslWeapon_Gun["CurrentZeroLevel"]);
                }

                if (Dump.Classes.TryGetValue("CharacterMovementComponent", out var CharacterMovementComponent))
                {
                    await Stream.WriteHeader("CharacterMovementComponent");
                    await Stream.WriteOffset(CharacterMovementComponent, "Acceleration", CharacterMovementComponent["Acceleration"]);
                    await Stream.WriteOffset(CharacterMovementComponent, "GravityScale", CharacterMovementComponent["GravityScale"]);
                    await Stream.WriteOffset(CharacterMovementComponent, "JumpZVelocity", CharacterMovementComponent["JumpZVelocity"]);
                    await Stream.WriteOffset(CharacterMovementComponent, "MaxWalkSpeed", CharacterMovementComponent["MaxWalkSpeed"]);
                    await Stream.WriteOffset(CharacterMovementComponent, "MaxWalkSpeedCrouched", CharacterMovementComponent["MaxWalkSpeedCrouched"]);
                    await Stream.WriteOffset(CharacterMovementComponent, "MaxSwimSpeed", CharacterMovementComponent["MaxSwimSpeed"]);
                    await Stream.WriteOffset(CharacterMovementComponent, "MaxFlySpeed", CharacterMovementComponent["MaxFlySpeed"]);
                    await Stream.WriteOffset(CharacterMovementComponent, "MaxCustomMovementSpeed", CharacterMovementComponent["MaxCustomMovementSpeed"]);
                    await Stream.WriteOffset(CharacterMovementComponent, "LastUpdateVelocity", CharacterMovementComponent["LastUpdateVelocity"]);
                    await Stream.WriteOffset(CharacterMovementComponent, "LastUpdateRotation", CharacterMovementComponent["LastUpdateRotation"]);
                    await Stream.WriteOffset(CharacterMovementComponent, "LastUpdateLocation", CharacterMovementComponent["LastUpdateLocation"]);
                }

                if (Dump.Classes.TryGetValue("TslCharacterMovement", out var TslCharacterMovement))
                {
                    await Stream.WriteHeader("TslCharacterMovement");
                    await Stream.WriteOffset(TslCharacterMovement, "MinJumpZVelocity", TslCharacterMovement["MinJumpZVelocity"]);
                    await Stream.WriteOffset(TslCharacterMovement, "MaxJumpZVelocity", TslCharacterMovement["MaxJumpZVelocity"]);
                    await Stream.WriteOffset(TslCharacterMovement, "SpeedInWaterModifier", TslCharacterMovement["SpeedInWaterModifier"]);
                    await Stream.WriteOffset(TslCharacterMovement, "SpeedInWaterModifier", TslCharacterMovement["SpeedInWaterModifier"]);
                }

                if (Dump.Classes.TryGetValue("ItemPackage", out var ItemPackage))
                {
                    await Stream.WriteHeader("ItemPackage");
                    await Stream.WriteOffset(ItemPackage, "Items", ItemPackage["Items"]);
                }

                if (Dump.Classes.TryGetValue("DroppedItemInteractionComponent", out var DroppedItemInteractionComponent))
                {
                    await Stream.WriteHeader("DroppedItemInteractionComponent");
                    await Stream.WriteOffset(DroppedItemInteractionComponent, "Item", DroppedItemInteractionComponent["Item"]);
                }

                if (Dump.Classes.TryGetValue("DroppedItem", out var DroppedItem))
                {
                    await Stream.WriteHeader("DroppedItem");
                    await Stream.WriteOffset(DroppedItem, "Item", DroppedItem["Item"]);
                }

                if (Dump.Classes.TryGetValue("Item", out var Item))
                {
                    await Stream.WriteHeader("Item");
                    await Stream.WriteOffset(Item, "ItemName", Item["ItemName"]);
                    await Stream.WriteOffset(Item, "ItemCategory", Item["ItemCategory"]);
                    await Stream.WriteOffset(Item, "ItemDetailedName", Item["ItemDetailedName"]);
                    await Stream.WriteOffset(Item, "ItemDescription", Item["ItemDescription"]);
                    await Stream.WriteOffset(Item, "StackCount", Item["StackCount"]);
                    await Stream.WriteOffset(Item, "StackCountMax", Item["StackCountMax"]);
                    await Stream.WriteOffset(Item, "StackCountMax", Item["StackCountMax"]);
                    await Stream.WriteOffset(Item, "Category", Item["Category"]);
                }

                if (Dump.Classes.TryGetValue("TslWeapon_Trajectory", out var TslWeapon_Trajectory))
                {
                    await Stream.WriteHeader("TslWeapon_Trajectory");
                    await Stream.WriteOffset(TslWeapon_Trajectory, "WeaponTrajectoryData", TslWeapon_Trajectory["WeaponTrajectoryData"]);
                }

                if (Dump.Classes.TryGetValue("WeaponTrajectoryData", out var WeaponTrajectoryData))
                {
                    await Stream.WriteHeader("WeaponTrajectoryData");
                    await Stream.WriteOffset(WeaponTrajectoryData, "TrajectoryConfig", WeaponTrajectoryData["TrajectoryConfig"]);
                }

                if (Dump.Classes.TryGetValue("WeaponTrajectoryConfig", out var WeaponTrajectoryConfig))
                {
                    await Stream.WriteHeader("WeaponTrajectoryConfig");
                    await Stream.WriteOffset(WeaponTrajectoryConfig, "InitialSpeed", WeaponTrajectoryConfig["InitialSpeed"]);
                    await Stream.WriteOffset(WeaponTrajectoryConfig, "VDragCoefficient", WeaponTrajectoryConfig["VDragCoefficient"]);
                    await Stream.WriteOffset(WeaponTrajectoryConfig, "TravelDistanceMax", WeaponTrajectoryConfig["TravelDistanceMax"]);
                }
            }
        }
    }
}
