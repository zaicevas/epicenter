using Android.App;
using Android.Hardware.Camera2;

namespace Camera2Basic.Listeners
{
    public class CameraStateListener : CameraDevice.StateCallback
    {
        public CameraFragment Owner { get; set; }

        public override void OnOpened(CameraDevice cameraDevice)
        {
            if (Owner == null)
                return;
            Owner.CameraOpenCloseLock.Release();
            Owner.CameraDevice = cameraDevice;
            Owner.CreateCameraPreviewSession();
        }

        public override void OnDisconnected(CameraDevice cameraDevice)
        {
            if (Owner == null)
                return;
            Owner.CameraOpenCloseLock.Release();
            cameraDevice.Close();
            Owner.CameraDevice = null;
        }

        public override void OnError(CameraDevice cameraDevice, CameraError error)
        {
            if (Owner == null)
                return;
            Owner.CameraOpenCloseLock.Release();
            cameraDevice.Close();
            Owner.CameraDevice = null;
            if (Owner == null)
                return;
            Activity activity = Owner.Activity;
            if (activity != null)
            {
                activity.Finish();
            }
        }
    }
}