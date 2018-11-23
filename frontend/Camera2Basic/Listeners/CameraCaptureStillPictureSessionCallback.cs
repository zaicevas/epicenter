using Android.Hardware.Camera2;
using Android.Util;

namespace Camera2Basic.Listeners
{
    public class CameraCaptureStillPictureSessionCallback : CameraCaptureSession.CaptureCallback
    {
        private static readonly string TAG = "CameraCaptureStillPictureSessionCallback";
        private readonly CameraFragment owner;

        public CameraCaptureStillPictureSessionCallback(CameraFragment owner)
        {
            this.owner = owner ?? throw new System.ArgumentNullException("owner");
        }

        public override void OnCaptureCompleted(CameraCaptureSession session, CaptureRequest request, TotalCaptureResult result)
        {
            if (owner == null)
                return;
            Log.Debug(TAG, owner.ImageFile.ToString());
            owner.UnlockFocus();
        }
    }
}
