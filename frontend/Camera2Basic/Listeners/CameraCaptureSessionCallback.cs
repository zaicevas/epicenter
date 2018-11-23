using Android.Hardware.Camera2;

namespace Camera2Basic.Listeners
{
    public class CameraCaptureSessionCallback : CameraCaptureSession.StateCallback
    {
        private readonly CameraFragment owner;

        public CameraCaptureSessionCallback(CameraFragment owner)
        {
            this.owner = owner ?? throw new System.ArgumentNullException("owner");
        }

        public override void OnConfigureFailed(CameraCaptureSession session)
        {
            Owner.ShowToast("Failed");
        }

        public override void OnConfigured(CameraCaptureSession session)
        {
            if (Owner == null)
                return;
            // The camera is already closed
            if (null == Owner.CameraDevice)
            {
                return;
            }

            // When the session is ready, we start displaying the preview.
            Owner.CaptureSession = session;
            try
            {
                // Auto focus should be continuous for camera preview.
                Owner.PreviewRequestBuilder.Set(CaptureRequest.ControlAfMode, (int)ControlAFMode.ContinuousPicture);
                // Flash is automatically enabled when necessary.
                Owner.SetAutoFlash(Owner.PreviewRequestBuilder);

                // Finally, we start displaying the camera preview.
                Owner.PreviewRequest = Owner.PreviewRequestBuilder.Build();
                Owner.CaptureSession.SetRepeatingRequest(Owner.PreviewRequest,
                        Owner.CaptureCallback, Owner.BackgroundHandler);
            }
            catch (CameraAccessException e)
            {
                e.PrintStackTrace();
            }
        }
    }
}