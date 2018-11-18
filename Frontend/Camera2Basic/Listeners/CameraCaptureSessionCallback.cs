using Android.Hardware.Camera2;

namespace Camera2Basic.Listeners
{
    public class CameraCaptureSessionCallback : CameraCaptureSession.StateCallback
    {
        private readonly Camera2BasicFragment owner;

        public CameraCaptureSessionCallback(Camera2BasicFragment owner)
        {
            if (owner == null)
                throw new System.ArgumentNullException("owner");
            this.owner = owner;
        }

        public override void OnConfigureFailed(CameraCaptureSession session)
        {
            owner.ShowToast("Failed");
        }

        public override void OnConfigured(CameraCaptureSession session)
        {
            // The camera is already closed
            if (null == owner.CameraDevice)
            {
                return;
            }

            // When the session is ready, we start displaying the preview.
            owner.CaptureSession = session;
            try
            {
                // Auto focus should be continuous for camera preview.
                owner.PreviewRequestBuilder.Set(CaptureRequest.ControlAfMode, (int)ControlAFMode.ContinuousPicture);
                // Flash is automatically enabled when necessary.
                owner.SetAutoFlash(owner.PreviewRequestBuilder);

                // Finally, we start displaying the camera preview.
                owner.PreviewRequest = owner.PreviewRequestBuilder.Build();
                owner.CaptureSession.SetRepeatingRequest(owner.PreviewRequest,
                        owner.CaptureCallback, owner._backgroundHandler);
            }
            catch (CameraAccessException e)
            {
                e.PrintStackTrace();
            }
        }
    }
}