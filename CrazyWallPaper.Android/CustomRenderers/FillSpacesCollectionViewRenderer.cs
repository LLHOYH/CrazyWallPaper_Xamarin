using System;
using Android.Content;
using Android.Support.V7.Widget;
using CrazyWallPaper.Droid.CustomRenderers;
using CrazyWallPaper.Views.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly:ExportRenderer(typeof(FillSpacesCollectionView), typeof(FillSpacesCollectionViewRenderer))]
namespace CrazyWallPaper.Droid.CustomRenderers
{
    public class FillSpacesCollectionViewRenderer : CollectionViewRenderer
    {

        public FillSpacesCollectionViewRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<ItemsView> elementChangedEvent)
        {
            base.OnElementChanged(elementChangedEvent);

            if (elementChangedEvent.NewElement != null)
            {
                this.SetLayoutManager(new StaggeredGridLayoutManager(2, 1));
            }

        }
    }
}
