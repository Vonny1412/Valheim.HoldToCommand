# Note for modders

HoldToCommand replaces Valheim's `Tameable.Interact()` method.
However, interaction can still be blocked by applying a prefix patch with `Priority.First` (or even without specifying a priority):

```csharp
[HarmonyPatch(typeof(Tameable), "Interact")]
static class Tameable_Interact_Patch
{
    [HarmonyPriority(Priority.First)]
    static bool Prefix(Tameable __instance, Humanoid user, bool hold, bool alt, ref bool __result)
    {
        ...
        __result = ...;
        return false;
    }
}
```

Returning `false` from the prefix will prevent HoldToCommand's interaction logic from running.

---

## Detecting petting

Petting updates the private field `Tameable.m_lastPetTime`.
Since this field is private, you can detect petting by comparing its value in a prefix/postfix pair.

Example:

```csharp
static float lastPetTimeBefore;

[HarmonyPatch(typeof(Tameable), "Interact")]
static class Tameable_Interact_Patch
{
    static void Prefix(Tameable __instance)
    {
        lastPetTimeBefore = (float)AccessTools
            .Field(typeof(Tameable), "m_lastPetTime")
            .GetValue(__instance);
    }

    static void Postfix(Tameable __instance)
    {
        float lastPetTimeAfter = (float)AccessTools
            .Field(typeof(Tameable), "m_lastPetTime")
            .GetValue(__instance);

        if (lastPetTimeAfter != lastPetTimeBefore)
        {
            // Petting happened
        }
    }
}
```

---

## Commanding

`Tameable.Command()` and `Tameable.RPC_Command()` can still be patched normally without any special handling.
