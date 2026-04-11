using UnityEngine;

namespace MC.Core.Unity.Scenes
{
    public class SceneFlowController : MonoBehaviour
    {
        public void PushScene(SceneReferenceSo newScene)
        {
            if (ValidateScene(newScene))
                SceneStacker.Instance.PushScene(newScene.Name);
        }

        public void PopScene()
        {
            SceneStacker.Instance.PopScene();
        }

        public void ReplaceScene(SceneReferenceSo newScene)
        {
            if (ValidateScene(newScene))
                SceneStacker.Instance.ReplaceScene(newScene.Name);
        }

        private static bool ValidateScene(SceneReferenceSo scene)
        {
            if (scene != null && !string.IsNullOrEmpty(scene.Name)) return true;
            Debug.LogError("SceneFlowController: Invalid scene reference provided.");
            return false;
        }
    }

}
