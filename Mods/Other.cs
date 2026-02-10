using System;
using System.Collections;
using UnityEngine;

namespace StupidTemplate.Mods
{
    internal class Other
    {
        #region Gunlib fix
        public static void GunLibfix()
        {
            GunLibfixStarter.EnsureStarted();
        }

        private static class GunLibfixStarter
        {
            private static GameObject _go;
            private const float DefaultPollInterval = 0.05f;

            public static void EnsureStarted()
            {
                if (_go != null)
                    return;

                _go = new GameObject("Gunlibfixver1");
                UnityEngine.Object.DontDestroyOnLoad(_go);
                var comp = _go.AddComponent<GunLibfixBehaviour>();
                comp.PollInterval = DefaultPollInterval;
            }
        }
        private class GunLibfixBehaviour : MonoBehaviour
        {
            public float PollInterval = 0.05f;
            private bool _prevRightGrab = false;
            private bool _initialized = false;

            private void Start()
            {
                StartCoroutine(Polldatshizx());
            }

            private IEnumerator Polldatshizx()
            {

                while (ControllerInputPoller.instance == null)
                {
                    yield return null;
                }

                _prevRightGrab = ControllerInputPoller.instance.rightGrab;
                _initialized = true;

                var wait = new WaitForSecondsRealtime(Mathf.Max(0.001f, PollInterval));
                while (true)
                {
                    bool currRightGrab = ControllerInputPoller.instance.rightGrab;


                    if (currRightGrab && !_prevRightGrab)
                    {
                        try
                        {
                            Yesyesgunfrfrfrfrfrfrfrfrfrfrfrfr();
                        }
                        catch (Exception)
                        {

                        }
                    }
                    else if (!currRightGrab && _prevRightGrab)
                    {
                        try
                        {
                            Nonomoregunfrfrfrfrfrfrfrfrfrfrfr();
                        }
                        catch (Exception)
                        {

                        }
                    }

                    _prevRightGrab = currRightGrab;

                    yield return wait;
                }
            }
            private void OnDestroy()
            {
                StopAllCoroutines();
            }
            #endregion
            #region Voids for gunlib fix
            public static void Nonomoregunfrfrfrfrfrfrfrfrfrfrfr() // Do not delete this is for gunlib fix
            {
                GameObject.Find("iiMenu_GunLine").SetActive(false);
                GameObject.Find("Gunpointer").SetActive(false);
            }
            public static void Yesyesgunfrfrfrfrfrfrfrfrfrfrfrfr()
            {
                GameObject.Find("iiMenu_GunLine").SetActive(true);
                GameObject.Find("GunPointer").SetActive(true);

            }
            #endregion
        }
    }
}
