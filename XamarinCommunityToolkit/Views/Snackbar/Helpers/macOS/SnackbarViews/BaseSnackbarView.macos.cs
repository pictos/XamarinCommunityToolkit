﻿using AppKit;

namespace Xamarin.CommunityToolkit.UI.Views.Helpers.macOS.SnackbarViews
{
	abstract class BaseSnackbarView : NSView
	{
		public BaseSnackbarView(MacOSSnackBar snackbar)
		{
			Snackbar = snackbar;
		}

		public NSLayoutConstraint BottomConstraint { get; protected set; }

		public NSLayoutConstraint CenterXConstraint { get; protected set; }

		public NSLayoutConstraint CenterYConstraint { get; protected set; }

		public NSLayoutConstraint LeadingConstraint { get; protected set; }

		public virtual NSView ParentView => NSApplication.SharedApplication.KeyWindow.ContentView;

		public NSLayoutConstraint TopConstraint { get; protected set; }

		public NSLayoutConstraint TrailingConstraint { get; protected set; }

		protected MacOSSnackBar Snackbar { get; }

		public virtual void Dismiss()
		{
			RemoveFromSuperview();
		}

		public virtual void Setup()
		{
			Initialize();
			ConstrainInParent();
			ConstrainChildren();
		}

		protected virtual void ConstrainChildren()
		{
		}

		protected virtual void ConstrainInParent()
		{
			BottomConstraint =
				BottomAnchor.ConstraintEqualToAnchor(ParentView.BottomAnchor, -Snackbar.Layout.MarginBottom);
			BottomConstraint.Active = true;

			TopConstraint =
				TopAnchor.ConstraintGreaterThanOrEqualToAnchor(ParentView.TopAnchor, Snackbar.Layout.MarginTop);
			TopConstraint.Active = true;

			LeadingConstraint =
				LeadingAnchor.ConstraintGreaterThanOrEqualToAnchor(ParentView.LeadingAnchor,
					Snackbar.Layout.MarginLeading);
			TrailingConstraint =
				TrailingAnchor.ConstraintGreaterThanOrEqualToAnchor(ParentView.TrailingAnchor,
					-Snackbar.Layout.MarginTrailing);
			CenterXConstraint = CenterXAnchor.ConstraintEqualToAnchor(ParentView.CenterXAnchor);

			NSLayoutConstraint.ActivateConstraints(new[] { LeadingConstraint, TrailingConstraint, CenterXConstraint });
		}

		protected virtual void Initialize()
		{
			WantsLayer = true;
			if (Layer != null)
			{
				Layer.BackgroundColor = Snackbar.Appearance.Color.CGColor;
				Layer.CornerRadius = Snackbar.Appearance.CornerRadius;
			}

			TranslatesAutoresizingMaskIntoConstraints = false;
		}
	}
}