using Android.App;
using Android.Hardware.Camera2;

namespace Camera2Basic.Listeners
{
    public class CameraStateListener : CameraDevice.StateCallback
    {
        private readonly Camera2BasicFragment owner;

        public CameraStateListener(Camera2BasicFragment owner)
        {
            if (owner == null)
                throw new System.ArgumentNullException("owner");
            this.owner = owner;
        }

        public override void OnOpened(CameraDevice cameraDevice)
        {
            // This method is called when the camera is opened.  We start camera preview here.
            owner.CameraOpenCloseLock.Release();
            owner.CameraDevice = cameraDevice;
            owner.CreateCameraPreviewSession();
        }

        public override void OnDisconnected(CameraDevice cameraDevice)
        {
            owner.CameraOpenCloseLock.Release();
            cameraDevice.Close();
            owner.CameraDevice = null;
        }

        public override void OnError(CameraDevice cameraDevice, CameraError error)
        {
            owner.CameraOpenCloseLock.Release();
            cameraDevice.Close();
            owner.CameraDevice = null;
            if (owner == null)
                return;
            Activity activity = owner.Activity;
            if (activity != null)
            {
                activity.Finish();
            }
        }
    }
}