using System;
using Android.Content;
using Android.Util;
using Android.Views;

namespace Camera2Basic
{
	public class AutoFitTextureView : TextureView
	{
		private int _widthRatio = 0;
		private int _heightRatio = 0;

		public AutoFitTextureView(Context context)
			: this (context, null)
		{

		}
		public AutoFitTextureView (Context context, IAttributeSet attrs)
			: this (context, attrs, 0)
		{

		}
		public AutoFitTextureView (Context context, IAttributeSet attrs, int defStyle)
			: base (context, attrs, defStyle)
		{

		}

		public void SetAspectRatio(int width, int height)
		{
			if (width <= 0 || height <= 0)
				throw new ArgumentException ("Size cannot be negative.");
			_widthRatio = width;
			_heightRatio = height;
			RequestLayout ();
		}

		protected override void OnMeasure (int widthMeasureSpec, int heightMeasureSpec)
		{
			base.OnMeasure (widthMeasureSpec, heightMeasureSpec);
			int width = MeasureSpec.GetSize (widthMeasureSpec);
			int height = MeasureSpec.GetSize (heightMeasureSpec);
			if (0 == _widthRatio || 0 == _heightRatio) {
				SetMeasuredDimension (width, height);
			} else {
				if (width < (float)height * _widthRatio / (float)_heightRatio) {
					SetMeasuredDimension (width, width * _heightRatio / _widthRatio);
				} else {
					SetMeasuredDimension (height * _widthRatio / _heightRatio, height);
				}
			}
		}
	}
}

