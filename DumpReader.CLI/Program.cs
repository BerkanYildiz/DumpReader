namespace DumpReader.CLI
{
    using System;
    using System.IO;

    internal static class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        private static void Main()
        {
            var CurrentDir  = Directory.GetCurrentDirectory();
            var OutputPath  = Path.Combine(CurrentDir, "Output.txt");
            var DumpsDir    = Path.Combine(CurrentDir, "Dumps");
            var DumpPath    = Path.Combine(DumpsDir, "ObjectsDump.txt");
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
                    Stream.WriteHeader("PlayerController");
                    Stream.WriteOffset(PlayerController, "PlayerCameraManagerPtr", PlayerController["PlayerCameraManager"]);
                    Stream.WriteOffset(PlayerController, "SpectatorPawnPtr", PlayerController["SpectatorPawn"]);
                    Stream.WriteOffset(PlayerController, "AcknowledgedPawnPtr", PlayerController["AcknowledgedPawn"]);
                    Stream.WriteOffset(PlayerController, "NetConnection", PlayerController["NetConnection"]);
                    Stream.WriteOffset(PlayerController, "InputRotation", PlayerController["NetConnection"] + 0x08);
                }

                if (Dump.Classes.TryGetValue("Controller", out var Controller))
                {
                    Stream.WriteHeader("Controller");
                    Stream.WriteOffset(Controller, "PawnPtr", Controller["Pawn"]);
                    Stream.WriteOffset(Controller, "ControlRotation", Controller["ControlRotation"]);
                    Stream.WriteOffset(Controller, "PlayerStatePtr", Controller["PlayerState"]);
                }

                if (Dump.Classes.TryGetValue("Actor", out var Actor))
                {
                    Stream.WriteHeader("Actor");
                    Stream.WriteOffset(Actor, "RootComponentPtr", Actor["RootComponent"]);
                }

                if (Dump.Classes.TryGetValue("TslVehicleCommonComponent", out var TslVehicleCommonComponent))
                {
                    Stream.WriteHeader("TslVehicleCommonComponent");
                    Stream.WriteOffset(TslVehicleCommonComponent, "Health", TslVehicleCommonComponent["Health"]);
                    Stream.WriteOffset(TslVehicleCommonComponent, "HealthMax", TslVehicleCommonComponent["HealthMax"]);
                    Stream.WriteOffset(TslVehicleCommonComponent, "Fuel", TslVehicleCommonComponent["Fuel"]);
                    Stream.WriteOffset(TslVehicleCommonComponent, "FuelMax", TslVehicleCommonComponent["FuelMax"]);
                }

                if (Dump.Classes.TryGetValue("PlayerState", out var PlayerState))
                {
                    Stream.WriteHeader("PlayerState");
                    Stream.WriteOffset(PlayerState, "PlayerName", PlayerState["PlayerName"]);
                }

                if (Dump.Classes.TryGetValue("SceneComponent", out var SceneComponent))
                {
                    Stream.WriteHeader("SceneComponent");
                    Stream.WriteOffset(SceneComponent, "RelativeLocation", SceneComponent["RelativeLocation"]);
                    Stream.WriteOffset(SceneComponent, "ComponentVelocity", SceneComponent["ComponentVelocity"]);
                }

                if (Dump.Classes.TryGetValue("SkinnedMeshComponent", out var SkinnedMeshComponent))
                {
                    Stream.WriteHeader("SkinnedMeshComponent");
                    Stream.WriteOffset(SkinnedMeshComponent, "CachedBoneSpaceTransforms", SkinnedMeshComponent["MasterPoseComponent"] + 0x08);
                }

                if (Dump.Classes.TryGetValue("PrimitiveComponent", out var PrimitiveComponent))
                {
                    Stream.WriteHeader("PrimitiveComponent");
                    Stream.WriteOffset(PrimitiveComponent, "LastRenderTimeOnScreen", PrimitiveComponent["LastRenderTimeOnScreen"]);
                    Stream.WriteOffset(PrimitiveComponent, "LastRenderTime", PrimitiveComponent["LastRenderTime"]);
                    Stream.WriteOffset(PrimitiveComponent, "LastSubmitTime", PrimitiveComponent["LastSubmitTime"]);
                }

                if (Dump.Classes.TryGetValue("SkeletalMeshComponent", out var SkeletalMeshComponent))
                {
                    Stream.WriteHeader("SkeletalMeshComponent");
                    Stream.WriteOffset(SkeletalMeshComponent, "AnimScriptInstancePtr", SkeletalMeshComponent["AnimScriptInstance"]);
                }

                if (Dump.Classes.TryGetValue("WeaponProcessorComponent", out var WeaponProcessorComponent))
                {
                    Stream.WriteHeader("WeaponProcessorComponent");
                    Stream.WriteOffset(WeaponProcessorComponent, "EquippedWeapons", WeaponProcessorComponent["EquippedWeapons"]);
                    Stream.WriteOffset(WeaponProcessorComponent, "WeaponArmInfo", WeaponProcessorComponent["WeaponArmInfo"]);
                }

                if (Dump.Classes.TryGetValue("TslAnimInstance", out var TslAnimInstance))
                {
                    Stream.WriteHeader("TslAnimInstance");
                    Stream.WriteOffset(TslAnimInstance, "ControlRotation_CP", TslAnimInstance["ControlRotation_CP"]);
                    Stream.WriteOffset(TslAnimInstance, "ControlRotationFPP_CP", TslAnimInstance["ControlRotationFPP_CP"]);
                }

                if (Dump.Classes.TryGetValue("TslWeapon_Gun", out var TslWeapon_Gun))
                {
                    Stream.WriteHeader("TslWeapon_Gun");
                    Stream.WriteOffset(TslWeapon_Gun, "CurrentZeroLevel", TslWeapon_Gun["CurrentZeroLevel"]);
                }

                if (Dump.Classes.TryGetValue("CharacterMovementComponent", out var CharacterMovementComponent))
                {
                    Stream.WriteHeader("CharacterMovementComponent");
                    Stream.WriteOffset(CharacterMovementComponent, "Acceleration", CharacterMovementComponent["Acceleration"]);
                    Stream.WriteOffset(CharacterMovementComponent, "GravityScale", CharacterMovementComponent["GravityScale"]);
                    Stream.WriteOffset(CharacterMovementComponent, "JumpZVelocity", CharacterMovementComponent["JumpZVelocity"]);
                    Stream.WriteOffset(CharacterMovementComponent, "MaxWalkSpeed", CharacterMovementComponent["MaxWalkSpeed"]);
                    Stream.WriteOffset(CharacterMovementComponent, "MaxWalkSpeedCrouched", CharacterMovementComponent["MaxWalkSpeedCrouched"]);
                    Stream.WriteOffset(CharacterMovementComponent, "MaxSwimSpeed", CharacterMovementComponent["MaxSwimSpeed"]);
                    Stream.WriteOffset(CharacterMovementComponent, "MaxFlySpeed", CharacterMovementComponent["MaxFlySpeed"]);
                    Stream.WriteOffset(CharacterMovementComponent, "MaxCustomMovementSpeed", CharacterMovementComponent["MaxCustomMovementSpeed"]);
                    Stream.WriteOffset(CharacterMovementComponent, "LastUpdateVelocity", CharacterMovementComponent["LastUpdateVelocity"]);
                    Stream.WriteOffset(CharacterMovementComponent, "LastUpdateRotation", CharacterMovementComponent["LastUpdateRotation"]);
                    Stream.WriteOffset(CharacterMovementComponent, "LastUpdateLocation", CharacterMovementComponent["LastUpdateLocation"]);
                }

                if (Dump.Classes.TryGetValue("TslCharacterMovement", out var TslCharacterMovement))
                {
                    Stream.WriteHeader("TslCharacterMovement");
                    Stream.WriteOffset(TslCharacterMovement, "MinJumpZVelocity", TslCharacterMovement["MinJumpZVelocity"]);
                    Stream.WriteOffset(TslCharacterMovement, "MaxJumpZVelocity", TslCharacterMovement["MaxJumpZVelocity"]);
                    Stream.WriteOffset(TslCharacterMovement, "SpeedInWaterModifier", TslCharacterMovement["SpeedInWaterModifier"]);
                    Stream.WriteOffset(TslCharacterMovement, "SpeedInWaterModifier", TslCharacterMovement["SpeedInWaterModifier"]);
                }

                if (Dump.Classes.TryGetValue("ItemPackage", out var ItemPackage))
                {
                    Stream.WriteHeader("ItemPackage");
                    Stream.WriteOffset(ItemPackage, "Items", ItemPackage["Items"]);
                }

                if (Dump.Classes.TryGetValue("DroppedItemInteractionComponent", out var DroppedItemInteractionComponent))
                {
                    Stream.WriteHeader("DroppedItemInteractionComponent");
                    Stream.WriteOffset(DroppedItemInteractionComponent, "Item", DroppedItemInteractionComponent["Item"]);
                }

                if (Dump.Classes.TryGetValue("DroppedItem", out var DroppedItem))
                {
                    Stream.WriteHeader("DroppedItem");
                    Stream.WriteOffset(DroppedItem, "Item", DroppedItem["Item"]);
                }

                if (Dump.Classes.TryGetValue("Item", out var Item))
                {
                    Stream.WriteHeader("Item");
                    Stream.WriteOffset(Item, "ItemName", Item["ItemName"]);
                    Stream.WriteOffset(Item, "ItemCategory", Item["ItemCategory"]);
                    Stream.WriteOffset(Item, "ItemDetailedName", Item["ItemDetailedName"]);
                    Stream.WriteOffset(Item, "ItemDescription", Item["ItemDescription"]);
                    Stream.WriteOffset(Item, "StackCount", Item["StackCount"]);
                    Stream.WriteOffset(Item, "StackCountMax", Item["StackCountMax"]);
                    Stream.WriteOffset(Item, "StackCountMax", Item["StackCountMax"]);
                    Stream.WriteOffset(Item, "Category", Item["Category"]);
                }

                if (Dump.Classes.TryGetValue("TslWeapon_Trajectory", out var TslWeapon_Trajectory))
                {
                    Stream.WriteHeader("TslWeapon_Trajectory");
                    Stream.WriteOffset(TslWeapon_Trajectory, "WeaponTrajectoryData", TslWeapon_Trajectory["WeaponTrajectoryData"]);
                }

                if (Dump.Classes.TryGetValue("WeaponTrajectoryData", out var WeaponTrajectoryData))
                {
                    Stream.WriteHeader("WeaponTrajectoryData");
                    Stream.WriteOffset(WeaponTrajectoryData, "TrajectoryConfig", WeaponTrajectoryData["TrajectoryConfig"]);
                }

                if (Dump.Classes.TryGetValue("WeaponTrajectoryConfig", out var WeaponTrajectoryConfig))
                {
                    Stream.WriteHeader("WeaponTrajectoryConfig");
                    Stream.WriteOffset(WeaponTrajectoryConfig, "InitialSpeed", WeaponTrajectoryConfig["InitialSpeed"]);
                    Stream.WriteOffset(WeaponTrajectoryConfig, "VDragCoefficient", WeaponTrajectoryConfig["VDragCoefficient"]);
                    Stream.WriteOffset(WeaponTrajectoryConfig, "TravelDistanceMax", WeaponTrajectoryConfig["TravelDistanceMax"]);
                }
            }

            Console.ReadKey();
        }
    }
}
