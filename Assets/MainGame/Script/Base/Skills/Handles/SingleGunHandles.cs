using MainGame.Script.Common;

namespace MainGame.Script.Base.Skills.Handles
{
    public class AddBulletHandles : AddObjectHandles
    {
        private PlaneController planeController;
        protected override void Start()
        {
            base.Start();
            planeController = GetComponent<PlaneController>();
        }

        public override void Handle()
        {
            base.Handle();
            print("Fire 1 bullet");
        }
    }
}