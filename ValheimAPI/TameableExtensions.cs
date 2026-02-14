using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HoldToCommand.ValheimAPI
{
    internal static class TameableExtensions
    {
        private const float HoldThreshold = 0.45f;
        private static Tameable lastTarget = null;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetName(this Tameable tameable)
            => LowLevel.Tameable.__IAPI_SetName_Invoker1.Invoke(tameable);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float GetLastPetTime(this Tameable tameable)
            => LowLevel.Tameable.__IAPI_m_lastPetTime_Invoker.Get(tameable);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetLastPetTime(this Tameable tameable, float t)
            => LowLevel.Tameable.__IAPI_m_lastPetTime_Invoker.Set(tameable, t);

        public static bool CustomInteract(this Tameable tameable, Humanoid user, bool hold, bool alt)
        {
            var m_nview = tameable.GetComponent<ZNetView>();
            if (m_nview == null || !m_nview.IsValid())
            {
                return false;
            }

            // Shift+E rename (keep vanilla behavior)
            if (alt)
            {
                tameable.SetName();
                return true;
            }

            // only tamed creatures react
            if (!tameable.IsTamed())
            {
                return false;
            }

            var timeNow = UnityEngine.Time.time;
            var lastPetTime = tameable.GetLastPetTime();

            // HOLD = command (separated from pet)
            if (hold)
            {

                if (!tameable.m_commandable)
                {
                    return false;
                }

                if (timeNow - lastPetTime < HoldThreshold)
                {
                    return false;
                }

                if (lastTarget == tameable)
                {
                    return false;
                }

                lastTarget = tameable;
                tameable.Command(user);
                return true;
            }
            else
            {
                lastTarget = null;
            }

            // TAP = pet + message (no command)
            if (timeNow - lastPetTime <= 1f)
            {
                return false;
            }

            tameable.SetLastPetTime(timeNow);
            tameable.m_petEffect?.Create(tameable.transform.position, tameable.transform.rotation);

            // vanilla-like message selection
            string msg = null;
            if (tameable.m_tameTextGetter != null)
            {
                var text = tameable.m_tameTextGetter();
                if (!string.IsNullOrEmpty(text))
                {
                    msg = text;
                }
            }
            if (string.IsNullOrEmpty(msg))
            {
                var hoverName = tameable.GetHoverName();
                var tameText = tameable.m_tameText ?? "";
                msg = tameable.m_nameBeforeText ? (hoverName + " " + tameText) : tameText;
            }
            if (!string.IsNullOrEmpty(msg))
            {
                user.Message(MessageHud.MessageType.Center, msg);
            }

            return true;
        }

    }
}
